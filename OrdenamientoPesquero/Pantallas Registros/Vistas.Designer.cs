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
            this.components = new System.ComponentModel.Container();
            this.pescadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordPesqueroDataSet1 = new OrdenamientoPesquero.OrdPesqueroDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pescadoresTableAdapter = new OrdenamientoPesquero.OrdPesqueroDataSet1TableAdapters.pescadoresTableAdapter();
            this.dataSetPermisos = new OrdenamientoPesquero.DataSetPermisos();
            this.vistapermBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vista_permTableAdapter1 = new OrdenamientoPesquero.DataSetPermisosTableAdapters.vista_permTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pescadoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistapermBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pescadoresBindingSource
            // 
            this.pescadoresBindingSource.DataMember = "pescadores";
            this.pescadoresBindingSource.DataSource = this.ordPesqueroDataSet1;
            // 
            // ordPesqueroDataSet1
            // 
            this.ordPesqueroDataSet1.DataSetName = "OrdPesqueroDataSet1";
            this.ordPesqueroDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OrdenamientoPesquero.Reportes.Anexo3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1003, 421);
            this.reportViewer1.TabIndex = 0;
            // 
            // pescadoresTableAdapter
            // 
            this.pescadoresTableAdapter.ClearBeforeFill = true;
            // 
            // dataSetPermisos
            // 
            this.dataSetPermisos.DataSetName = "DataSetPermisos";
            this.dataSetPermisos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vistapermBindingSource
            // 
            this.vistapermBindingSource.DataMember = "vista_perm";
            this.vistapermBindingSource.DataSource = this.dataSetPermisos;
            // 
            // vista_permTableAdapter1
            // 
            this.vista_permTableAdapter1.ClearBeforeFill = true;
            // 
            // Vistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 421);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Vistas";
            this.Text = "Vistas";
            this.Load += new System.EventHandler(this.Vistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pescadoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistapermBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Permisos_listaTableAdapters.vista_permTableAdapter vista_permTableAdapter;
        private System.Windows.Forms.BindingSource vistapermBindingSource;
        private DataSetPermisos dataSetPermisos;
        private OrdPesqueroDataSet1 ordPesqueroDataSet1;
        private System.Windows.Forms.BindingSource pescadoresBindingSource;
        private OrdPesqueroDataSet1TableAdapters.pescadoresTableAdapter pescadoresTableAdapter;
        private DataSetPermisosTableAdapters.vista_permTableAdapter vista_permTableAdapter1;
    }
}