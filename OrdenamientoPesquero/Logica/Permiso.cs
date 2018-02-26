using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Permiso
    {
        string FOLIO { get; set; }
        string RNPA { get; set; }
        string NPERMISO { get; set; }
        string PESQUERIA { get; set; }
        string LUGAR { get; set; }
        string DIAEXP { get; set; }
        string FINVIGENCIA { get; set; }
        string ZONAPESC { get; set; }
        string SITIOS { get; set; }
        string OBSERVACIONES { get; set; }
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
