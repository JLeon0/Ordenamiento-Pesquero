namespace OrdenamientoPesquero
{
    partial class Pantalla_Solicitudes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pantalla_Solicitudes));
            this.NombrePesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.estatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.responsable = new System.Windows.Forms.ComboBox();
            this.monto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.prioridad = new System.Windows.Forms.ComboBox();
            this.concepto = new System.Windows.Forms.TextBox();
            this.observaciones = new System.Windows.Forms.TextBox();
            this.Lista = new System.Windows.Forms.ListBox();
            this.txt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.director = new System.Windows.Forms.ComboBox();
            this.Entregar = new System.Windows.Forms.PictureBox();
            this.Actualizar = new System.Windows.Forms.PictureBox();
            this.Registrar = new System.Windows.Forms.PictureBox();
            this.Entrega = new System.Windows.Forms.Label();
            this.Apoyo = new System.Windows.Forms.GroupBox();
            this.programa = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.TextBox();
            this.montoP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.montoF = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.montoE = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.Eliminar = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.FolioMayor = new System.Windows.Forms.Label();
            this.otro = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.solicitud = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Entregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Actualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Registrar)).BeginInit();
            this.Apoyo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eliminar)).BeginInit();
            this.solicitud.SuspendLayout();
            this.SuspendLayout();
            // 
            // NombrePesc
            // 
            this.NombrePesc.AutoSize = true;
            this.NombrePesc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombrePesc.Location = new System.Drawing.Point(291, 28);
            this.NombrePesc.Name = "NombrePesc";
            this.NombrePesc.Size = new System.Drawing.Size(89, 24);
            this.NombrePesc.TabIndex = 0;
            this.NombrePesc.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio";
            // 
            // folio
            // 
            this.folio.Location = new System.Drawing.Point(295, 125);
            this.folio.MaxLength = 11;
            this.folio.Name = "folio";
            this.folio.Size = new System.Drawing.Size(102, 22);
            this.folio.TabIndex = 1;
            this.folio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prioridad";
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(295, 189);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(102, 22);
            this.fecha.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Concepto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Estatus";
            // 
            // estatus
            // 
            this.estatus.FormattingEnabled = true;
            this.estatus.Items.AddRange(new object[] {
            "Pendiente",
            "+Con techo presupuestal",
            "+Sin techo presupuestal",
            "Negativa"});
            this.estatus.Location = new System.Drawing.Point(67, 59);
            this.estatus.Name = "estatus";
            this.estatus.Size = new System.Drawing.Size(141, 24);
            this.estatus.TabIndex = 4;
            this.estatus.Text = "Pendiente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Monto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Responsable";
            // 
            // responsable
            // 
            this.responsable.FormattingEnabled = true;
            this.responsable.Items.AddRange(new object[] {
            "Hernan Rafael Flores Cota",
            "Dacia Meza Villavicencio",
            "Rosa Maria Castro Lozano",
            "Cristina Gonzalez Rubio SanVicente",
            "Claudia Cota Alvarez",
            "Daniel Amador Manriquez",
            "Patricia Serrano",
            "Karla Murillo"});
            this.responsable.Location = new System.Drawing.Point(327, 15);
            this.responsable.Name = "responsable";
            this.responsable.Size = new System.Drawing.Size(204, 24);
            this.responsable.TabIndex = 6;
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(67, 100);
            this.monto.MaxLength = 9;
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(102, 22);
            this.monto.TabIndex = 5;
            this.monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Observaciones";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(911, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 114;
            this.label9.Text = "Actualizar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(843, 416);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 115;
            this.label10.Text = "Registrar";
            // 
            // prioridad
            // 
            this.prioridad.FormattingEnabled = true;
            this.prioridad.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.prioridad.Location = new System.Drawing.Point(67, 15);
            this.prioridad.Name = "prioridad";
            this.prioridad.Size = new System.Drawing.Size(45, 24);
            this.prioridad.TabIndex = 3;
            // 
            // concepto
            // 
            this.concepto.Location = new System.Drawing.Point(224, 272);
            this.concepto.Multiline = true;
            this.concepto.Name = "concepto";
            this.concepto.Size = new System.Drawing.Size(399, 84);
            this.concepto.TabIndex = 8;
            // 
            // observaciones
            // 
            this.observaciones.Location = new System.Drawing.Point(637, 272);
            this.observaciones.Multiline = true;
            this.observaciones.Name = "observaciones";
            this.observaciones.Size = new System.Drawing.Size(399, 84);
            this.observaciones.TabIndex = 9;
            // 
            // Lista
            // 
            this.Lista.FormattingEnabled = true;
            this.Lista.ItemHeight = 16;
            this.Lista.Location = new System.Drawing.Point(11, 144);
            this.Lista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(207, 164);
            this.Lista.TabIndex = 170;
            this.Lista.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListaSolicitudes_MouseDoubleClick);
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(69, 116);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(92, 16);
            this.txt.TabIndex = 169;
            this.txt.Text = "SOLICITUDES";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Director";
            // 
            // director
            // 
            this.director.FormattingEnabled = true;
            this.director.Items.AddRange(new object[] {
            "David Navarro Nuñez",
            "Enrique Duarte Guluarte",
            "Carlos Gonzalez Gonzalez",
            "Fernando García Romero"});
            this.director.Location = new System.Drawing.Point(327, 56);
            this.director.Name = "director";
            this.director.Size = new System.Drawing.Size(204, 24);
            this.director.TabIndex = 7;
            // 
            // Entregar
            // 
            this.Entregar.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.Entregar;
            this.Entregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Entregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Entregar.Location = new System.Drawing.Point(224, 362);
            this.Entregar.Name = "Entregar";
            this.Entregar.Size = new System.Drawing.Size(50, 50);
            this.Entregar.TabIndex = 171;
            this.Entregar.TabStop = false;
            this.Entregar.Click += new System.EventHandler(this.Entregar_Click);
            // 
            // Actualizar
            // 
            this.Actualizar.BackColor = System.Drawing.Color.Transparent;
            this.Actualizar.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.ActualizarArchivo;
            this.Actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Actualizar.Location = new System.Drawing.Point(917, 362);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(50, 50);
            this.Actualizar.TabIndex = 113;
            this.Actualizar.TabStop = false;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // Registrar
            // 
            this.Registrar.BackColor = System.Drawing.Color.Transparent;
            this.Registrar.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.GuardarArchivo;
            this.Registrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Registrar.Location = new System.Drawing.Point(842, 362);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(50, 50);
            this.Registrar.TabIndex = 112;
            this.Registrar.TabStop = false;
            this.Registrar.Click += new System.EventHandler(this.Registrar_Click);
            // 
            // Entrega
            // 
            this.Entrega.AutoSize = true;
            this.Entrega.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Entrega.Location = new System.Drawing.Point(223, 415);
            this.Entrega.Name = "Entrega";
            this.Entrega.Size = new System.Drawing.Size(48, 14);
            this.Entrega.TabIndex = 115;
            this.Entrega.Text = "Entregar";
            // 
            // Apoyo
            // 
            this.Apoyo.Controls.Add(this.otro);
            this.Apoyo.Controls.Add(this.label18);
            this.Apoyo.Controls.Add(this.programa);
            this.Apoyo.Controls.Add(this.label17);
            this.Apoyo.Controls.Add(this.Total);
            this.Apoyo.Controls.Add(this.montoP);
            this.Apoyo.Controls.Add(this.label12);
            this.Apoyo.Controls.Add(this.label16);
            this.Apoyo.Controls.Add(this.montoF);
            this.Apoyo.Controls.Add(this.label15);
            this.Apoyo.Controls.Add(this.montoE);
            this.Apoyo.Controls.Add(this.label14);
            this.Apoyo.Enabled = false;
            this.Apoyo.Location = new System.Drawing.Point(452, 99);
            this.Apoyo.Name = "Apoyo";
            this.Apoyo.Size = new System.Drawing.Size(584, 151);
            this.Apoyo.TabIndex = 3;
            this.Apoyo.TabStop = false;
            this.Apoyo.Text = "Apoyo";
            this.Apoyo.Visible = false;
            // 
            // programa
            // 
            this.programa.Location = new System.Drawing.Point(307, 24);
            this.programa.Name = "programa";
            this.programa.Size = new System.Drawing.Size(198, 22);
            this.programa.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(237, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 173;
            this.label17.Text = "Programa";
            // 
            // Total
            // 
            this.Total.Location = new System.Drawing.Point(109, 127);
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Total.Size = new System.Drawing.Size(68, 22);
            this.Total.TabIndex = 174;
            this.Total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // montoP
            // 
            this.montoP.Location = new System.Drawing.Point(109, 71);
            this.montoP.MaxLength = 9;
            this.montoP.Name = "montoP";
            this.montoP.Size = new System.Drawing.Size(68, 22);
            this.montoP.TabIndex = 5;
            this.montoP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.montoP.TextChanged += new System.EventHandler(this.montoE_TextChanged);
            this.montoP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 173;
            this.label12.Text = "Monto Total";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 16);
            this.label16.TabIndex = 173;
            this.label16.Text = "Monto Productor";
            // 
            // montoF
            // 
            this.montoF.Location = new System.Drawing.Point(109, 43);
            this.montoF.MaxLength = 9;
            this.montoF.Name = "montoF";
            this.montoF.Size = new System.Drawing.Size(68, 22);
            this.montoF.TabIndex = 4;
            this.montoF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.montoF.TextChanged += new System.EventHandler(this.montoE_TextChanged);
            this.montoF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 16);
            this.label15.TabIndex = 173;
            this.label15.Text = "Monto Federal";
            // 
            // montoE
            // 
            this.montoE.Location = new System.Drawing.Point(109, 15);
            this.montoE.MaxLength = 9;
            this.montoE.Name = "montoE";
            this.montoE.Size = new System.Drawing.Size(68, 22);
            this.montoE.TabIndex = 3;
            this.montoE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.montoE.TextChanged += new System.EventHandler(this.montoE_TextChanged);
            this.montoE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 16);
            this.label14.TabIndex = 173;
            this.label14.Text = "Monto Estatal";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.Logo_BCS__Escudo_estatal_;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(221, 13);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 60);
            this.pictureBox8.TabIndex = 200;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.logo_Gobierno_H_;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(768, 10);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(200, 60);
            this.pictureBox7.TabIndex = 199;
            this.pictureBox7.TabStop = false;
            // 
            // Eliminar
            // 
            this.Eliminar.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.borrar;
            this.Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Eliminar.Location = new System.Drawing.Point(986, 362);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(50, 50);
            this.Eliminar.TabIndex = 201;
            this.Eliminar.TabStop = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(973, 415);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 14);
            this.label13.TabIndex = 202;
            this.label13.Text = "Eliminar registro";
            // 
            // FolioMayor
            // 
            this.FolioMayor.AutoSize = true;
            this.FolioMayor.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolioMayor.ForeColor = System.Drawing.Color.DimGray;
            this.FolioMayor.Location = new System.Drawing.Point(292, 150);
            this.FolioMayor.Name = "FolioMayor";
            this.FolioMayor.Size = new System.Drawing.Size(67, 16);
            this.FolioMayor.TabIndex = 203;
            this.FolioMayor.Text = "Folio Mayor:";
            // 
            // otro
            // 
            this.otro.Location = new System.Drawing.Point(109, 98);
            this.otro.MaxLength = 9;
            this.otro.Name = "otro";
            this.otro.Size = new System.Drawing.Size(68, 22);
            this.otro.TabIndex = 6;
            this.otro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.otro.TextChanged += new System.EventHandler(this.montoE_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 16);
            this.label18.TabIndex = 176;
            this.label18.Text = "Otro";
            // 
            // solicitud
            // 
            this.solicitud.Controls.Add(this.label3);
            this.solicitud.Controls.Add(this.label5);
            this.solicitud.Controls.Add(this.label6);
            this.solicitud.Controls.Add(this.label7);
            this.solicitud.Controls.Add(this.label11);
            this.solicitud.Controls.Add(this.monto);
            this.solicitud.Controls.Add(this.estatus);
            this.solicitud.Controls.Add(this.responsable);
            this.solicitud.Controls.Add(this.director);
            this.solicitud.Controls.Add(this.prioridad);
            this.solicitud.Location = new System.Drawing.Point(446, 98);
            this.solicitud.Name = "solicitud";
            this.solicitud.Size = new System.Drawing.Size(584, 152);
            this.solicitud.TabIndex = 3;
            this.solicitud.TabStop = false;
            this.solicitud.Text = "Solicitudes";
            // 
            // Pantalla_Solicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 451);
            this.Controls.Add(this.solicitud);
            this.Controls.Add(this.FolioMayor);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.Apoyo);
            this.Controls.Add(this.Entregar);
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.observaciones);
            this.Controls.Add(this.concepto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Entrega);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.Registrar);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.folio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombrePesc);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Pantalla_Solicitudes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla_Solicitudes";
            this.Load += new System.EventHandler(this.Pantalla_Solicitudes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Entregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Actualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Registrar)).EndInit();
            this.Apoyo.ResumeLayout(false);
            this.Apoyo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eliminar)).EndInit();
            this.solicitud.ResumeLayout(false);
            this.solicitud.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NombrePesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox estatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox responsable;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox Actualizar;
        private System.Windows.Forms.PictureBox Registrar;
        private System.Windows.Forms.ComboBox prioridad;
        private System.Windows.Forms.TextBox concepto;
        private System.Windows.Forms.TextBox observaciones;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox director;
        private System.Windows.Forms.PictureBox Entregar;
        private System.Windows.Forms.Label Entrega;
        private System.Windows.Forms.GroupBox Apoyo;
        private System.Windows.Forms.TextBox programa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox montoP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox montoF;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox montoE;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox Eliminar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label FolioMayor;
        private System.Windows.Forms.TextBox otro;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox solicitud;
    }
}