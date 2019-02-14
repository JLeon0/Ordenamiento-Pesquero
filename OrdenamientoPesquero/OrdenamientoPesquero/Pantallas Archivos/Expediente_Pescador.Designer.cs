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
            this.dgvArchivos = new System.Windows.Forms.DataGridView();
            this.Expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // AbrirPDF
            // 
            this.AbrirPDF.Location = new System.Drawing.Point(235, 369);
            this.AbrirPDF.Name = "AbrirPDF";
            this.AbrirPDF.Size = new System.Drawing.Size(75, 23);
            this.AbrirPDF.TabIndex = 186;
            this.AbrirPDF.Text = "Ver";
            this.AbrirPDF.UseVisualStyleBackColor = true;
            this.AbrirPDF.Click += new System.EventHandler(this.AbrirPDF_Click);
            // 
            // SubirPDF
            // 
            this.SubirPDF.Location = new System.Drawing.Point(145, 369);
            this.SubirPDF.Name = "SubirPDF";
            this.SubirPDF.Size = new System.Drawing.Size(75, 23);
            this.SubirPDF.TabIndex = 185;
            this.SubirPDF.Text = "Cargar";
            this.SubirPDF.UseVisualStyleBackColor = true;
            this.SubirPDF.Click += new System.EventHandler(this.SubirPDF_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgvArchivos
            // 
            this.dgvArchivos.AllowUserToAddRows = false;
            this.dgvArchivos.AllowUserToDeleteRows = false;
            this.dgvArchivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArchivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Expediente,
            this.Check});
            this.dgvArchivos.Location = new System.Drawing.Point(79, 86);
            this.dgvArchivos.Name = "dgvArchivos";
            this.dgvArchivos.RowHeadersVisible = false;
            this.dgvArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchivos.Size = new System.Drawing.Size(231, 277);
            this.dgvArchivos.TabIndex = 187;
            // 
            // Expediente
            // 
            this.Expediente.Frozen = true;
            this.Expediente.HeaderText = "Archivo";
            this.Expediente.Name = "Expediente";
            this.Expediente.ReadOnly = true;
            this.Expediente.Width = 150;
            // 
            // Check
            // 
            this.Check.Frozen = true;
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            this.Check.Width = 75;
            // 
            // Expediente_Pescador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 430);
            this.Controls.Add(this.dgvArchivos);
            this.Controls.Add(this.AbrirPDF);
            this.Controls.Add(this.SubirPDF);
            this.Name = "Expediente_Pescador";
            this.Text = "Expediente_Pescador";
            this.Load += new System.EventHandler(this.Expediente_Pescador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AbrirPDF;
        private System.Windows.Forms.Button SubirPDF;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvArchivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expediente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
    }
}