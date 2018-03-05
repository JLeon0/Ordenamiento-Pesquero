using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Permiso
    {
        public string FOLIO { get; set; }
        public string RNPA { get; set; }
        public string NPERMISO { get; set; }
        public string PESQUERIA { get; set; }
        public string LUGAR { get; set; }
        public string DIAEXP { get; set; }
        public string FINVIGENCIA { get; set; }
        public string ZONAPESC { get; set; }
        public string SITIOS { get; set; }
        public string OBSERVACIONES { get; set; }
        public Permiso()
        {
            FOLIO = "";
            RNPA = "";
            NPERMISO = "";
            PESQUERIA = "";
            LUGAR = "";
            DIAEXP = "";
            FINVIGENCIA = "";
            ZONAPESC = "";
            SITIOS = "";
            OBSERVACIONES = "";
        }
        public Permiso(string folio, string rnpa, string npermiso, string pesqueria, string lugar, string diaexp, string finvig, string zonapesca, string sitios, string obs)
        {
            FOLIO = folio;
            RNPA = rnpa;
            NPERMISO = npermiso;
            PESQUERIA = pesqueria;
            LUGAR = lugar;
            DIAEXP = diaexp;
            FINVIGENCIA = finvig;
            ZONAPESC = zonapesca;
            SITIOS = sitios;
            OBSERVACIONES = obs;
        }
    }
}
