using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Logica
{
    public class Validaciones
    {
        public bool validarcurp(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w]{6})([0-9A-Z]{1})([0-9]{1})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validarCorreo(string correo)
        {
            if (Regex.IsMatch(correo, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaralgo(string[,] arre)
        {
            bool estabien = true;
            string msg = "Los siguientes campos estan mal o incompletos: \n";
            for (int i = 0; i < arre.Length / 2; i++)
            {
                if (arre[i, 0] == "0")
                {
                    estabien = false;
                    msg += "----" + arre[i, 1] + "\n";
                }
            }
            if (!estabien)
            {
                MessageBox.Show(msg, "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return estabien;
        }
    }
}
