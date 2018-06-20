using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Logica;

namespace OrdenamientoPesquero.Pantallas_Registros
{
    public partial class Pantalla_Fotografia : Form
    {
        string CURP = "";
        Procedimientos proc = new Procedimientos();
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;

        public Pantalla_Fotografia(string curp)
        {
            InitializeComponent();
            CURP = curp;
            BuscarDispositivos();
        }

        private void Pantalla_Fotografia_Load(object sender, EventArgs e)
        {

        }

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++) ;

            cbxDispositivos.Items.Add(Dispositivos[0].Name.ToString());
            cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();

        }

        public void BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
            {
                ExisteDispositivo = false;
            }

            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);

            }
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }

        }

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            EspacioCamara.BackgroundImage = Imagen;
            EspacioCamara.BackgroundImageLayout = ImageLayout.Zoom;

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text == "Iniciar")

            {
                if (ExisteDispositivo)
                {

                    FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    FuenteDeVideo.Start();
                    Estado.Text = "Ejecutando Dispositivo...";
                    btnIniciar.Text = "Detener";
                    cbxDispositivos.Enabled = false;
                    groupBox1.Text = DispositivoDeVideo[cbxDispositivos.SelectedIndex].Name.ToString();
                }
                else
                    Estado.Text = "Error: No se encuenta el Dispositivo";

            }
            else
            {
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    Estado.Text = "Dispositivo Detenido...";
                    btnIniciar.Text = "Iniciar";
                    cbxDispositivos.Enabled = true;

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnIniciar.Text == "Capturar")
                btnIniciar_Click(sender, e);
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            EspacioCamara.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(ms);
            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(131, 182, null, IntPtr.Zero);
            System.IO.MemoryStream myResult = new System.IO.MemoryStream();
            newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Gif);

            int exito = proc.InsertarImagen(CURP, myResult.GetBuffer());
            if (exito > 0)
            {
                MessageBox.Show("Imagen Insertada correctamente");
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if(btnIniciar.Text == "Iniciar")
            {
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Desea salir sin capturar una imagen", "Saliendo", MessageBoxButtons.YesNo);
                if(result== DialogResult.Yes)
                {
                    if (FuenteDeVideo.IsRunning)
                    {
                        TerminarFuenteDeVideo();
                        Estado.Text = "Dispositivo Detenido...";
                        btnIniciar.Text = "Iniciar";
                        cbxDispositivos.Enabled = true;
                    }
                    this.Close();
                }
            }
        }
    }
}
