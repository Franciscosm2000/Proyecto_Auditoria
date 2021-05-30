using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Auditoria.Model.Conexion
{
    abstract class ConnectionToSQL
    {
        //String solo lectura 
        private readonly string connectionString;

        //Constructor
        public ConnectionToSQL()
        {
            //Cadena servidor 
            connectionString = @"server=tcp:FRANCISCO,12500; DataBase =PawnSystem; User Id = CasaDeEmpeño; Password=1320022077";

        }

        //Solo accedido de una clase eradada
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
