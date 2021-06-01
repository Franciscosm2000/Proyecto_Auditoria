using Auditoria.Model.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria.Controler
{
   public class ContingenciaController
    {
        //Insert
        bool insertar(int idConsecuencia, string descripcion)
        {

            Contigencia c = new Contigencia(0, idConsecuencia, descripcion);

            return c.Insertar(c);
        }

        //UPDATE
        public void Update(int id, int idConsecuencia, string descripcion)
        {

            Contigencia r = new Contigencia(id, idConsecuencia, descripcion);
            r.ActualizarDatos(r);
        }

        //Show
        public static DataTable Show()
        {
            Contigencia r = new Contigencia();

            return r.Mostrar();
        }
    }
}
