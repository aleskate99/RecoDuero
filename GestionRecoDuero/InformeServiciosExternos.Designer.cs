namespace GestionRecoDuero
{
    partial class InformeServiciosExternos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeServiciosExternos));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.servicioExternoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicioExternoTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.ServicioExternoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicioExternoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.servicioExternoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeServicioExterno.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(883, 662);
            this.reportViewer1.TabIndex = 0;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servicioExternoBindingSource
            // 
            this.servicioExternoBindingSource.DataMember = "ServicioExterno";
            this.servicioExternoBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // servicioExternoTableAdapter
            // 
            this.servicioExternoTableAdapter.ClearBeforeFill = true;
            // 
            // InformeServiciosExternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1170, 667);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InformeServiciosExternos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeServiciosExternos";
            this.Load += new System.EventHandler(this.InformeServiciosExternos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicioExternoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource servicioExternoBindingSource;
        private RecoDueroDataSetTableAdapters.ServicioExternoTableAdapter servicioExternoTableAdapter;
    }
}