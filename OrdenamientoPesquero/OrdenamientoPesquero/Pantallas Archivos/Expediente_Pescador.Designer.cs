namespace OrdenamientoPesquero.Pantallas_Archivos
{
    partial class Expediente_Pescador
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
            this.AbrirPDF = new System.Windows.Forms.Button();
            this.SubirPDF = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // AbrirPDF
            // 
            this.AbrirPDF.Location = new System.Drawing.Point(12, 49);
            this.AbrirPDF.Name = "AbrirPDF";
            this.AbrirPDF.Size = new System.Drawing.Size(75, 23);
            this.AbrirPDF.TabIndex = 186;
            this.AbrirPDF.Text = "Abrir PDF";
            this.AbrirPDF.UseVisualStyleBackColor = true;
            this.AbrirPDF.Click += new System.EventHandler(this.AbrirPDF_Click);
            // 
            // SubirPDF
            // 
            this.SubirPDF.Location = new System.Drawing.Point(12, 20);
            this.SubirPDF.Name = "SubirPDF";
            this.SubirPDF.Size = new System.Drawing.Size(75, 23);
            this.SubirPDF.TabIndex = 185;
            this.SubirPDF.Text = "PDF";
            this.SubirPDF.UseVisualStyleBackColor = true;
            this.SubirPDF.Click += new System.EventHandler(this.SubirPDF_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Expediente_Pescador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AbrirPDF);
            this.Controls.Add(this.SubirPDF);
            this.Name = "Expediente_Pescador";
            this.Text = "Expediente_Pescador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AbrirPDF;
        private System.Windows.Forms.Button SubirPDF;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}