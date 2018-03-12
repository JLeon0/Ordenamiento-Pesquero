using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Directiva
    {
        public string RNPA { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Fecha_Ing { get; set; }
        public string Telefono { get; set; }

        public Directiva()
        {
            RNPA = "";
            Nombre = "";
            Cargo = "";
            Fecha_Ing = "";
            Telefono = "";
        }

        public Directiva(string rnpa, string nombre, string cargo, string fechaing, string telefono)
        {
            RNPA = rnpa;
            Nombre = nombre;
            Cargo = cargo;
            Fecha_Ing = fechaing;
            Telefono = telefono;

        }
    }
}
