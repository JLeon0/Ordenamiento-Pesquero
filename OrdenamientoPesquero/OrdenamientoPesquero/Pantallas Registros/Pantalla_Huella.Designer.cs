namespace OrdenamientoPesquero.Pantallas_Registros
{
    partial class Pantalla_Huella
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
            this.Salir = new System.Windows.Forms.Button();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            this.lblPlaceFinger = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // Salir
            // 
            this.Salir.Location = new System.Drawing.Point(156, 221);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(75, 23);
            this.Salir.TabIndex = 13;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.Location = new System.Drawing.Point(12, 12);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(219, 184);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFingerprint.TabIndex = 7;
            this.pbFingerprint.TabStop = false;
            // 
            // lblPlaceFinger
            // 
            this.lblPlaceFinger.Location = new System.Drawing.Point(12, 199);
            this.lblPlaceFinger.Name = "lblPlaceFinger";
            this.lblPlaceFinger.Size = new System.Drawing.Size(187, 19);
            this.lblPlaceFinger.TabIndex = 14;
            this.lblPlaceFinger.Text = "Coloque su dedo sobre el lector";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 221);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Pantalla_Huella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 248);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblPlaceFinger);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.pbFingerprint);
            this.Name = "Pantalla_Huella";
            this.Text = "Pantalla_Huella";
            this.Load += new System.EventHandler(this.Pantalla_Huella_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbFingerprint;
        private System.Windows.Forms.Button Salir;
        internal System.Windows.Forms.Label lblPlaceFinger;
        private System.Windows.Forms.Button btnGuardar;
    }
}