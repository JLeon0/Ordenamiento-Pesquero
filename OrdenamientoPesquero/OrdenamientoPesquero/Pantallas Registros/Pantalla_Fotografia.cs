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
        Image FIRMA, HUELLA;
        Pantalla_Registro_Usuario USUARIO;
        Procedimientos proc = new Procedimientos();
        private int selected = 0;
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;

        public Pantalla_Fotografia(string curp, Image Firma, Image Huella, Pantalla_Registro_Usuario usu)
        {
            InitializeComponent();
            CURP = curp;
            USUARIO = usu;
            FIRMA = Firma;
            HUELLA = Huella;
            BuscarDispositivos();
        }

        private void Pantalla_Fotografia_Load(object sender, EventArgs e)
        {

        }

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
            { cbxDispositivos.Items.Add(Dispositivos[0].Name.ToString()); }
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
            Bitmap Imagen; Rectangle rectangle;
            if (selected != 0)
            {
                Imagen = (Bitmap)eventArgs.Frame.Clone();
                rectangle = new Rectangle(200, 0, 300, 350);
            }
            else
            {
                Imagen = (Bitmap)eventArgs.Frame.Clone();
                rectangle = new Rectangle(480, 150, 300, 350);
            }
            Imagen = Imagen.Clone(rectangle, Imagen.PixelFormat);
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
                    selected = cbxDispositivos.SelectedIndex;
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    FuenteDeVideo.Start();
                    Estado.Text = "Ejecutando Dispositivo...";
                    btnIniciar.Text = "Capturar";
                    cbxDispositivos.Enabled = false;
                    groupBox1.Text = DispositivoDeVideo[cbxDispositivos.SelectedIndex].Name.ToString();
                }
                else
                    Estado.Text = "Error: No se encuenta el Dispositivo";

            }
            else
            {
                EspacioCamara.BackgroundImageLayout = ImageLayout.Zoom;
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    Estado.Text = "Dispositivo Detenido...";
                    btnIniciar.Text = "Iniciar";
                    cbxDispositivos.Enabled = true;

                }
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            USUARIO.ImagenBackGround(EspacioCamara.BackgroundImage);
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
