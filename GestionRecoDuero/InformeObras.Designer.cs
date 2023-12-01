namespace GestionRecoDuero
{
    partial class InformeObras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeObras));
            this.obraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obraTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.ObraTableAdapter();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.comboBoxFiltrarTipo = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarTipo = new System.Windows.Forms.Button();
            this.buttonFiltrarEstado = new System.Windows.Forms.Button();
            this.buttonFiltrarNombre = new System.Windows.Forms.Button();
            this.textBoxFiltrarNombre = new System.Windows.Forms.TextBox();
            this.buttonQuitarFiltro = new System.Windows.Forms.Button();
            this.comboBoxFiltrarEstado = new System.Windows.Forms.ComboBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.obraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // obraBindingSource
            // 
            this.obraBindingSource.DataMember = "Obra";
            this.obraBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeObra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(959, 766);
            this.reportViewer1.TabIndex = 0;
            // 
            // obraTableAdapter
            // 
            this.obraTableAdapter.ClearBeforeFill = true;
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.BackColor = System.Drawing.Color.Transparent;
            this.buttonVolverInicio.FlatAppearance.BorderSize = 0;
            this.buttonVolverInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1253, 64);
            this.buttonVolverInicio.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(88, 68);
            this.buttonVolverInicio.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonVolverInicio, "Volver a obras");
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // comboBoxFiltrarTipo
            // 
            this.comboBoxFiltrarTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarTipo.FormattingEnabled = true;
            this.comboBoxFiltrarTipo.Items.AddRange(new object[] {
            "Residencial",
            "Comercial",
            "Institucional"});
            this.comboBoxFiltrarTipo.Location = new System.Drawing.Point(1000, 413);
            this.comboBoxFiltrarTipo.Name = "comboBoxFiltrarTipo";
            this.comboBoxFiltrarTipo.Size = new System.Drawing.Size(146, 24);
            this.comboBoxFiltrarTipo.TabIndex = 5;
            // 
            // buttonFiltrarTipo
            // 
            this.buttonFiltrarTipo.Location = new System.Drawing.Point(1179, 409);
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
            this.buttonFiltrarEstado.Location = new System.Drawing.Point(1179, 319);
            this.buttonFiltrarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarEstado.Name = "buttonFiltrarEstado";
            this.buttonFiltrarEstado.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarEstado.TabIndex = 4;
            this.buttonFiltrarEstado.Text = "Filtrar por estado";
            this.buttonFiltrarEstado.UseVisualStyleBackColor = true;
            this.buttonFiltrarEstado.Click += new System.EventHandler(this.buttonFiltrarEstado_Click);
            // 
            // buttonFiltrarNombre
            // 
            this.buttonFiltrarNombre.Location = new System.Drawing.Point(1179, 220);
            this.buttonFiltrarNombre.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarNombre.Name = "buttonFiltrarNombre";
            this.buttonFiltrarNombre.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarNombre.TabIndex = 2;
            this.buttonFiltrarNombre.Text = "Filtrar por nombre";
            this.buttonFiltrarNombre.UseVisualStyleBackColor = true;
            this.buttonFiltrarNombre.Click += new System.EventHandler(this.buttonFiltrarNombre_Click);
            // 
            // textBoxFiltrarNombre
            // 
            this.textBoxFiltrarNombre.Location = new System.Drawing.Point(1000, 224);
            this.textBoxFiltrarNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarNombre.Name = "textBoxFiltrarNombre";
            this.textBoxFiltrarNombre.Size = new System.Drawing.Size(146, 22);
            this.textBoxFiltrarNombre.TabIndex = 1;
            // 
            // buttonQuitarFiltro
            // 
            this.buttonQuitarFiltro.Location = new System.Drawing.Point(1110, 500);
            this.buttonQuitarFiltro.Name = "buttonQuitarFiltro";
            this.buttonQuitarFiltro.Size = new System.Drawing.Size(123, 23);
            this.buttonQuitarFiltro.TabIndex = 7;
            this.buttonQuitarFiltro.Text = "Quitar filtros";
            this.buttonQuitarFiltro.UseVisualStyleBackColor = true;
            this.buttonQuitarFiltro.Click += new System.EventHandler(this.buttonQuitarFiltro_Click);
            // 
            // comboBoxFiltrarEstado
            // 
            this.comboBoxFiltrarEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarEstado.FormattingEnabled = true;
            this.comboBoxFiltrarEstado.Items.AddRange(new object[] {
            "Pendiente",
            "En curso",
            "Finalizada"});
            this.comboBoxFiltrarEstado.Location = new System.Drawing.Point(1000, 319);
            this.comboBoxFiltrarEstado.Name = "comboBoxFiltrarEstado";
            this.comboBoxFiltrarEstado.Size = new System.Drawing.Size(146, 24);
            this.comboBoxFiltrarEstado.TabIndex = 3;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AyudaRecoDuero.chm";
            // 
            // InformeObras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1354, 769);
            this.Controls.Add(this.comboBoxFiltrarEstado);
            this.Controls.Add(this.comboBoxFiltrarTipo);
            this.Controls.Add(this.buttonFiltrarTipo);
            this.Controls.Add(this.buttonFiltrarEstado);
            this.Controls.Add(this.buttonFiltrarNombre);
            this.Controls.Add(this.textBoxFiltrarNombre);
            this.Controls.Add(this.buttonQuitarFiltro);
            this.Controls.Add(this.buttonVolverInicio);
            this.Controls.Add(this.reportViewer1);
            this.helpProvider1.SetHelpKeyword(this, "9");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InformeObras";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeObras";
            this.Load += new System.EventHandler(this.InformeObras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource obraBindingSource;
        private RecoDueroDataSetTableAdapters.ObraTableAdapter obraTableAdapter;
        private System.Windows.Forms.Button buttonVolverInicio;
        private System.Windows.Forms.ComboBox comboBoxFiltrarTipo;
        private System.Windows.Forms.Button buttonFiltrarTipo;
        private System.Windows.Forms.Button buttonFiltrarEstado;
        private System.Windows.Forms.Button buttonFiltrarNombre;
        private System.Windows.Forms.TextBox textBoxFiltrarNombre;
        private System.Windows.Forms.Button buttonQuitarFiltro;
        private System.Windows.Forms.ComboBox comboBoxFiltrarEstado;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}