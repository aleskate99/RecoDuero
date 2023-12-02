namespace GestionRecoDuero
{
    partial class InformeMateriales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeMateriales));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.materialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonFiltrarNombre = new System.Windows.Forms.Button();
            this.textBoxFiltrarNombre = new System.Windows.Forms.TextBox();
            this.buttonQuitarFiltro = new System.Windows.Forms.Button();
            this.comboBoxFiltrarEstado = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarEstado = new System.Windows.Forms.Button();
            this.buttonFiltrarDistribuidor = new System.Windows.Forms.Button();
            this.textBoxFiltrarDistribuidor = new System.Windows.Forms.TextBox();
            this.materialTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.MaterialTableAdapter();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // materialBindingSource
            // 
            this.materialBindingSource.DataMember = "Material";
            this.materialBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.BackColor = System.Drawing.Color.Transparent;
            this.buttonVolverInicio.FlatAppearance.BorderSize = 0;
            this.buttonVolverInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1278, 52);
            this.buttonVolverInicio.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(88, 68);
            this.buttonVolverInicio.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonVolverInicio, "Volver a materiales");
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.materialBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeMaterial.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(999, 755);
            this.reportViewer1.TabIndex = 27;
            // 
            // buttonFiltrarNombre
            // 
            this.buttonFiltrarNombre.Location = new System.Drawing.Point(1196, 205);
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
            this.textBoxFiltrarNombre.Location = new System.Drawing.Point(1031, 209);
            this.textBoxFiltrarNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarNombre.Name = "textBoxFiltrarNombre";
            this.textBoxFiltrarNombre.Size = new System.Drawing.Size(132, 22);
            this.textBoxFiltrarNombre.TabIndex = 1;
            // 
            // buttonQuitarFiltro
            // 
            this.buttonQuitarFiltro.Location = new System.Drawing.Point(1126, 442);
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
            "Disponible",
            "Pendiente",
            "Agotado"});
            this.comboBoxFiltrarEstado.Location = new System.Drawing.Point(1031, 375);
            this.comboBoxFiltrarEstado.Name = "comboBoxFiltrarEstado";
            this.comboBoxFiltrarEstado.Size = new System.Drawing.Size(132, 24);
            this.comboBoxFiltrarEstado.TabIndex = 5;
            // 
            // buttonFiltrarEstado
            // 
            this.buttonFiltrarEstado.Location = new System.Drawing.Point(1196, 371);
            this.buttonFiltrarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarEstado.Name = "buttonFiltrarEstado";
            this.buttonFiltrarEstado.Size = new System.Drawing.Size(143, 31);
            this.buttonFiltrarEstado.TabIndex = 6;
            this.buttonFiltrarEstado.Text = "Filtrar por estado";
            this.buttonFiltrarEstado.UseVisualStyleBackColor = true;
            this.buttonFiltrarEstado.Click += new System.EventHandler(this.buttonFiltrarEstado_Click);
            // 
            // buttonFiltrarDistribuidor
            // 
            this.buttonFiltrarDistribuidor.Location = new System.Drawing.Point(1196, 281);
            this.buttonFiltrarDistribuidor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarDistribuidor.Name = "buttonFiltrarDistribuidor";
            this.buttonFiltrarDistribuidor.Size = new System.Drawing.Size(166, 28);
            this.buttonFiltrarDistribuidor.TabIndex = 4;
            this.buttonFiltrarDistribuidor.Text = "Filtrar por distribuidor";
            this.buttonFiltrarDistribuidor.UseVisualStyleBackColor = true;
            this.buttonFiltrarDistribuidor.Click += new System.EventHandler(this.buttonFiltrarDistribuidor_Click);
            // 
            // textBoxFiltrarDistribuidor
            // 
            this.textBoxFiltrarDistribuidor.Location = new System.Drawing.Point(1031, 283);
            this.textBoxFiltrarDistribuidor.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarDistribuidor.Name = "textBoxFiltrarDistribuidor";
            this.textBoxFiltrarDistribuidor.Size = new System.Drawing.Size(132, 22);
            this.textBoxFiltrarDistribuidor.TabIndex = 3;
            // 
            // materialTableAdapter
            // 
            this.materialTableAdapter.ClearBeforeFill = true;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AyudaRecoDuero.chm";
            // 
            // InformeMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1369, 756);
            this.Controls.Add(this.comboBoxFiltrarEstado);
            this.Controls.Add(this.buttonFiltrarEstado);
            this.Controls.Add(this.buttonFiltrarDistribuidor);
            this.Controls.Add(this.textBoxFiltrarDistribuidor);
            this.Controls.Add(this.buttonQuitarFiltro);
            this.Controls.Add(this.buttonFiltrarNombre);
            this.Controls.Add(this.textBoxFiltrarNombre);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonVolverInicio);
            this.helpProvider1.SetHelpKeyword(this, "7");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InformeMateriales";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeMateriales";
            this.Load += new System.EventHandler(this.InformeMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVolverInicio;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonFiltrarNombre;
        private System.Windows.Forms.TextBox textBoxFiltrarNombre;
        private System.Windows.Forms.Button buttonQuitarFiltro;
        private System.Windows.Forms.ComboBox comboBoxFiltrarEstado;
        private System.Windows.Forms.Button buttonFiltrarEstado;
        private System.Windows.Forms.Button buttonFiltrarDistribuidor;
        private System.Windows.Forms.TextBox textBoxFiltrarDistribuidor;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource materialBindingSource;
        private RecoDueroDataSetTableAdapters.MaterialTableAdapter materialTableAdapter;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}