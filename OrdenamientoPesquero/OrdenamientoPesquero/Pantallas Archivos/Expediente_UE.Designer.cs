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
            this.label1 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.CheckedListBox();
            this.ActasPesc = new System.Windows.Forms.Label();
            this.CurpsPesc = new System.Windows.Forms.Label();
            this.INEPesc = new System.Windows.Forms.Label();
            this.ComprPesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pescadores";
            // 
            // check
            // 
            this.check.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.check.FormattingEnabled = true;
            this.check.Items.AddRange(new object[] {
            "Actas de Nacimiento",
            "CURP",
            "Identificacion oficial (INE)",
            "Comprobante de Domicilio"});
            this.check.Location = new System.Drawing.Point(140, 83);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(174, 85);
            this.check.TabIndex = 2;
            // 
            // ActasPesc
            // 
            this.ActasPesc.AutoSize = true;
            this.ActasPesc.Location = new System.Drawing.Point(106, 83);
            this.ActasPesc.Name = "ActasPesc";
            this.ActasPesc.Size = new System.Drawing.Size(16, 16);
            this.ActasPesc.TabIndex = 3;
            this.ActasPesc.Text = "--";
            // 
            // CurpsPesc
            // 
            this.CurpsPesc.AutoSize = true;
            this.CurpsPesc.Location = new System.Drawing.Point(106, 100);
            this.CurpsPesc.Name = "CurpsPesc";
            this.CurpsPesc.Size = new System.Drawing.Size(16, 16);
            this.CurpsPesc.TabIndex = 4;
            this.CurpsPesc.Text = "--";
            // 
            // INEPesc
            // 
            this.INEPesc.AutoSize = true;
            this.INEPesc.Location = new System.Drawing.Point(106, 116);
            this.INEPesc.Name = "INEPesc";
            this.INEPesc.Size = new System.Drawing.Size(16, 16);
            this.INEPesc.TabIndex = 5;
            this.INEPesc.Text = "--";
            // 
            // ComprPesc
            // 
            this.ComprPesc.AutoSize = true;
            this.ComprPesc.Location = new System.Drawing.Point(106, 134);
            this.ComprPesc.Name = "ComprPesc";
            this.ComprPesc.Size = new System.Drawing.Size(16, 16);
            this.ComprPesc.TabIndex = 6;
            this.ComprPesc.Text = "--";
            // 
            // Expediente_UE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 356);
            this.Controls.Add(this.ComprPesc);
            this.Controls.Add(this.INEPesc);
            this.Controls.Add(this.CurpsPesc);
            this.Controls.Add(this.ActasPesc);
            this.Controls.Add(this.check);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Expediente_UE";
            this.Text = "Expediente_UE";
            this.Load += new System.EventHandler(this.Expediente_UE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox check;
        private System.Windows.Forms.Label ActasPesc;
        private System.Windows.Forms.Label CurpsPesc;
        private System.Windows.Forms.Label INEPesc;
        private System.Windows.Forms.Label ComprPesc;
    }
}