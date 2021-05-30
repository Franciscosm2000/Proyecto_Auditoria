using Auditoria.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public int Id { get => id; set => id = value; }
        public int IdConsecuencia { get => idConsecuencia; set => idConsecuencia = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
