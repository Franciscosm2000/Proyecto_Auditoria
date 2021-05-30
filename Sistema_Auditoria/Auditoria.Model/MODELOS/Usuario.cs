using Auditoria.Model.Conexion;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Auditoria.Model.MODELOS
{
    class Usuario: ConnectionToSQL
    {

        //atributos
        private int id;
        private string nombre_usuario;
        private string password;
        private bool estado;

        public Usuario(int id=0, string nombre_usuario = null, string password = null, bool estado = false)
        {
            this.Id = id;
            this.Nombre_usuario = nombre_usuario;
            this.Password = password;
            this.Estado = estado;
        }
        //Get and Set
        public int Id { get => id; set => id = value; }
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public string Password { get => password; set => password = value; }
        public bool Estado { get => estado; set => estado = value; }


        //CRUD
        public bool Insertar(Usuario r)
        {
            CrearPasswordHash(r.Password, out byte[] passwordHash, out byte[] passwordSalt); //encriptacion
            try
            {

                using (var connecion = GetConnection())
                {
                    connecion.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = connecion;

                        comando.CommandText = "sp_add_usuario";   //nombre proceso
                        comando.CommandType = CommandType.StoredProcedure;


                        comando.Parameters.AddWithValue("@nombre_usuario", r.Nombre_usuario);
                        comando.Parameters.AddWithValue("@password_hash", passwordHash);
                        comando.Parameters.AddWithValue("@password_salt", passwordSalt);
                        comando.Parameters.AddWithValue("@estado",true);
                        comando.ExecuteNonQuery();

                        comando.Parameters.Clear();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool ActualizarDatos(Usuario r)
        {
            CrearPasswordHash(r.Password, out byte[] passwordHash, out byte[] passwordSalt); //encriptacion
            try
            {
                using (var coneccion = GetConnection())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = coneccion;

                        comando.CommandText = "sp_update_usuario";
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@id", r.Id);
                        comando.Parameters.AddWithValue("@nombre_usuario", r.Nombre_usuario);
                        comando.Parameters.AddWithValue("@password_hast", passwordHash);
                        comando.Parameters.AddWithValue("@password_salt", passwordSalt);
                        comando.ExecuteNonQuery();

                        comando.Parameters.Clear();

                        return true;
                    }//fin segundo using 
                }//fin de primer using
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public DataTable Mostrar()
        {

            DataTable res = new DataTable();
            try
            {

                using (var co = GetConnection())
                {
                    co.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = co;
                        comando.CommandText = "sp_show_usuario";
                        comando.CommandType = CommandType.StoredProcedure;
                        // comando.Parameters.AddWithValue("@tipo", "text");
                        comando.ExecuteNonQuery();

                        SqlDataAdapter adp = new SqlDataAdapter(comando);
                        adp.Fill(res);

                    }//fin segundo using
                }//fin primer using
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public DataTable Buscar(string dato)
        {
            DataTable res = new DataTable();
            try
            {
                using (var coneccion = GetConnection())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = coneccion;

                        comando.CommandText = "sp_search_usuario";
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Dato", dato);
                        SqlDataAdapter leer = new SqlDataAdapter(comando);
                        leer.Fill(res);
                        comando.Parameters.Clear();
                    }//Termina 2do using
                }//Termina primer using
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public bool Login(string usuario, string password) {
            try
            {

                byte  [] password_hash ;
                byte  [] password_salt;

                //buscamos usuario
                password_hash = ObjectToByteArray( Buscar(usuario).Rows[0]["password_hash"]);
                password_salt = ObjectToByteArray( Buscar(usuario).Rows[0]["password_salt"]);

                //verificamos

                if (!VerificarPasswordHash(password, password_hash, password_salt))
                {
                    return false;
                }
                else {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
               
            }
        }

        //convert object to byte[] 
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }


        //Encriptacion de clave

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }

    }
}
