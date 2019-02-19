namespace OrdenamientoPesquero.Pantallas_Archivos
{
    partial class Expediente_UE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.Label();
            this.dgvEmbarcacion = new System.Windows.Forms.DataGridView();
            this.Expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Registrados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPescadores = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUnidad = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AbrirPDF = new System.Windows.Forms.PictureBox();
            this.SubirPDF = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmbarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPescadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbrirPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubirPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pescadores";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label30.Location = new System.Drawing.Point(287, 36);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(216, 22);
            this.label30.TabIndex = 202;
            this.label30.Text = "Expediente de la Unidad";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.Location = new System.Drawing.Point(266, 79);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(28, 17);
            this.Nombre.TabIndex = 203;
            this.Nombre.Text = "----";
            // 
            // dgvEmbarcacion
            // 
            this.dgvEmbarcacion.AllowUserToAddRows = false;
            this.dgvEmbarcacion.AllowUserToDeleteRows = false;
            this.dgvEmbarcacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmbarcacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmbarcacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmbarcacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Expediente,
            this.dataGridViewCheckBoxColumn1,
            this.Registrados});
            this.dgvEmbarcacion.GridColor = System.Drawing.Color.White;
            this.dgvEmbarcacion.Location = new System.Drawing.Point(67, 388);
            this.dgvEmbarcacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEmbarcacion.Name = "dgvEmbarcacion";
            this.dgvEmbarcacion.ReadOnly = true;
            this.dgvEmbarcacion.RowHeadersVisible = false;
            this.dgvEmbarcacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEmbarcacion.Size = new System.Drawing.Size(335, 194);
            this.dgvEmbarcacion.TabIndex = 204;
            // 
            // Expediente
            // 
            this.Expediente.Frozen = true;
            this.Expediente.HeaderText = "Archivo";
            this.Expediente.Name = "Expediente";
            this.Expediente.ReadOnly = true;
            this.Expediente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Expediente.Width = 175;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.NullValue = false;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Check";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 75;
            // 
            // Registrados
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Registrados.DefaultCellStyle = dataGridViewCellStyle2;
            this.Registrados.Frozen = true;
            this.Registrados.HeaderText = "Registrados";
            this.Registrados.Name = "Registrados";
            this.Registrados.ReadOnly = true;
            this.Registrados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Registrados.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 22);
            this.label2.TabIndex = 205;
            this.label2.Text = "Embarcaciones";
            // 
            // dgvPescadores
            // 
            this.dgvPescadores.AllowUserToAddRows = false;
            this.dgvPescadores.AllowUserToDeleteRows = false;
            this.dgvPescadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvPescadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPescadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPescadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn2});
            this.dgvPescadores.GridColor = System.Drawing.Color.White;
            this.dgvPescadores.Location = new System.Drawing.Point(480, 388);
            this.dgvPescadores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPescadores.Name = "dgvPescadores";
            this.dgvPescadores.ReadOnly = true;
            this.dgvPescadores.RowHeadersVisible = false;
            this.dgvPescadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPescadores.Size = new System.Drawing.Size(335, 194);
            this.dgvPescadores.TabIndex = 206;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Archivo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 175;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.NullValue = false;
            this.dataGridViewCheckBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCheckBoxColumn2.Frozen = true;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Check";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Registrados";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dgvUnidad
            // 
            this.dgvUnidad.AllowUserToAddRows = false;
            this.dgvUnidad.AllowUserToDeleteRows = false;
            this.dgvUnidad.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUnidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn3});
            this.dgvUnidad.GridColor = System.Drawing.Color.White;
            this.dgvUnidad.Location = new System.Drawing.Point(258, 115);
            this.dgvUnidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvUnidad.Name = "dgvUnidad";
            this.dgvUnidad.ReadOnly = true;
            this.dgvUnidad.RowHeadersVisible = false;
            this.dgvUnidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUnidad.Size = new System.Drawing.Size(280, 149);
            this.dgvUnidad.TabIndex = 207;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AbrirPDF
            // 
            this.AbrirPDF.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.show;
            this.AbrirPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AbrirPDF.Location = new System.Drawing.Point(488, 271);
            this.AbrirPDF.Name = "AbrirPDF";
            this.AbrirPDF.Size = new System.Drawing.Size(50, 50);
            this.AbrirPDF.TabIndex = 211;
            this.AbrirPDF.TabStop = false;
            this.toolTip1.SetToolTip(this.AbrirPDF, "Abrir Archivo");
            this.AbrirPDF.Click += new System.EventHandler(this.AbrirPDF_Click);
            // 
            // SubirPDF
            // 
            this.SubirPDF.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.GuardarArchivo;
            this.SubirPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubirPDF.Location = new System.Drawing.Point(258, 271);
            this.SubirPDF.Name = "SubirPDF";
            this.SubirPDF.Size = new System.Drawing.Size(50, 50);
            this.SubirPDF.TabIndex = 210;
            this.SubirPDF.TabStop = false;
            this.toolTip1.SetToolTip(this.SubirPDF, "Subir Archivo");
            this.SubirPDF.Click += new System.EventHandler(this.SubirPDF_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.Logo_BCS__Escudo_estatal_;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(131, 13);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 60);
            this.pictureBox8.TabIndex = 201;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.logo_Gobierno_H_;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(582, 13);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(200, 60);
            this.pictureBox7.TabIndex = 200;
            this.pictureBox7.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 219;
            this.label3.Text = "Abrir Archivo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 218;
            this.label4.Text = "Subir Archivo";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Archivo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.NullValue = false;
            this.dataGridViewCheckBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCheckBoxColumn3.Frozen = true;
            this.dataGridViewCheckBoxColumn3.HeaderText = "Check";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn3.Width = 75;
            // 
            // Expediente_UE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 586);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AbrirPDF);
            this.Controls.Add(this.SubirPDF);
            this.Controls.Add(this.dgvUnidad);
            this.Controls.Add(this.dgvPescadores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEmbarcacion);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Expediente_UE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expediente_UE";
            this.Load += new System.EventHandler(this.Expediente_UE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmbarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPescadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbrirPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubirPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.DataGridView dgvEmbarcacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPescadores;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expediente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registrados;
        private System.Windows.Forms.DataGridView dgvUnidad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox SubirPDF;
        private System.Windows.Forms.PictureBox AbrirPDF;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
    }
}