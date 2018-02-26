using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenamientoPesquero.Clases_Entidad
{
    class Pescador
    {
        string COD_REG = "";
        string NOMBRE = "";
        string AP_PAT = "";
        string AP_MAT = "";
        string CURP = "";
        string RFC = "";
        string ESCOLARIDAD = "";
        string TIP_SANG = "";
        string SEXO = "";
        string LUG_NACIMI = "";
        string FECH_NACIMI = "";
        string CALLENUM = "";
        string COLONIA = "";
        string LOCALIDAD = "";
        string MUNICIPIO = "";
        string CP = "";
        string TEL = "";
        string TIPO_PESC = "";
        string OCP_LABORAL = "";
        string CUERPO_DE_AGUA = "";
        string MATRICULA = "";
        public Pescador()
        {
             COD_REG = "";
             NOMBRE = "";
             AP_PAT = "";
             AP_MAT = "";
             CURP = "";
             RFC = "";
             ESCOLARIDAD = "";
             TIP_SANG = "";
             SEXO = "";
             LUG_NACIMI = "";
             FECH_NACIMI = "";
             CALLENUM = "";
             COLONIA = "";
             LOCALIDAD = "";
             MUNICIPIO = "";
             CP = "";
             TEL = "";
             TIPO_PESC = "";
             OCP_LABORAL = "";
             CUERPO_DE_AGUA = "";
             MATRICULA = "";
        }
        public Pescador(string cOD_REG,
        string nOMBRE,
        string aP_PAT,
        string aP_MAT,
        string cURP,
        string rFC,
        string eSCOLARIDAD,
        string tIP_SANG,
        string sEXO,
        string lUG_NACIMI,
        string fECH_NACIMI,
        string cALLENUM,
        string cOLONIA,
        string lOCALIDAD,
        string mUNICIPIO,
        string cP,
        string tEL,
        string tIPO_PESC,
        string oCP_LABORAL,
        string cUERPO_DE_AGUA,
        string mATRICULA)
        {
            COD_REG = cOD_REG;
            NOMBRE = nOMBRE;
            AP_PAT = aP_PAT;
            AP_MAT = aP_MAT;
            CURP = cURP;
            RFC = rFC;
            ESCOLARIDAD = eSCOLARIDAD;
            TIP_SANG = tIP_SANG;
            SEXO = sEXO;
            LUG_NACIMI = =lUG_NACIMI;
            FECH_NACIMI = fECH_NACIMI;
            CALLENUM = cALLENUM;
            COLONIA = cOLONIA;
            LOCALIDAD = lOCALIDAD;
            MUNICIPIO = mUNICIPIO;
            CP = cP;
            TEL = tEL;
            TIPO_PESC = tIP_SANG;
            OCP_LABORAL = oCP_LABORAL;
            CUERPO_DE_AGUA = cUERPO_DE_AGUA;
            MATRICULA = mATRICULA;
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
