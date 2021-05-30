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
    class Contigencia:ConnectionToSQL
    {
        //atributos
        private int id;
        private int idConsecuencia;
        private string descripcion;

        //constructor
        public Contigencia(int id = 0, int idConsecuencia = 0, string descripcion) {
            this.Id = id;
            this.IdConsecuencia = idConsecuencia;
            this.Descripcion = descripcion;
        }
        //get and set
        public int Id { get => id; set => id = value; }
        public int IdConsecuencia { get => idConsecuencia; set => idConsecuencia = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }


        //CRUD
        public bool Insertar(Contigencia r)
        {
            try
            {

                using (var connecion = GetConnection())
                {
                    connecion.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = connecion;

                        comando.CommandText = "sp_add_contigencia";   //nombre proceso
                        comando.CommandType = CommandType.StoredProcedure;


                        comando.Parameters.AddWithValue("@idConsecuencia", r.IdConsecuencia);
                        comando.Parameters.AddWithValue("@descripcion", r.Descripcion);
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

        public bool ActualizarDatos(Contigencia r)
        {
            try
            {
                using (var coneccion = GetConnection())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = coneccion;

                        comando.CommandText = "sp_update_consecuencia";
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@id", r.Id);
                        comando.Parameters.AddWithValue("@idConsecuencia", r.IdConsecuencia);
                        comando.Parameters.AddWithValue("@descripcion", r.Descripcion);
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
                        comando.CommandText = "sp_show_Contigencia";
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

                        comando.CommandText = "sp_search_contigencia";
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

    }
}
