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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeServiciosExternos));
            this.servicioExternoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.servicioExternoTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.ServicioExternoTableAdapter();
            this.comboBoxFiltrarEstado = new System.Windows.Forms.ComboBox();
            this.comboBoxFiltrarTipo = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarTipo = new System.Windows.Forms.Button();
            this.buttonFiltrarEstado = new System.Windows.Forms.Button();
            this.buttonFiltrarEmpresa = new System.Windows.Forms.Button();
            this.textBoxFiltrarEmpresa = new System.Windows.Forms.TextBox();
            this.buttonQuitarFiltro = new System.Windows.Forms.Button();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.servicioExternoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // servicioExternoBindingSource
            // 
            this.servicioExternoBindingSource.DataMember = "ServicioExterno";
            this.servicioExternoBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.servicioExternoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeServicioExterno.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(998, 758);
            this.reportViewer1.TabIndex = 0;
            // 
            // servicioExternoTableAdapter
            // 
            this.servicioExternoTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxFiltrarEstado
            // 
            this.comboBoxFiltrarEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarEstado.FormattingEnabled = true;
            this.comboBoxFiltrarEstado.Items.AddRange(new object[] {
            "En curso",
            "Completado",
            "Pendiente",
            "Cancelado"});
            this.comboBoxFiltrarEstado.Location = new System.Drawing.Point(1028, 324);
            this.comboBoxFiltrarEstado.Name = "comboBoxFiltrarEstado";
            this.comboBoxFiltrarEstado.Size = new System.Drawing.Size(154, 24);
            this.comboBoxFiltrarEstado.TabIndex = 3;
            // 
            // comboBoxFiltrarTipo
            // 
            this.comboBoxFiltrarTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarTipo.FormattingEnabled = true;
            this.comboBoxFiltrarTipo.Items.AddRange(new object[] {
            "Transporte",
            "Materiales",
            "Consultoría",
            "Mantenimiento"});
            this.comboBoxFiltrarTipo.Location = new System.Drawing.Point(1028, 418);
            this.comboBoxFiltrarTipo.Name = "comboBoxFiltrarTipo";
            this.comboBoxFiltrarTipo.Size = new System.Drawing.Size(154, 24);
            this.comboBoxFiltrarTipo.TabIndex = 5;
            // 
            // buttonFiltrarTipo
            // 
            this.buttonFiltrarTipo.Location = new System.Drawing.Point(1215, 414);
            this.buttonFiltrarTipo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarTipo.Name = "buttonFiltrarTipo";
            this.buttonFiltrarTipo.Size = new System.Drawing.Size(143, 31);
            this.buttonFiltrarTipo.TabIndex = 6;
            this.buttonFiltrarTipo.Text = "Filtrar por tipo";
            this.buttonFiltrarTipo.UseVisualStyleBackColor = true;
            this.buttonFiltrarTipo.Click += new System.EventHandler(this.buttonFiltrarTipo_Click);
            // 
            // buttonFiltrarEstado
            // 
            this.buttonFiltrarEstado.Location = new System.Drawing.Point(1215, 324);
            this.buttonFiltrarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarEstado.Name = "buttonFiltrarEstado";
            this.buttonFiltrarEstado.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarEstado.TabIndex = 4;
            this.buttonFiltrarEstado.Text = "Filtrar por estado";
            this.buttonFiltrarEstado.UseVisualStyleBackColor = true;
            this.buttonFiltrarEstado.Click += new System.EventHandler(this.buttonFiltrarEstado_Click);
            // 
            // buttonFiltrarEmpresa
            // 
            this.buttonFiltrarEmpresa.Location = new System.Drawing.Point(1215, 225);
            this.buttonFiltrarEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarEmpresa.Name = "buttonFiltrarEmpresa";
            this.buttonFiltrarEmpresa.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarEmpresa.TabIndex = 2;
            this.buttonFiltrarEmpresa.Text = "Filtrar por empresa\r\n";
            this.buttonFiltrarEmpresa.UseVisualStyleBackColor = true;
            this.buttonFiltrarEmpresa.Click += new System.EventHandler(this.buttonFiltrarEmpresa_Click);
            // 
            // textBoxFiltrarEmpresa
            // 
            this.textBoxFiltrarEmpresa.Location = new System.Drawing.Point(1028, 229);
            this.textBoxFiltrarEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarEmpresa.Name = "textBoxFiltrarEmpresa";
            this.textBoxFiltrarEmpresa.Size = new System.Drawing.Size(154, 22);
            this.textBoxFiltrarEmpresa.TabIndex = 1;
            // 
            // buttonQuitarFiltro
            // 
            this.buttonQuitarFiltro.Location = new System.Drawing.Point(1143, 510);
            this.buttonQuitarFiltro.Name = "buttonQuitarFiltro";
            this.buttonQuitarFiltro.Size = new System.Drawing.Size(123, 23);
            this.buttonQuitarFiltro.TabIndex = 7;
            this.buttonQuitarFiltro.Text = "Quitar filtros";
            this.buttonQuitarFiltro.UseVisualStyleBackColor = true;
            this.buttonQuitarFiltro.Click += new System.EventHandler(this.buttonQuitarFiltro_Click);
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.BackColor = System.Drawing.Color.Transparent;
            this.buttonVolverInicio.FlatAppearance.BorderSize = 0;
            this.buttonVolverInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1289, 79);
            this.buttonVolverInicio.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(88, 68);
            this.buttonVolverInicio.TabIndex = 8;
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AyudaRecoDuero.chm";
            // 
            // InformeServiciosExternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1390, 760);
            this.Controls.Add(this.buttonVolverInicio);
            this.Controls.Add(this.comboBoxFiltrarEstado);
            this.Controls.Add(this.comboBoxFiltrarTipo);
            this.Controls.Add(this.buttonFiltrarTipo);
            this.Controls.Add(this.buttonFiltrarEstado);
            this.Controls.Add(this.buttonFiltrarEmpresa);
            this.Controls.Add(this.textBoxFiltrarEmpresa);
            this.Controls.Add(this.buttonQuitarFiltro);
            this.Controls.Add(this.reportViewer1);
            this.helpProvider1.SetHelpKeyword(this, "13");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InformeServiciosExternos";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeServiciosExternos";
            this.Load += new System.EventHandler(this.InformeServiciosExternos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servicioExternoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource servicioExternoBindingSource;
        private RecoDueroDataSetTableAdapters.ServicioExternoTableAdapter servicioExternoTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxFiltrarEstado;
        private System.Windows.Forms.ComboBox comboBoxFiltrarTipo;
        private System.Windows.Forms.Button buttonFiltrarTipo;
        private System.Windows.Forms.Button buttonFiltrarEstado;
        private System.Windows.Forms.Button buttonFiltrarEmpresa;
        private System.Windows.Forms.TextBox textBoxFiltrarEmpresa;
        private System.Windows.Forms.Button buttonQuitarFiltro;
        private System.Windows.Forms.Button buttonVolverInicio;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}