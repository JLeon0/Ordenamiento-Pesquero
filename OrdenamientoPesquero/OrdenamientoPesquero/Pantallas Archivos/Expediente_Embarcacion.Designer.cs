namespace OrdenamientoPesquero.Pantallas_Archivos
{
    partial class Expediente_Embarcacion
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Nombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.dgvArchivos = new System.Windows.Forms.DataGridView();
            this.Expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.AbrirPDF = new System.Windows.Forms.PictureBox();
            this.SubirPDF = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.EliminarPDF = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbrirPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubirPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EliminarPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(125, 98);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(24, 16);
            this.Nombre.TabIndex = 201;
            this.Nombre.Text = "----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 200;
            this.label1.Text = "Nombre:";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label30.Location = new System.Drawing.Point(98, 35);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(222, 22);
            this.label30.TabIndex = 199;
            this.label30.Text = "Expediente Embarcacion";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.Logo_BCS__Escudo_estatal_;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(24, 20);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 60);
            this.pictureBox8.TabIndex = 198;
            this.pictureBox8.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.logo_Gobierno_H_;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.Location = new System.Drawing.Point(326, 20);
            this.Logo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(200, 60);
            this.Logo.TabIndex = 197;
            this.Logo.TabStop = false;
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
            this.dgvArchivos.Location = new System.Drawing.Point(128, 137);
            this.dgvArchivos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvArchivos.MultiSelect = false;
            this.dgvArchivos.Name = "dgvArchivos";
            this.dgvArchivos.ReadOnly = true;
            this.dgvArchivos.RowHeadersVisible = false;
            this.dgvArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvArchivos.Size = new System.Drawing.Size(232, 197);
            this.dgvArchivos.TabIndex = 196;
            // 
            // Expediente
            // 
            this.Expediente.Frozen = true;
            this.Expediente.HeaderText = "Archivo";
            this.Expediente.Name = "Expediente";
            this.Expediente.ReadOnly = true;
            this.Expediente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Expediente.Width = 150;
            // 
            // Check
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.NullValue = false;
            this.Check.DefaultCellStyle = dataGridViewCellStyle1;
            this.Check.Frozen = true;
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Check.Width = 75;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AbrirPDF
            // 
            this.AbrirPDF.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.show;
            this.AbrirPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AbrirPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AbrirPDF.Location = new System.Drawing.Point(310, 364);
            this.AbrirPDF.Name = "AbrirPDF";
            this.AbrirPDF.Size = new System.Drawing.Size(50, 50);
            this.AbrirPDF.TabIndex = 213;
            this.AbrirPDF.TabStop = false;
            this.toolTip1.SetToolTip(this.AbrirPDF, "Abrir Archivo");
            this.AbrirPDF.Click += new System.EventHandler(this.AbrirPDF_Click);
            // 
            // SubirPDF
            // 
            this.SubirPDF.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.GuardarArchivo;
            this.SubirPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubirPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SubirPDF.Location = new System.Drawing.Point(128, 364);
            this.SubirPDF.Name = "SubirPDF";
            this.SubirPDF.Size = new System.Drawing.Size(50, 50);
            this.SubirPDF.TabIndex = 212;
            this.SubirPDF.TabStop = false;
            this.toolTip1.SetToolTip(this.SubirPDF, "Subir Archivo");
            this.SubirPDF.Visible = false;
            this.SubirPDF.Click += new System.EventHandler(this.SubirPDF_Click);
            // 
            // EliminarPDF
            // 
            this.EliminarPDF.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.borrar;
            this.EliminarPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminarPDF.Location = new System.Drawing.Point(457, 364);
            this.EliminarPDF.Name = "EliminarPDF";
            this.EliminarPDF.Size = new System.Drawing.Size(50, 50);
            this.EliminarPDF.TabIndex = 220;
            this.EliminarPDF.TabStop = false;
            this.toolTip1.SetToolTip(this.EliminarPDF, "Eliminar Archivo");
            this.EliminarPDF.Click += new System.EventHandler(this.EliminarPDF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 219;
            this.label3.Text = "Abrir Archivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 218;
            this.label2.Text = "Subir Archivo";
            this.label2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 221;
            this.label4.Text = "Eliminar Archivo";
            // 
            // Expediente_Embarcacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 446);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EliminarPDF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AbrirPDF);
            this.Controls.Add(this.SubirPDF);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.dgvArchivos);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Expediente_Embarcacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expediente_Embarcacion";
            this.Load += new System.EventHandler(this.Expediente_Embarcacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbrirPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubirPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EliminarPDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.DataGridView dgvArchivos;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expediente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.PictureBox AbrirPDF;
        private System.Windows.Forms.PictureBox SubirPDF;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox EliminarPDF;
    }
}