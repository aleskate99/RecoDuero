namespace GestionRecoDuero
{
    partial class InformeClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeClientes));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.ClienteTableAdapter();
            this.comboBoxFiltrarTipo = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarTipo = new System.Windows.Forms.Button();
            this.buttonFiltrarTelefono = new System.Windows.Forms.Button();
            this.textBoxFiltrarTelefono = new System.Windows.Forms.TextBox();
            this.buttonFiltrarNombre = new System.Windows.Forms.Button();
            this.textBoxFiltrarNombre = new System.Windows.Forms.TextBox();
            this.buttonQuitarFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.BackColor = System.Drawing.Color.Transparent;
            this.buttonVolverInicio.FlatAppearance.BorderSize = 0;
            this.buttonVolverInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1272, 45);
            this.buttonVolverInicio.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(88, 68);
            this.buttonVolverInicio.TabIndex = 25;
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // reportViewer1
            // 
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.clienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1004, 763);
            this.reportViewer1.TabIndex = 26;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxFiltrarTipo
            // 
            this.comboBoxFiltrarTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarTipo.FormattingEnabled = true;
            this.comboBoxFiltrarTipo.Items.AddRange(new object[] {
            "Normal",
            "VIP"});
            this.comboBoxFiltrarTipo.Location = new System.Drawing.Point(1036, 398);
            this.comboBoxFiltrarTipo.Name = "comboBoxFiltrarTipo";
            this.comboBoxFiltrarTipo.Size = new System.Drawing.Size(132, 24);
            this.comboBoxFiltrarTipo.TabIndex = 43;
            // 
            // buttonFiltrarTipo
            // 
            this.buttonFiltrarTipo.Location = new System.Drawing.Point(1201, 394);
            this.buttonFiltrarTipo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarTipo.Name = "buttonFiltrarTipo";
            this.buttonFiltrarTipo.Size = new System.Drawing.Size(143, 31);
            this.buttonFiltrarTipo.TabIndex = 42;
            this.buttonFiltrarTipo.Text = "Filtrar por tipo";
            this.buttonFiltrarTipo.UseVisualStyleBackColor = true;
            this.buttonFiltrarTipo.Click += new System.EventHandler(this.buttonFiltrarTipo_Click);
            // 
            // buttonFiltrarTelefono
            // 
            this.buttonFiltrarTelefono.Location = new System.Drawing.Point(1201, 304);
            this.buttonFiltrarTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarTelefono.Name = "buttonFiltrarTelefono";
            this.buttonFiltrarTelefono.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarTelefono.TabIndex = 39;
            this.buttonFiltrarTelefono.Text = "Filtrar por teléfono";
            this.buttonFiltrarTelefono.UseVisualStyleBackColor = true;
            this.buttonFiltrarTelefono.Click += new System.EventHandler(this.buttonFiltrarTelefono_Click);
            // 
            // textBoxFiltrarTelefono
            // 
            this.textBoxFiltrarTelefono.Location = new System.Drawing.Point(1036, 306);
            this.textBoxFiltrarTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarTelefono.Name = "textBoxFiltrarTelefono";
            this.textBoxFiltrarTelefono.Size = new System.Drawing.Size(132, 22);
            this.textBoxFiltrarTelefono.TabIndex = 38;
            // 
            // buttonFiltrarNombre
            // 
            this.buttonFiltrarNombre.Location = new System.Drawing.Point(1201, 205);
            this.buttonFiltrarNombre.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarNombre.Name = "buttonFiltrarNombre";
            this.buttonFiltrarNombre.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarNombre.TabIndex = 37;
            this.buttonFiltrarNombre.Text = "Filtrar por nombre";
            this.buttonFiltrarNombre.UseVisualStyleBackColor = true;
            this.buttonFiltrarNombre.Click += new System.EventHandler(this.buttonFiltrarNombre_Click);
            // 
            // textBoxFiltrarNombre
            // 
            this.textBoxFiltrarNombre.Location = new System.Drawing.Point(1036, 209);
            this.textBoxFiltrarNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarNombre.Name = "textBoxFiltrarNombre";
            this.textBoxFiltrarNombre.Size = new System.Drawing.Size(132, 22);
            this.textBoxFiltrarNombre.TabIndex = 36;
            // 
            // buttonQuitarFiltro
            // 
            this.buttonQuitarFiltro.Location = new System.Drawing.Point(1132, 485);
            this.buttonQuitarFiltro.Name = "buttonQuitarFiltro";
            this.buttonQuitarFiltro.Size = new System.Drawing.Size(123, 23);
            this.buttonQuitarFiltro.TabIndex = 35;
            this.buttonQuitarFiltro.Text = "Quitar filtros";
            this.buttonQuitarFiltro.UseVisualStyleBackColor = true;
            this.buttonQuitarFiltro.Click += new System.EventHandler(this.buttonQuitarFiltro_Click);
            // 
            // InformeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1373, 768);
            this.Controls.Add(this.comboBoxFiltrarTipo);
            this.Controls.Add(this.buttonFiltrarTipo);
            this.Controls.Add(this.buttonFiltrarTelefono);
            this.Controls.Add(this.textBoxFiltrarTelefono);
            this.Controls.Add(this.buttonFiltrarNombre);
            this.Controls.Add(this.textBoxFiltrarNombre);
            this.Controls.Add(this.buttonQuitarFiltro);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonVolverInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InformeClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeClientes";
            this.Load += new System.EventHandler(this.InformeClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVolverInicio;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private RecoDueroDataSetTableAdapters.ClienteTableAdapter clienteTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxFiltrarTipo;
        private System.Windows.Forms.Button buttonFiltrarTipo;
        private System.Windows.Forms.Button buttonFiltrarTelefono;
        private System.Windows.Forms.TextBox textBoxFiltrarTelefono;
        private System.Windows.Forms.Button buttonFiltrarNombre;
        private System.Windows.Forms.TextBox textBoxFiltrarNombre;
        private System.Windows.Forms.Button buttonQuitarFiltro;
    }
}