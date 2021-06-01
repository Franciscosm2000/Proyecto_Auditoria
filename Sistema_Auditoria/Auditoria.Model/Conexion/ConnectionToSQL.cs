using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Auditoria.Model.Conexion
{
    abstract public class ConnectionToSQL
    {
        //String solo lectura 
        private readonly string connectionString;

        //Constructor
        public ConnectionToSQL()
        {
            //Cadena servidor 
            connectionString = @"Data Source=DESKTOP-PVPMNFE\SQLEXPRESS;Initial Catalog=COSO;Integrated Security=True";

        }

        //Solo accedido de una clase eradada
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
