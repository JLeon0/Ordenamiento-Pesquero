using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Unidad_Economica
    {
        public string RNPA { get; set; }
        public string NOMBRE { get; set; }
        public string TIPO { get; set; }
        public string CALLE { get; set; }
        public string RFC { get; set; }
        public string COLONIA { get; set; }
        public string LOCALIDAD { get; set; }
        public string MUNICIPIO { get; set; }
        public string CP { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }

        public Unidad_Economica()
        {
             RNPA = "";
             NOMBRE = "";
             TIPO = "";
             CALLE = "";
             RFC = "";
             COLONIA = "";
             LOCALIDAD = "";
             MUNICIPIO = "";
             CP = "";
             CORREO = "";
             TELEFONO = "";
        }
        public Unidad_Economica(string rNPA, string nOMBRE, string tIPO, string cALLE, string rFC, string cOLONIA, string lOCALIDAD,  string mUNICIPIO, string cP, string cORREO, string tELEFONO)
        {
            RNPA = rNPA;
            NOMBRE = nOMBRE;
            TIPO = tIPO;
            CALLE = cALLE;
            RFC = rFC;
            COLONIA = cOLONIA;
            LOCALIDAD = lOCALIDAD;
            MUNICIPIO = mUNICIPIO;
            CP = cP;
            CORREO = cORREO;
            TELEFONO = tELEFONO;
        }
    }
}
