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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu1));
            this.Solicitudes = new System.Windows.Forms.Button();
            this.Ordenamiento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Solicitudes
            // 
            this.Solicitudes.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solicitudes.Location = new System.Drawing.Point(60, 97);
            this.Solicitudes.Name = "Solicitudes";
            this.Solicitudes.Size = new System.Drawing.Size(278, 199);
            this.Solicitudes.TabIndex = 0;
            this.Solicitudes.Text = "Solicitudes";
            this.Solicitudes.UseVisualStyleBackColor = true;
            this.Solicitudes.Visible = false;
            this.Solicitudes.Click += new System.EventHandler(this.Solicitudes_Click);
            // 
            // Ordenamiento
            // 
            this.Ordenamiento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ordenamiento.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ordenamiento.Location = new System.Drawing.Point(432, 97);
            this.Ordenamiento.Name = "Ordenamiento";
            this.Ordenamiento.Size = new System.Drawing.Size(278, 199);
            this.Ordenamiento.TabIndex = 0;
            this.Ordenamiento.Text = "Ord Pesquero";
            this.Ordenamiento.UseVisualStyleBackColor = true;
            this.Ordenamiento.Visible = false;
            this.Ordenamiento.Click += new System.EventHandler(this.Ordenamiento_Click);
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(803, 409);
            this.Controls.Add(this.Ordenamiento);
            this.Controls.Add(this.Solicitudes);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Menu1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu1";
            this.Activated += new System.EventHandler(this.Menu1_Activated);
            this.Load += new System.EventHandler(this.Menu1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Solicitudes;
        private System.Windows.Forms.Button Ordenamiento;
    }
}