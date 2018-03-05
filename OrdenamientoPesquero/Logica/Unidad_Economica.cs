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
        public string PRESIDENTE { get; set; }
        public string TESORERO { get; set; }
        public string SECRETARIO { get; set; }
        public string TELPRES { get; set; }
        public string TELTESOR { get; set; }
        public string TELSECRE { get; set; }
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
             PRESIDENTE = "";
             TESORERO = "";
             SECRETARIO = "";
             TELPRES = "";
             TELTESOR = "";
             TELSECRE = "";
        }
        public Unidad_Economica(string rNPA, string nOMBRE, string tIPO, string cALLE, string rFC, string cOLONIA, string lOCALIDAD,  string mUNICIPIO, string cP, string cORREO, string tELEFONO, string pRESIDENTE, string tESORERO,
        string sECRETARIO,
        string tELPRES,
        string tELTESOR,
        string tELSECRE)
        {
            RNPA = rNPA;
            NOMBRE = nOMBRE;
            TIPO = tIPO;
            CALLE = cALLE;
            RFC = rFC;
            COLONIA = cALLE;
            LOCALIDAD = lOCALIDAD;
            MUNICIPIO = mUNICIPIO;
            CP = cP;
            CORREO = cORREO;
            TELEFONO = tELEFONO;
            PRESIDENTE = pRESIDENTE;
            TESORERO = tESORERO;
            SECRETARIO = sECRETARIO;
            TELPRES = tELPRES;
            TELTESOR = tELTESOR;
            TELSECRE = tELSECRE;
        }
    }
}
