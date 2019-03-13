namespace OrdenamientoPesquero.Pantallas_Menu
{
    partial class Menu1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Solicitudes = new System.Windows.Forms.Button();
            this.Ordenamiento = new System.Windows.Forms.Button();
            this.CerrarPanel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Solicitudes
            // 
            this.Solicitudes.BackColor = System.Drawing.Color.Transparent;
            this.Solicitudes.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.pedir;
            this.Solicitudes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Solicitudes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Solicitudes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Solicitudes.FlatAppearance.BorderSize = 0;
            this.Solicitudes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Solicitudes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Solicitudes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Solicitudes.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solicitudes.Location = new System.Drawing.Point(44, 121);
            this.Solicitudes.Name = "Solicitudes";
            this.Solicitudes.Size = new System.Drawing.Size(280, 240);
            this.Solicitudes.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Solicitudes, "Apoyos Y Solicitudes");
            this.Solicitudes.UseVisualStyleBackColor = false;
            this.Solicitudes.Click += new System.EventHandler(this.Solicitudes_Click);
            // 
            // Ordenamiento
            // 
            this.Ordenamiento.BackColor = System.Drawing.Color.Transparent;
            this.Ordenamiento.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.logo_Gobierno_V_;
            this.Ordenamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ordenamiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ordenamiento.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Ordenamiento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Ordenamiento.FlatAppearance.BorderSize = 0;
            this.Ordenamiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.Ordenamiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Ordenamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ordenamiento.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ordenamiento.Location = new System.Drawing.Point(557, 121);
            this.Ordenamiento.Name = "Ordenamiento";
            this.Ordenamiento.Size = new System.Drawing.Size(317, 240);
            this.Ordenamiento.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Ordenamiento, "Ordenamiento Pesquero");
            this.Ordenamiento.UseVisualStyleBackColor = false;
            this.Ordenamiento.Click += new System.EventHandler(this.Ordenamiento_Click);
            // 
            // CerrarPanel
            // 
            this.CerrarPanel.BackColor = System.Drawing.Color.Transparent;
            this.CerrarPanel.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.Equis;
            this.CerrarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CerrarPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CerrarPanel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.CerrarPanel.FlatAppearance.BorderSize = 0;
            this.CerrarPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.CerrarPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.CerrarPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CerrarPanel.Location = new System.Drawing.Point(857, 8);
            this.CerrarPanel.Name = "CerrarPanel";
            this.CerrarPanel.Size = new System.Drawing.Size(30, 30);
            this.CerrarPanel.TabIndex = 189;
            this.toolTip1.SetToolTip(this.CerrarPanel, "Salir");
            this.CerrarPanel.UseVisualStyleBackColor = false;
            this.CerrarPanel.Click += new System.EventHandler(this.CerrarPanel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.CerrarPanel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Solicitudes);
            this.panel1.Controls.Add(this.Ordenamiento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 451);
            this.panel1.TabIndex = 191;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.SEPADA;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(44, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(525, 88);
            this.pictureBox1.TabIndex = 188;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Solicitudes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ordenamiento Pesquero";
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(903, 459);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Menu1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu1";
            this.Load += new System.EventHandler(this.Menu1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Solicitudes;
        private System.Windows.Forms.Button Ordenamiento;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CerrarPanel;
    }
}