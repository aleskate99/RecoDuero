namespace GestionRecoDuero
{
    partial class InformeFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeFacturas));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.facturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonFiltrarEmpleado = new System.Windows.Forms.Button();
            this.textBoxFiltrarEmpleado = new System.Windows.Forms.TextBox();
            this.comboBoxFiltrarEstado = new System.Windows.Forms.ComboBox();
            this.comboBoxFiltrarMetodo = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarMetodo = new System.Windows.Forms.Button();
            this.buttonFiltrarEstado = new System.Windows.Forms.Button();
            this.buttonFiltrarCliente = new System.Windows.Forms.Button();
            this.textBoxFiltrarCliente = new System.Windows.Forms.TextBox();
            this.buttonQuitarFiltro = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.facturaTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.FacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // facturaBindingSource
            // 
            this.facturaBindingSource.DataMember = "Factura";
            this.facturaBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AyudaRecoDuero.chm";
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.BackColor = System.Drawing.Color.Transparent;
            this.buttonVolverInicio.FlatAppearance.BorderSize = 0;
            this.buttonVolverInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1258, 61);
            this.buttonVolverInicio.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(88, 68);
            this.buttonVolverInicio.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonVolverInicio, "Volver a facturas");
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.facturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(961, 756);
            this.reportViewer1.TabIndex = 10;
            // 
            // buttonFiltrarEmpleado
            // 
            this.buttonFiltrarEmpleado.Location = new System.Drawing.Point(1170, 185);
            this.buttonFiltrarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarEmpleado.Name = "buttonFiltrarEmpleado";
            this.buttonFiltrarEmpleado.Size = new System.Drawing.Size(158, 28);
            this.buttonFiltrarEmpleado.TabIndex = 12;
            this.buttonFiltrarEmpleado.Text = "Filtrar por empleado";
            this.buttonFiltrarEmpleado.UseVisualStyleBackColor = true;
            this.buttonFiltrarEmpleado.Click += new System.EventHandler(this.buttonFiltrarEmpleado_Click);
            // 
            // textBoxFiltrarEmpleado
            // 
            this.textBoxFiltrarEmpleado.Location = new System.Drawing.Point(991, 189);
            this.textBoxFiltrarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarEmpleado.Name = "textBoxFiltrarEmpleado";
            this.textBoxFiltrarEmpleado.Size = new System.Drawing.Size(146, 22);
            this.textBoxFiltrarEmpleado.TabIndex = 11;
            // 
            // comboBoxFiltrarEstado
            // 
            this.comboBoxFiltrarEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarEstado.FormattingEnabled = true;
            this.comboBoxFiltrarEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Aprobado",
            "Rechazado"});
            this.comboBoxFiltrarEstado.Location = new System.Drawing.Point(991, 371);
            this.comboBoxFiltrarEstado.Name = "comboBoxFiltrarEstado";
            this.comboBoxFiltrarEstado.Size = new System.Drawing.Size(146, 24);
            this.comboBoxFiltrarEstado.TabIndex = 15;
            // 
            // comboBoxFiltrarMetodo
            // 
            this.comboBoxFiltrarMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarMetodo.FormattingEnabled = true;
            this.comboBoxFiltrarMetodo.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.comboBoxFiltrarMetodo.Location = new System.Drawing.Point(991, 465);
            this.comboBoxFiltrarMetodo.Name = "comboBoxFiltrarMetodo";
            this.comboBoxFiltrarMetodo.Size = new System.Drawing.Size(146, 24);
            this.comboBoxFiltrarMetodo.TabIndex = 17;
            // 
            // buttonFiltrarMetodo
            // 
            this.buttonFiltrarMetodo.Location = new System.Drawing.Point(1170, 461);
            this.buttonFiltrarMetodo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarMetodo.Name = "buttonFiltrarMetodo";
            this.buttonFiltrarMetodo.Size = new System.Drawing.Size(158, 31);
            this.buttonFiltrarMetodo.TabIndex = 18;
            this.buttonFiltrarMetodo.Text = "Filtrar por método";
            this.buttonFiltrarMetodo.UseVisualStyleBackColor = true;
            this.buttonFiltrarMetodo.Click += new System.EventHandler(this.buttonFiltrarMetodo_Click);
            // 
            // buttonFiltrarEstado
            // 
            this.buttonFiltrarEstado.Location = new System.Drawing.Point(1170, 371);
            this.buttonFiltrarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarEstado.Name = "buttonFiltrarEstado";
            this.buttonFiltrarEstado.Size = new System.Drawing.Size(158, 28);
            this.buttonFiltrarEstado.TabIndex = 16;
            this.buttonFiltrarEstado.Text = "Filtrar por estado";
            this.buttonFiltrarEstado.UseVisualStyleBackColor = true;
            this.buttonFiltrarEstado.Click += new System.EventHandler(this.buttonFiltrarEstado_Click);
            // 
            // buttonFiltrarCliente
            // 
            this.buttonFiltrarCliente.Location = new System.Drawing.Point(1170, 272);
            this.buttonFiltrarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarCliente.Name = "buttonFiltrarCliente";
            this.buttonFiltrarCliente.Size = new System.Drawing.Size(158, 28);
            this.buttonFiltrarCliente.TabIndex = 14;
            this.buttonFiltrarCliente.Text = "Filtrar por cliente";
            this.buttonFiltrarCliente.UseVisualStyleBackColor = true;
            this.buttonFiltrarCliente.Click += new System.EventHandler(this.buttonFiltrarCliente_Click);
            // 
            // textBoxFiltrarCliente
            // 
            this.textBoxFiltrarCliente.Location = new System.Drawing.Point(991, 276);
            this.textBoxFiltrarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarCliente.Name = "textBoxFiltrarCliente";
            this.textBoxFiltrarCliente.Size = new System.Drawing.Size(146, 22);
            this.textBoxFiltrarCliente.TabIndex = 13;
            // 
            // buttonQuitarFiltro
            // 
            this.buttonQuitarFiltro.Location = new System.Drawing.Point(1101, 552);
            this.buttonQuitarFiltro.Name = "buttonQuitarFiltro";
            this.buttonQuitarFiltro.Size = new System.Drawing.Size(123, 23);
            this.buttonQuitarFiltro.TabIndex = 19;
            this.buttonQuitarFiltro.Text = "Quitar filtros";
            this.buttonQuitarFiltro.UseVisualStyleBackColor = true;
            this.buttonQuitarFiltro.Click += new System.EventHandler(this.buttonQuitarFiltro_Click);
            // 
            // facturaTableAdapter
            // 
            this.facturaTableAdapter.ClearBeforeFill = true;
            // 
            // InformeFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1359, 758);
            this.Controls.Add(this.buttonFiltrarEmpleado);
            this.Controls.Add(this.textBoxFiltrarEmpleado);
            this.Controls.Add(this.comboBoxFiltrarEstado);
            this.Controls.Add(this.comboBoxFiltrarMetodo);
            this.Controls.Add(this.buttonFiltrarMetodo);
            this.Controls.Add(this.buttonFiltrarEstado);
            this.Controls.Add(this.buttonFiltrarCliente);
            this.Controls.Add(this.textBoxFiltrarCliente);
            this.Controls.Add(this.buttonQuitarFiltro);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonVolverInicio);
            this.helpProvider1.SetHelpKeyword(this, "17");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformeFacturas";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeFacturas";
            this.Load += new System.EventHandler(this.InformeFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button buttonVolverInicio;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonFiltrarEmpleado;
        private System.Windows.Forms.TextBox textBoxFiltrarEmpleado;
        private System.Windows.Forms.ComboBox comboBoxFiltrarEstado;
        private System.Windows.Forms.ComboBox comboBoxFiltrarMetodo;
        private System.Windows.Forms.Button buttonFiltrarMetodo;
        private System.Windows.Forms.Button buttonFiltrarEstado;
        private System.Windows.Forms.Button buttonFiltrarCliente;
        private System.Windows.Forms.TextBox textBoxFiltrarCliente;
        private System.Windows.Forms.Button buttonQuitarFiltro;
        private System.Windows.Forms.ToolTip toolTip1;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource facturaBindingSource;
        private RecoDueroDataSetTableAdapters.FacturaTableAdapter facturaTableAdapter;
    }
}