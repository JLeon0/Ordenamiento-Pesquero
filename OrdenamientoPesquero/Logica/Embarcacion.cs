using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{ 
    public class Embarcacion
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string RNPA { get; set; }
        public string AVID { get; set; }
        public string MARCA { get; set; }
        public string HP { get; set; }
        public string MUNICIPIO { get; set; }
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
    }
}
