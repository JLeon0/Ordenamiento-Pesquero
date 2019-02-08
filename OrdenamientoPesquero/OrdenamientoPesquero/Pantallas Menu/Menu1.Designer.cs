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
            this.Ordenamiento = new System.Windows.Forms.Button();
            this.Solicitudes = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.CerrarPanel = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CerrarPanel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ordenamiento
            // 
            this.Ordenamiento.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.logo_Gobierno_V_;
            this.Ordenamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ordenamiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ordenamiento.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Ordenamiento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Ordenamiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Ordenamiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.Ordenamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ordenamiento.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ordenamiento.Location = new System.Drawing.Point(564, 82);
            this.Ordenamiento.Name = "Ordenamiento";
            this.Ordenamiento.Size = new System.Drawing.Size(310, 240);
            this.Ordenamiento.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Ordenamiento, "Ordenamiento Pesquero");
            this.Ordenamiento.UseVisualStyleBackColor = true;
            this.Ordenamiento.Visible = false;
            this.Ordenamiento.Click += new System.EventHandler(this.Ordenamiento_Click);
            // 
            // Solicitudes
            // 
            this.Solicitudes.BackColor = System.Drawing.Color.White;
            this.Solicitudes.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.pedir;
            this.Solicitudes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Solicitudes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Solicitudes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Solicitudes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Solicitudes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.Solicitudes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Solicitudes.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solicitudes.Location = new System.Drawing.Point(44, 82);
            this.Solicitudes.Name = "Solicitudes";
            this.Solicitudes.Size = new System.Drawing.Size(280, 240);
            this.Solicitudes.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Solicitudes, "Apoyos Y Solicitudes");
            this.Solicitudes.UseVisualStyleBackColor = false;
            this.Solicitudes.Visible = false;
            this.Solicitudes.Click += new System.EventHandler(this.Solicitudes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Solicitudes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(588, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ordenamiento Pesquero";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label30.Location = new System.Drawing.Point(234, 12);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(407, 22);
            this.label30.TabIndex = 190;
            this.label30.Text = "Secretaría de Pesca y Desarrollo Agrupecuario";
            // 
            // CerrarPanel
            // 
            this.CerrarPanel.BackColor = System.Drawing.Color.Transparent;
            this.CerrarPanel.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.Equis;
            this.CerrarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CerrarPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CerrarPanel.Image = global::OrdenamientoPesquero.Properties.Resources.verde;
            this.CerrarPanel.Location = new System.Drawing.Point(861, 12);
            this.CerrarPanel.Name = "CerrarPanel";
            this.CerrarPanel.Size = new System.Drawing.Size(30, 30);
            this.CerrarPanel.TabIndex = 187;
            this.CerrarPanel.TabStop = false;
            this.toolTip1.SetToolTip(this.CerrarPanel, "Cerrar");
            this.CerrarPanel.Click += new System.EventHandler(this.CerrarPanel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Solicitudes);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.Ordenamiento);
            this.panel1.Controls.Add(this.CerrarPanel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 400);
            this.panel1.TabIndex = 191;
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(903, 409);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Menu1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu1";
            this.Activated += new System.EventHandler(this.Menu1_Activated);
            this.Load += new System.EventHandler(this.Menu1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CerrarPanel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Solicitudes;
        private System.Windows.Forms.Button Ordenamiento;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.PictureBox CerrarPanel;
        private System.Windows.Forms.Panel panel1;
    }
}