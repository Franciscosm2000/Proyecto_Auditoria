using Auditoria.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Auditoria.Model.MODELOS
{
    public class Riesgo : ConnectionToSQL
    {
        //atributos
        private int id;
        private string nombre;
        private string probabilidad;
        private string impacto;
        private string ocurrencia;

        //Constructor

        public Riesgo(int id = 0, string nombre = null, string probabilidad = null, string impacto = null, string ocurrencia= null) {
            this.Id = id;
            this.Nombre = nombre;
            this.Probabilidad = probabilidad;
            this.Impacto = impacto;
            this.Ocurrencia = ocurrencia;
        }

        //get and set
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Probabilidad { get => probabilidad; set => probabilidad = value; }
        public string Impacto { get => impacto; set => impacto = value; }
        public string Ocurrencia { get => ocurrencia; set => ocurrencia = value; }


        //CRUD
        public bool Insertar(Riesgo r)
        {
            try
            {

                using (var connecion = GetConnection())
                {
                    connecion.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = connecion;

                        comando.CommandText = "sp_add_riesgo";   //nombre proceso
                        comando.CommandType = CommandType.StoredProcedure;


                        comando.Parameters.AddWithValue("@nombre", r.Nombre);
                        comando.Parameters.AddWithValue("@probabilidad", r.Probabilidad);
                        comando.Parameters.AddWithValue("@impacto", r.Impacto);
                        comando.Parameters.AddWithValue("@ocurrencia", r.Ocurrencia);
                        comando.ExecuteNonQuery();

                        comando.Parameters.Clear();
                    }
                    return true;
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool ActualizarDatos(Riesgo r)
        {
            try
            {
                using (var coneccion = GetConnection())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = coneccion;

                        comando.CommandText = "sp_update_riesgo";
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@id", r.Id);
                        comando.Parameters.AddWithValue("@nombre", r.Nombre);
                        comando.Parameters.AddWithValue("@probabilidad", r.Probabilidad);
                        comando.Parameters.AddWithValue("@impacto", r.Impacto);
                        comando.Parameters.AddWithValue("@ocurrencia", r.Ocurrencia);
                        comando.ExecuteNonQuery();

                        comando.Parameters.Clear();

                        return true;
                    }//fin segundo using 
                }//fin de primer using
            }
            catch(Exception e)
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
                    comando.CommandText = "sp_show_riesgo";
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

                        comando.CommandText = "sp_search_riesgo";
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Dato", dato);
                        SqlDataAdapter leer = new SqlDataAdapter(comando);
                        leer.Fill(res);
                        comando.Parameters.Clear();
                    }//Termina 2do using
                }//Termina primer using
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }

            return res;
        }


    }
}
