using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Solicitud
    {
        public string NOMBRE { get; set; }
        public string CURP { get; set; }
        public string FOLIO { get; set; }
        public string FECHA { get; set; }
        public string PRIORIDAD { get; set; }
        public string CONCEPTO { get; set; }
        public string ESTATUS { get; set; }
        public string MONTO { get; set; }
        public string RESPONSABLE { get; set; }
        public string DIRECTOR { get; set; }
        public string OBSERVACIONES { get; set; }

        public string MONTOFEDERAL { get; set; }
        public string MONTOESTATAL { get; set; }
        public string MONTOPRODUCTOR { get; set; }
        public string MONTOOTRO { get; set; }
        public string TOTAL { get; set; }
        public string PROGRAMA { get; set; }

        public Solicitud()
        {
            NOMBRE = "";
            CURP = "";
            FOLIO = "";
            FECHA = "";
            PRIORIDAD = "";
            CONCEPTO = "";
            ESTATUS = "";
            MONTO = "";
            RESPONSABLE = "";
            DIRECTOR = "";
            OBSERVACIONES = "";
        }

        public Solicitud(string nombre, string curp, string folio, string fecha, string prioridad, string concepto, string estatus, string monto, string responsable, string director, string observaciones)
        {
            NOMBRE = nombre;
            CURP = curp;
            FOLIO = folio;
            FECHA = fecha;
            PRIORIDAD = prioridad;
            CONCEPTO = concepto;
            ESTATUS = estatus;
            MONTO = monto;
            RESPONSABLE = responsable;
            DIRECTOR = director;
            OBSERVACIONES = observaciones;
        }

        public Solicitud(string nombre, string curp, string folio, string fecha, string concepto, string observaciones, string montoF, string montoE, string montoP, string montoO, string programa, string total, int apoyo)
        {
            NOMBRE = nombre;
            CURP = curp;
            FOLIO = folio;
            FECHA = fecha;
            CONCEPTO = concepto;
            OBSERVACIONES = observaciones;
            MONTOFEDERAL = montoF;
            MONTOESTATAL = montoE;
            MONTOPRODUCTOR = montoP;
            MONTOOTRO = montoO;
            PROGRAMA = programa;
            TOTAL = total;
        }
    }
}
