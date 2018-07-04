using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using Logica;

namespace Logica
{
    public class Validaciones
    {
        DataTable dt;
        Procedimientos proc = new Procedimientos();
        public void ajustarResolucion(System.Windows.Forms.Form formulario)
        {
            String ancho = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width.ToString();//Obtengo el ancho de la pantalla
            String alto = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height.ToString();//Obtengo el alto de la pantalla
            String tamano = ancho + "x" + alto;//Concateno para utilizarlo en el switch
            switch (tamano)
            {
                case "800x600":
                    cambiarResolucion(formulario, 110F, 110F);//Hago el ajuste con esta función
                    break;
                case "1024x600":
                    cambiarResolucion(formulario, 96F, 110F);
                    break;
                default:
                    cambiarResolucion(formulario, 96F, 96F);
                    break;
            }
        }

        private static void cambiarResolucion(System.Windows.Forms.Form formulario, float ancho, float alto)
        {
            formulario.AutoScaleDimensions = new System.Drawing.SizeF(ancho, alto); //Ajusto la resolución
            formulario.PerformAutoScale(); //Escalo el control contenedor y sus elementos secundarios.
        }

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
            return true;
        }
        public bool validarrfc(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w\0-9]{3})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validarrfcPes(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w\0-9]{3})$"))
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

        public String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }
            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        public void Exito(int ok)
        {
            if (ok >= 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Registrado exitosamente"); /* 1 segundo = 1000 */
            }
            else if (ok == -10)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("No se pueden registrar más de 1 capitan en una misma embarcación"); /* 1 segundo = 1000 */
            }
            else if(ok == -11)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error al registrar la unidad a una Federación"); /* 1 segundo = 1000 */
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error durante el registro"); /* 1 segundo = 1000 */
            }
        }
        public void CloseIt()
        {
            System.Threading.Thread.Sleep(2000);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        public bool existe(string rnpa)
        {
            dt = proc.Obtener_unidades(rnpa);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
