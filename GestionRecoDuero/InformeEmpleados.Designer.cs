namespace GestionRecoDuero
{
    partial class InformeEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeEmpleados));
            this.empleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonQuitarFiltro = new System.Windows.Forms.Button();
            this.empleadoTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.EmpleadoTableAdapter();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.comboBoxFiltrarSituacionLaboral = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarSituacionLaboral = new System.Windows.Forms.Button();
            this.buttonFiltrarDni = new System.Windows.Forms.Button();
            this.textBoxFiltrarDNI = new System.Windows.Forms.TextBox();
            this.buttonFiltrarNombre = new System.Windows.Forms.Button();
            this.textBoxFiltrarNombre = new System.Windows.Forms.TextBox();
            this.comboBoxFiltrarPuesto = new System.Windows.Forms.ComboBox();
            this.buttonFiltrarPuesto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // empleadoBindingSource
            // 
            this.empleadoBindingSource.DataMember = "Empleado";
            this.empleadoBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.empleadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionRecoDuero.InformeEmpleado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1007, 756);
            this.reportViewer1.TabIndex = 0;
            // 
            // buttonQuitarFiltro
            // 
            this.buttonQuitarFiltro.Location = new System.Drawing.Point(1135, 567);
            this.buttonQuitarFiltro.Name = "buttonQuitarFiltro";
            this.buttonQuitarFiltro.Size = new System.Drawing.Size(123, 23);
            this.buttonQuitarFiltro.TabIndex = 9;
            this.buttonQuitarFiltro.Text = "Quitar filtros";
            this.buttonQuitarFiltro.UseVisualStyleBackColor = true;
            this.buttonQuitarFiltro.Click += new System.EventHandler(this.buttonQuitarFiltro_Click);
            // 
            // empleadoTableAdapter
            // 
            this.empleadoTableAdapter.ClearBeforeFill = true;
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.BackColor = System.Drawing.Color.Transparent;
            this.buttonVolverInicio.FlatAppearance.BorderSize = 0;
            this.buttonVolverInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1281, 43);
            this.buttonVolverInicio.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(88, 68);
            this.buttonVolverInicio.TabIndex = 10;
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // comboBoxFiltrarSituacionLaboral
            // 
            this.comboBoxFiltrarSituacionLaboral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarSituacionLaboral.FormattingEnabled = true;
            this.comboBoxFiltrarSituacionLaboral.Items.AddRange(new object[] {
            "Activo",
            "Baja",
            "Vacaciones"});
            this.comboBoxFiltrarSituacionLaboral.Location = new System.Drawing.Point(1036, 483);
            this.comboBoxFiltrarSituacionLaboral.Name = "comboBoxFiltrarSituacionLaboral";
            this.comboBoxFiltrarSituacionLaboral.Size = new System.Drawing.Size(132, 24);
            this.comboBoxFiltrarSituacionLaboral.TabIndex = 7;
            // 
            // buttonFiltrarSituacionLaboral
            // 
            this.buttonFiltrarSituacionLaboral.Location = new System.Drawing.Point(1201, 474);
            this.buttonFiltrarSituacionLaboral.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarSituacionLaboral.Name = "buttonFiltrarSituacionLaboral";
            this.buttonFiltrarSituacionLaboral.Size = new System.Drawing.Size(143, 48);
            this.buttonFiltrarSituacionLaboral.TabIndex = 8;
            this.buttonFiltrarSituacionLaboral.Text = "Filtrar por situación laboral";
            this.buttonFiltrarSituacionLaboral.UseVisualStyleBackColor = true;
            this.buttonFiltrarSituacionLaboral.Click += new System.EventHandler(this.buttonFiltrarSituacionLaboral_Click);
            // 
            // buttonFiltrarDni
            // 
            this.buttonFiltrarDni.Location = new System.Drawing.Point(1201, 279);
            this.buttonFiltrarDni.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarDni.Name = "buttonFiltrarDni";
            this.buttonFiltrarDni.Size = new System.Drawing.Size(143, 28);
            this.buttonFiltrarDni.TabIndex = 4;
            this.buttonFiltrarDni.Text = "Filtrar por DNI";
            this.buttonFiltrarDni.UseVisualStyleBackColor = true;
            this.buttonFiltrarDni.Click += new System.EventHandler(this.buttonFiltrarDni_Click);
            // 
            // textBoxFiltrarDNI
            // 
            this.textBoxFiltrarDNI.Location = new System.Drawing.Point(1036, 281);
            this.textBoxFiltrarDNI.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarDNI.Name = "textBoxFiltrarDNI";
            this.textBoxFiltrarDNI.Size = new System.Drawing.Size(132, 22);
            this.textBoxFiltrarDNI.TabIndex = 3;
            // 
            // buttonFiltrarNombre
            // 
            this.buttonFiltrarNombre.Location = new System.Drawing.Point(1201, 180);
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
            this.textBoxFiltrarNombre.Location = new System.Drawing.Point(1036, 184);
            this.textBoxFiltrarNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltrarNombre.Name = "textBoxFiltrarNombre";
            this.textBoxFiltrarNombre.Size = new System.Drawing.Size(132, 22);
            this.textBoxFiltrarNombre.TabIndex = 1;
            // 
            // comboBoxFiltrarPuesto
            // 
            this.comboBoxFiltrarPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarPuesto.FormattingEnabled = true;
            this.comboBoxFiltrarPuesto.Items.AddRange(new object[] {
            "Maestro de obra",
            "Capataz",
            "Albañil"});
            this.comboBoxFiltrarPuesto.Location = new System.Drawing.Point(1036, 373);
            this.comboBoxFiltrarPuesto.Name = "comboBoxFiltrarPuesto";
            this.comboBoxFiltrarPuesto.Size = new System.Drawing.Size(132, 24);
            this.comboBoxFiltrarPuesto.TabIndex = 5;
            // 
            // buttonFiltrarPuesto
            // 
            this.buttonFiltrarPuesto.Location = new System.Drawing.Point(1201, 369);
            this.buttonFiltrarPuesto.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFiltrarPuesto.Name = "buttonFiltrarPuesto";
            this.buttonFiltrarPuesto.Size = new System.Drawing.Size(143, 31);
            this.buttonFiltrarPuesto.TabIndex = 6;
            this.buttonFiltrarPuesto.Text = "Filtrar por puesto";
            this.buttonFiltrarPuesto.UseVisualStyleBackColor = true;
            this.buttonFiltrarPuesto.Click += new System.EventHandler(this.buttonFiltrarPuesto_Click);
            // 
            // InformeEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1396, 754);
            this.Controls.Add(this.comboBoxFiltrarPuesto);
            this.Controls.Add(this.buttonFiltrarPuesto);
            this.Controls.Add(this.comboBoxFiltrarSituacionLaboral);
            this.Controls.Add(this.buttonFiltrarSituacionLaboral);
            this.Controls.Add(this.buttonFiltrarDni);
            this.Controls.Add(this.textBoxFiltrarDNI);
            this.Controls.Add(this.buttonFiltrarNombre);
            this.Controls.Add(this.textBoxFiltrarNombre);
            this.Controls.Add(this.buttonVolverInicio);
            this.Controls.Add(this.buttonQuitarFiltro);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InformeEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeEmpleados";
            this.Load += new System.EventHandler(this.InformeEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonQuitarFiltro;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource empleadoBindingSource;
        private RecoDueroDataSetTableAdapters.EmpleadoTableAdapter empleadoTableAdapter;
        private System.Windows.Forms.Button buttonVolverInicio;
        private System.Windows.Forms.ComboBox comboBoxFiltrarSituacionLaboral;
        private System.Windows.Forms.Button buttonFiltrarSituacionLaboral;
        private System.Windows.Forms.Button buttonFiltrarDni;
        private System.Windows.Forms.TextBox textBoxFiltrarDNI;
        private System.Windows.Forms.Button buttonFiltrarNombre;
        private System.Windows.Forms.TextBox textBoxFiltrarNombre;
        private System.Windows.Forms.ComboBox comboBoxFiltrarPuesto;
        private System.Windows.Forms.Button buttonFiltrarPuesto;
    }
}