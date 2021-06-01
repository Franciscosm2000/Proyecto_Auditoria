using Auditoria.Model.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria.Controler
{
    public class ConsecuenciaController
    {
        //Insert
        bool insertar(int idRiesgo, string descripcion)
        {

            Consecuencia c = new Consecuencia(0, idRiesgo, descripcion);

            return c.Insertar(c);
        }

        //UPDATE
        public void Update(int id, int idRiesgo, string descripcion)
        {

            Consecuencia r = new Consecuencia(id, idRiesgo, descripcion);
            r.ActualizarDatos(r);
        }

        //Show
        public static DataTable Show()
        {
            Consecuencia r = new Consecuencia();

            return r.Mostrar();
        }
    }
}
