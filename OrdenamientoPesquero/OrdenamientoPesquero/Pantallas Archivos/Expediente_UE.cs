using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero.Pantallas_Archivos
{
    public partial class Expediente_UE : Form
    {
        Procedimientos proc = new Procedimientos();
        string RNPA = "";


        public Expediente_UE(string rnpa)
        {
            InitializeComponent();
            RNPA = rnpa;
        }

        private void Expediente_UE_Load(object sender, EventArgs e)
        {
            CargarExpedientePescador();
        }

        private void CargarExpedientePescador()
        {
            DataTable expediente = proc.ObtenerExpedientePescadorXUnidad(RNPA);
            DataTable pescadores = proc.PescadoresXUnidad(RNPA);
            int acta = 0, aine = 0, acurp = 0, acompdom = 0;
            foreach (DataRow fila in expediente.Rows)
            {
                if (fila["ACTANAC"].ToString() != "") { acta++; }
                if (fila["ACURP"].ToString() != "") { acurp++; }
                if (fila["AINE"].ToString() != "") { aine++; }
                if (fila["ACOMPDOM"].ToString() != "") { acompdom++; }
            }
            ActasPesc.Text = acta + "/" + pescadores.Rows.Count;
            if (acta == pescadores.Rows.Count) { check.SetItemChecked(0, true); } else { check.SetItemChecked(0, false); }
            CurpsPesc.Text = acurp + "/" + pescadores.Rows.Count;
            if (acurp == pescadores.Rows.Count) { check.SetItemChecked(1, true); } else { check.SetItemChecked(1, false); }
            INEPesc.Text = aine + "/" + pescadores.Rows.Count;
            if (aine == pescadores.Rows.Count) { check.SetItemChecked(2, true); } else { check.SetItemChecked(2, false); }
            ComprPesc.Text = acompdom + "/" + pescadores.Rows.Count;
            if (acompdom == pescadores.Rows.Count) { check.SetItemChecked(0, true); } else { check.SetItemChecked(3, false); }

        }
    }
}
