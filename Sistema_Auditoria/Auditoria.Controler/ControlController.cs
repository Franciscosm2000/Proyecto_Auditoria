using Auditoria.Model.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria.Controler
{
    public class ControlController
    {
        //Insert
        bool insertar(int idRiesgo , string descripcion ,string eficiencia)
        {

            Control c = new Control(0,idRiesgo,descripcion,eficiencia);

            return c.Insertar(c);
        }

        //UPDATE
        public void Update(int id, int idRiesgo, string descripcion, string eficiencia)
        {

            Control r = new Control(id,idRiesgo,descripcion,eficiencia);
            r.ActualizarDatos(r);
        }

        //Show
        public static DataTable Show()
        {
            Control r = new Control();

            return r.Mostrar();
        }
    }
}
