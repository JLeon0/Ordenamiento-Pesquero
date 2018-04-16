namespace OrdenamientoPesquero.Pantallas_Registros
{
    partial class Vistas
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pescadoresTableAdapter1 = new OrdenamientoPesquero.OrdPesqueroDataSet4TableAdapters.pescadoresTableAdapter();
            this.ordPesqueroDataSet41 = new OrdenamientoPesquero.OrdPesqueroDataSet4();
            this.ordPesqueroDataSet42 = new OrdenamientoPesquero.OrdPesqueroDataSet4();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSet41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSet42)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OrdenamientoPesquero.Reportes.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(726, 333);
            this.reportViewer1.TabIndex = 0;
            // 
            // pescadoresTableAdapter1
            // 
            this.pescadoresTableAdapter1.ClearBeforeFill = true;
            // 
            // ordPesqueroDataSet41
            // 
            this.ordPesqueroDataSet41.DataSetName = "OrdPesqueroDataSet4";
            this.ordPesqueroDataSet41.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordPesqueroDataSet42
            // 
            this.ordPesqueroDataSet42.DataSetName = "OrdPesqueroDataSet4";
            this.ordPesqueroDataSet42.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Vistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 333);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Vistas";
            this.Text = "Vistas";
            this.Load += new System.EventHandler(this.Vistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSet41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSet42)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private OrdPesqueroDataSet4TableAdapters.pescadoresTableAdapter pescadoresTableAdapter1;
        private OrdPesqueroDataSet4 ordPesqueroDataSet41;
        private OrdPesqueroDataSet4 ordPesqueroDataSet42;
    }
}