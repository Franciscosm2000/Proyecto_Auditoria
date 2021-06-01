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
   public class Control: ConnectionToSQL
    {
        //atributos
        private int id;
        private int idRiesgo;
        private string descripcion;
        private string eficiencia;

        //constructor
        public Control(int id=0, int idRiesgo = 0, string descripcion = null, string eficiencia = null) {
            this.Id = id;
            this.IdRiesgo = idRiesgo;
            this.Descripcion = descripcion;
            this.Eficiencia = eficiencia;
        }

        //get y set
        public int Id { get => id; set => id = value; }
        public int IdRiesgo { get => idRiesgo; set => idRiesgo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Eficiencia { get => eficiencia; set => eficiencia = value; }


        //CRUD
        public bool Insertar(Control r)
        {
            try
            {

                using (var connecion = GetConnection())
                {
                    connecion.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = connecion;

                        comando.CommandText = "sp_add_control";   //nombre proceso
                        comando.CommandType = CommandType.StoredProcedure;


                        comando.Parameters.AddWithValue("@idRiesgo", r.IdRiesgo);
                        comando.Parameters.AddWithValue("@descripcion", r.Descripcion);
                        comando.Parameters.AddWithValue("@eficiencia", r.Eficiencia);
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

        public bool ActualizarDatos(Control r)
        {
            try
            {
                using (var coneccion = GetConnection())
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = coneccion;

                        comando.CommandText = "sp_update_control";
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@id", r.Id);
                        comando.Parameters.AddWithValue("@idRiesgo", r.IdRiesgo);
                        comando.Parameters.AddWithValue("@descripcion", r.Descripcion);
                        comando.Parameters.AddWithValue("@eficiencia", r.Eficiencia);
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
                        comando.CommandText = "sp_show_control";
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

                        comando.CommandText = "sp_search_control";
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
