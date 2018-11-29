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
            this.Solicitudes = new System.Windows.Forms.Button();
            this.Ordenamiento = new System.Windows.Forms.Button();
            this.loading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.SuspendLayout();
            // 
            // Solicitudes
            // 
            this.Solicitudes.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solicitudes.Location = new System.Drawing.Point(62, 78);
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
            this.Ordenamiento.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ordenamiento.Location = new System.Drawing.Point(440, 78);
            this.Ordenamiento.Name = "Ordenamiento";
            this.Ordenamiento.Size = new System.Drawing.Size(278, 199);
            this.Ordenamiento.TabIndex = 0;
            this.Ordenamiento.Text = "Ord Pesquero";
            this.Ordenamiento.UseVisualStyleBackColor = true;
            this.Ordenamiento.Visible = false;
            this.Ordenamiento.Click += new System.EventHandler(this.Ordenamiento_Click);
            // 
            // loading
            // 
            this.loading.BackgroundImage = global::OrdenamientoPesquero.Properties.Resources.cargando1;
            this.loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loading.Location = new System.Drawing.Point(3, -94);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(800, 552);
            this.loading.TabIndex = 1;
            this.loading.TabStop = false;
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 375);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.Ordenamiento);
            this.Controls.Add(this.Solicitudes);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Menu1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu1";
            this.Activated += new System.EventHandler(this.Menu1_Activated);
            this.Load += new System.EventHandler(this.Menu1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Solicitudes;
        private System.Windows.Forms.Button Ordenamiento;
        private System.Windows.Forms.PictureBox loading;
    }
}