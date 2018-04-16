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
        public bool validarrfc(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime Fechanac(string curp)
        {
            string an = curp[4].ToString() + curp[5].ToString();
            int año = 0, mes = 0, dia = 0;
            año = Convert.ToInt32(an) + 1900;
            if (año < 1930)
            {
                año += 100;
            }
            an = curp[6].ToString() + curp[7].ToString();
            mes = Convert.ToInt32(an);
            an = curp[8].ToString() + curp[9].ToString();
            dia = Convert.ToInt32(an);
            DateTime dti = new DateTime(año, mes, dia);
            return dti;
        }

        public void Exito(int ok)
        {
            if (ok >= 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Registrado exitosamente"); /* 1 segundo = 1000 */
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error durante el registro"); /* 1 segundo = 1000 */
            }
        }
        private void CloseIt()
        {
            System.Threading.Thread.Sleep(2000);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }
    }
}
