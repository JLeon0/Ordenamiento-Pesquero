﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Pescador
    {
        public string NOMBRE = "";
        public string AP_PAT = "";
        public string AP_MAT = "";
        public string CURP = "";
        public string RFC = "";
        public string ESCOLARIDAD = "";
        public string TIP_SANG = "";
        public string SEXO = "";
        public string LUG_NACIMI = "";
        public string FECH_NACIMI = "";
        public string CALLENUM = "";
        public string COLONIA = "";
        public string MUNICIPIO = "";
        public string CP = "";
        public string TEL = "";
        public string TIPO_PESC = "";
        public string OCP_LABORAL = "";
        public string CUERPO_DE_AGUA = "";
        public string MATRICULA = "";
        public string CORREO = "";
        public string LOCALIDAD = "";
        public int ORDENADO = 0;
        public Pescador()
        {
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
             MUNICIPIO = "";
             CP = "";
             TEL = "";
             TIPO_PESC = "";
             OCP_LABORAL = "";
             CUERPO_DE_AGUA = "";
             MATRICULA = "";
            CORREO = "";
            LOCALIDAD = "";
            ORDENADO = 0;
        }
        public Pescador(
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
        string mUNICIPIO,
        string cP,
        string tEL,
        string tIPO_PESC,
        string oCP_LABORAL,
        string cUERPO_DE_AGUA,
        string mATRICULA, string correo, string localidad,
        int Ordenado)
        {
            NOMBRE = nOMBRE;
            AP_PAT = aP_PAT;
            AP_MAT = aP_MAT;
            CURP = cURP;
            RFC = rFC;
            ESCOLARIDAD = eSCOLARIDAD;
            TIP_SANG = tIP_SANG;
            SEXO = sEXO;
            LUG_NACIMI = lUG_NACIMI;
            FECH_NACIMI = fECH_NACIMI;
            CALLENUM = cALLENUM;
            COLONIA = cOLONIA;
            MUNICIPIO = mUNICIPIO;
            CP = cP;
            TEL = tEL;
            TIPO_PESC = tIPO_PESC;
            OCP_LABORAL = oCP_LABORAL;
            CUERPO_DE_AGUA = cUERPO_DE_AGUA;
            MATRICULA = mATRICULA;
            CORREO = correo;
            LOCALIDAD = localidad;
            ORDENADO = Ordenado;
        }
    }
}
