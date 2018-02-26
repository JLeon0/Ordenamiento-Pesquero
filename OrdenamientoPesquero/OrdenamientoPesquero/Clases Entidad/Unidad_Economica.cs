using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenamientoPesquero.Clases_Entidad
{
    public class Unidad_Economica
    {
        string RNPA { get; set; }
        string NOMBRE { get; set; }
        string TIPO { get; set; }
        string CALLE { get; set; }
        string RFC { get; set; }
        string COLONIA { get; set; }
        string LOCALIDAD { get; set; }
        string MUNICIPIO { get; set; }
        string CP { get; set; }
        string CORREO { get; set; }
        string TELEFONO { get; set; }
        string PRESIDENTE { get; set; }
        string TESORERO { get; set; }
        string SECRETARIO { get; set; }
        string TELPRES { get; set; }
        string TELTESOR { get; set; }
        string TELSECRE { get; set; }
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
            TESORERO = TESORERO;
            SECRETARIO = sECRETARIO;
            TELPRES = tELPRES;
            TELTESOR = tELTESOR;
            TELSECRE = tELSECRE;
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
