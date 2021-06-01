using Auditoria.Model.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria.Controler
{
  public  class RiesgoController
    {
        //Insert
         bool insertar(string nombre = null, string probabilidad = null, string impacto = null, string ocurrencia = null) {

            Riesgo r = new Riesgo(0,nombre,probabilidad,impacto,ocurrencia);

            return r.Insertar(r);
        }

        //UPDATE
        public void Update(int id, string nombre , string probabilidad, string impacto, string ocurrencia)
        {

            Riesgo r = new Riesgo(id,nombre,probabilidad,impacto,ocurrencia);
            r.ActualizarDatos(r);
        }

        //Show
        public static DataTable Show()
        {
            Riesgo r = new Riesgo();

            return r.Mostrar();
        }
    }
}
