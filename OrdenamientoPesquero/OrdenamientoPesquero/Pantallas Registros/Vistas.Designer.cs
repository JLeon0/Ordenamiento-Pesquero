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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vista_permBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.permisos_lista = new OrdenamientoPesquero.Permisos_lista();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vistapermBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vista_permTableAdapter = new OrdenamientoPesquero.Permisos_listaTableAdapters.vista_permTableAdapter();
            this.ordPesqueroDataSetpescadores1 = new OrdenamientoPesquero.ordPesqueroDataSetpescadores1();
            this.pescadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pescadoresTableAdapter = new OrdenamientoPesquero.ordPesqueroDataSetpescadores1TableAdapters.pescadoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vista_permBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permisos_lista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistapermBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSetpescadores1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pescadoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vista_permBindingSource
            // 
            this.vista_permBindingSource.DataMember = "vista_perm";
            this.vista_permBindingSource.DataSource = this.permisos_lista;
            // 
            // permisos_lista
            // 
            this.permisos_lista.DataSetName = "Permisos_lista";
            this.permisos_lista.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.pescadoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OrdenamientoPesquero.Reportes.Permisos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1003, 421);
            this.reportViewer1.TabIndex = 0;
            // 
            // vistapermBindingSource
            // 
            this.vistapermBindingSource.DataMember = "vista_perm";
            this.vistapermBindingSource.DataSource = this.permisos_lista;
            // 
            // vista_permTableAdapter
            // 
            this.vista_permTableAdapter.ClearBeforeFill = true;
            // 
            // ordPesqueroDataSetpescadores1
            // 
            this.ordPesqueroDataSetpescadores1.DataSetName = "ordPesqueroDataSetpescadores1";
            this.ordPesqueroDataSetpescadores1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pescadoresBindingSource
            // 
            this.pescadoresBindingSource.DataMember = "pescadores";
            this.pescadoresBindingSource.DataSource = this.ordPesqueroDataSetpescadores1;
            // 
            // pescadoresTableAdapter
            // 
            this.pescadoresTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.vista_permBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permisos_lista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistapermBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordPesqueroDataSetpescadores1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pescadoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vistapermBindingSource;
        private Permisos_lista permisos_lista;
        private Permisos_listaTableAdapters.vista_permTableAdapter vista_permTableAdapter;
        private System.Windows.Forms.BindingSource vista_permBindingSource;
        private System.Windows.Forms.BindingSource pescadoresBindingSource;
        private ordPesqueroDataSetpescadores1 ordPesqueroDataSetpescadores1;
        private ordPesqueroDataSetpescadores1TableAdapters.pescadoresTableAdapter pescadoresTableAdapter;
    }
}