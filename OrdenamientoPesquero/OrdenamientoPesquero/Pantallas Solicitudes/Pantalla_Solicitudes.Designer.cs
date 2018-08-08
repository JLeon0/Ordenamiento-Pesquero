namespace OrdenamientoPesquero.Pantallas_Registros
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
            this.NombrePesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.concepto = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.estatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.responsable = new System.Windows.Forms.ComboBox();
            this.monto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.observaciones = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Actualizar = new System.Windows.Forms.PictureBox();
            this.Registrar = new System.Windows.Forms.PictureBox();
            this.prioridad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Actualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Registrar)).BeginInit();
            this.SuspendLayout();
            // 
            // NombrePesc
            // 
            this.NombrePesc.AutoSize = true;
            this.NombrePesc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombrePesc.Location = new System.Drawing.Point(18, 24);
            this.NombrePesc.Name = "NombrePesc";
            this.NombrePesc.Size = new System.Drawing.Size(89, 24);
            this.NombrePesc.TabIndex = 0;
            this.NombrePesc.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio";
            // 
            // folio
            // 
            this.folio.Location = new System.Drawing.Point(88, 75);
            this.folio.Name = "folio";
            this.folio.Size = new System.Drawing.Size(102, 22);
            this.folio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prioridad";
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(88, 104);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(102, 22);
            this.fecha.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Concepto";
            // 
            // concepto
            // 
            this.concepto.FormattingEnabled = true;
            this.concepto.ItemHeight = 16;
            this.concepto.Location = new System.Drawing.Point(22, 188);
            this.concepto.Name = "concepto";
            this.concepto.Size = new System.Drawing.Size(399, 84);
            this.concepto.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Estatus";
            // 
            // estatus
            // 
            this.estatus.FormattingEnabled = true;
            this.estatus.Items.AddRange(new object[] {
            "Aprobado",
            "En espera...",
            "Pendiente",
            "Rechazado"});
            this.estatus.Location = new System.Drawing.Point(530, 73);
            this.estatus.Name = "estatus";
            this.estatus.Size = new System.Drawing.Size(121, 24);
            this.estatus.TabIndex = 5;
            this.estatus.Text = "Pendiente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Monto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(434, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Responsable";
            // 
            // responsable
            // 
            this.responsable.FormattingEnabled = true;
            this.responsable.Location = new System.Drawing.Point(530, 134);
            this.responsable.Name = "responsable";
            this.responsable.Size = new System.Drawing.Size(121, 24);
            this.responsable.TabIndex = 7;
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(530, 103);
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(102, 22);
            this.monto.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(434, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Observaciones";
            // 
            // observaciones
            // 
            this.observaciones.FormattingEnabled = true;
            this.observaciones.ItemHeight = 16;
            this.observaciones.Location = new System.Drawing.Point(437, 188);
            this.observaciones.Name = "observaciones";
            this.observaciones.Size = new System.Drawing.Size(399, 84);
            this.observaciones.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(784, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 114;
            this.label9.Text = "Actualizar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(710, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 115;
            this.label10.Text = "Registrar";
            // 
            // Actualizar
            // 
            this.Actualizar.BackColor = System.Drawing.Color.Transparent;
            this.Actualizar.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.ActualizarArchivo;
            this.Actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Actualizar.Location = new System.Drawing.Point(784, 278);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(50, 50);
            this.Actualizar.TabIndex = 113;
            this.Actualizar.TabStop = false;
            // 
            // Registrar
            // 
            this.Registrar.BackColor = System.Drawing.Color.Transparent;
            this.Registrar.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.GuardarArchivo;
            this.Registrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Registrar.Location = new System.Drawing.Point(709, 278);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(50, 50);
            this.Registrar.TabIndex = 112;
            this.Registrar.TabStop = false;
            this.Registrar.Click += new System.EventHandler(this.Registrar_Click);
            // 
            // prioridad
            // 
            this.prioridad.FormattingEnabled = true;
            this.prioridad.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.prioridad.Location = new System.Drawing.Point(88, 132);
            this.prioridad.Name = "prioridad";
            this.prioridad.Size = new System.Drawing.Size(102, 24);
            this.prioridad.TabIndex = 3;
            // 
            // Pantalla_Solicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 367);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.Registrar);
            this.Controls.Add(this.prioridad);
            this.Controls.Add(this.responsable);
            this.Controls.Add(this.estatus);
            this.Controls.Add(this.observaciones);
            this.Controls.Add(this.concepto);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.monto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.folio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombrePesc);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Pantalla_Solicitudes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla_Solicitudes";
            this.Load += new System.EventHandler(this.Pantalla_Solicitudes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Actualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Registrar)).EndInit();
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
        private System.Windows.Forms.ListBox concepto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox estatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox responsable;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox observaciones;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox Actualizar;
        private System.Windows.Forms.PictureBox Registrar;
        private System.Windows.Forms.ComboBox prioridad;
    }
}