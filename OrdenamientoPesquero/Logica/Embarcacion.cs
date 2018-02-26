using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{ 
    class Embarcacion
    {
        string Nombre { get; set; }
        string Matricula { get; set; }
        string RNPA { get; set; }
        string AVID { get; set; }
        string MARCA { get; set; }
        string HP { get; set; }
        string MUNICIPIO { get; set; }
        public Embarcacion()
        {
            Nombre = "";
            Matricula = "";
            RNPA = "";
            AVID = "";
            MARCA = "";
            HP = "";
            MUNICIPIO = "";
        }
        public Embarcacion(string nombre,
        string matricula,
        string rNPA,
        string aVID,
        string mARCA,
        string hP,
        string mUNICIPIO)
        {
            Nombre = nombre;
            Matricula = matricula;
            RNPA = rNPA;
            AVID = aVID;
            MARCA = mARCA;
            HP = hP;
            MUNICIPIO = mUNICIPIO;
        }
        public void Registrar()
        {

        }
        public void Actualizar()
        {

        }
        public void Eliminar()
        {

        }
    }
}
