namespace GestionRecoDuero
{
    partial class Empleado
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
            System.Windows.Forms.Label idEmpleadoLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label apellidosLabel;
            System.Windows.Forms.Label generoLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label puestoLabel;
            System.Windows.Forms.Label salarioLabel;
            System.Windows.Forms.Label telefonoLabel;
            System.Windows.Forms.Label situacionLaboralLabel;
            System.Windows.Forms.Label dNILabel;
            System.Windows.Forms.Label imagenLabel;
            System.Windows.Forms.Label fechaNacimientoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleado));
            this.buttonVolverInicio = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaNacimientoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.empleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.dNITextBox = new System.Windows.Forms.TextBox();
            this.generoComboBox = new System.Windows.Forms.ComboBox();
            this.idEmpleadoLabel1 = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.apellidosTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.salarioLabel1 = new System.Windows.Forms.Label();
            this.situacionLaboralComboBox = new System.Windows.Forms.ComboBox();
            this.puestoComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonInicio = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAnterior = new System.Windows.Forms.ToolStripButton();
            this.toolstripLabelContadorEmpleados = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonSiguiente = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFinal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAnadir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInforme = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxBuscarEmpleados = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBoxBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imagenPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.empleadoTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.EmpleadoTableAdapter();
            this.tableAdapterManager = new GestionRecoDuero.RecoDueroDataSetTableAdapters.TableAdapterManager();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            idEmpleadoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            apellidosLabel = new System.Windows.Forms.Label();
            generoLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            puestoLabel = new System.Windows.Forms.Label();
            salarioLabel = new System.Windows.Forms.Label();
            telefonoLabel = new System.Windows.Forms.Label();
            situacionLaboralLabel = new System.Windows.Forms.Label();
            dNILabel = new System.Windows.Forms.Label();
            imagenLabel = new System.Windows.Forms.Label();
            fechaNacimientoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.buttonVolverInicio)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // idEmpleadoLabel
            // 
            idEmpleadoLabel.AutoSize = true;
            idEmpleadoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idEmpleadoLabel.Location = new System.Drawing.Point(37, 43);
            idEmpleadoLabel.Name = "idEmpleadoLabel";
            idEmpleadoLabel.Size = new System.Drawing.Size(128, 22);
            idEmpleadoLabel.TabIndex = 0;
            idEmpleadoLabel.Text = "Id Empleado *";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(37, 92);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(88, 22);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre *";
            // 
            // apellidosLabel
            // 
            apellidosLabel.AutoSize = true;
            apellidosLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            apellidosLabel.Location = new System.Drawing.Point(37, 145);
            apellidosLabel.Name = "apellidosLabel";
            apellidosLabel.Size = new System.Drawing.Size(101, 22);
            apellidosLabel.TabIndex = 4;
            apellidosLabel.Text = "Apellidos *";
            // 
            // generoLabel
            // 
            generoLabel.AutoSize = true;
            generoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            generoLabel.Location = new System.Drawing.Point(37, 423);
            generoLabel.Name = "generoLabel";
            generoLabel.Size = new System.Drawing.Size(84, 22);
            generoLabel.TabIndex = 6;
            generoLabel.Text = "Género *";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.Location = new System.Drawing.Point(37, 371);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(58, 22);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Email";
            // 
            // puestoLabel
            // 
            puestoLabel.AutoSize = true;
            puestoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            puestoLabel.Location = new System.Drawing.Point(27, 43);
            puestoLabel.Name = "puestoLabel";
            puestoLabel.Size = new System.Drawing.Size(80, 22);
            puestoLabel.TabIndex = 10;
            puestoLabel.Text = "Puesto *";
            // 
            // salarioLabel
            // 
            salarioLabel.AutoSize = true;
            salarioLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            salarioLabel.Location = new System.Drawing.Point(32, 149);
            salarioLabel.Name = "salarioLabel";
            salarioLabel.Size = new System.Drawing.Size(85, 22);
            salarioLabel.TabIndex = 12;
            salarioLabel.Text = "Salario *";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            telefonoLabel.Location = new System.Drawing.Point(37, 315);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new System.Drawing.Size(94, 22);
            telefonoLabel.TabIndex = 14;
            telefonoLabel.Text = "Teléfono *";
            // 
            // situacionLaboralLabel
            // 
            situacionLaboralLabel.AutoSize = true;
            situacionLaboralLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            situacionLaboralLabel.Location = new System.Drawing.Point(27, 96);
            situacionLaboralLabel.Name = "situacionLaboralLabel";
            situacionLaboralLabel.Size = new System.Drawing.Size(167, 22);
            situacionLaboralLabel.TabIndex = 16;
            situacionLaboralLabel.Text = "Situación laboral *";
            // 
            // dNILabel
            // 
            dNILabel.AutoSize = true;
            dNILabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dNILabel.Location = new System.Drawing.Point(37, 202);
            dNILabel.Name = "dNILabel";
            dNILabel.Size = new System.Drawing.Size(59, 22);
            dNILabel.TabIndex = 18;
            dNILabel.Text = "DNI *";
            // 
            // imagenLabel
            // 
            imagenLabel.AutoSize = true;
            imagenLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            imagenLabel.Location = new System.Drawing.Point(735, 377);
            imagenLabel.Name = "imagenLabel";
            imagenLabel.Size = new System.Drawing.Size(66, 22);
            imagenLabel.TabIndex = 20;
            imagenLabel.Text = "Imágen";
            // 
            // fechaNacimientoLabel
            // 
            fechaNacimientoLabel.AutoSize = true;
            fechaNacimientoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaNacimientoLabel.Location = new System.Drawing.Point(37, 259);
            fechaNacimientoLabel.Name = "fechaNacimientoLabel";
            fechaNacimientoLabel.Size = new System.Drawing.Size(173, 22);
            fechaNacimientoLabel.TabIndex = 22;
            fechaNacimientoLabel.Text = "Fecha Nacimiento *";
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1297, 81);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(60, 54);
            this.buttonVolverInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonVolverInicio.TabIndex = 9;
            this.buttonVolverInicio.TabStop = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.fechaNacimientoDateTimePicker);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.dNITextBox);
            this.groupBox1.Controls.Add(fechaNacimientoLabel);
            this.groupBox1.Controls.Add(dNILabel);
            this.groupBox1.Controls.Add(generoLabel);
            this.groupBox1.Controls.Add(idEmpleadoLabel);
            this.groupBox1.Controls.Add(this.generoComboBox);
            this.groupBox1.Controls.Add(this.idEmpleadoLabel1);
            this.groupBox1.Controls.Add(apellidosLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(emailLabel);
            this.groupBox1.Controls.Add(this.apellidosTextBox);
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Controls.Add(telefonoLabel);
            this.groupBox1.Controls.Add(this.telefonoTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 486);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del empeado";
            // 
            // fechaNacimientoDateTimePicker
            // 
            this.fechaNacimientoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.empleadoBindingSource, "FechaNacimiento", true));
            this.fechaNacimientoDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimientoDateTimePicker.Location = new System.Drawing.Point(223, 255);
            this.fechaNacimientoDateTimePicker.Name = "fechaNacimientoDateTimePicker";
            this.fechaNacimientoDateTimePicker.Size = new System.Drawing.Size(335, 30);
            this.fechaNacimientoDateTimePicker.TabIndex = 4;
            this.fechaNacimientoDateTimePicker.ValueChanged += new System.EventHandler(this.fechaNacimientoDateTimePicker_ValueChanged);
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
            // dNITextBox
            // 
            this.dNITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "DNI", true));
            this.dNITextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dNITextBox.Location = new System.Drawing.Point(223, 199);
            this.dNITextBox.Name = "dNITextBox";
            this.dNITextBox.Size = new System.Drawing.Size(335, 30);
            this.dNITextBox.TabIndex = 3;
            // 
            // generoComboBox
            // 
            this.generoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Genero", true));
            this.generoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generoComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generoComboBox.FormattingEnabled = true;
            this.generoComboBox.Items.AddRange(new object[] {
            "Masculino",
            "Femenino",
            "Otro"});
            this.generoComboBox.Location = new System.Drawing.Point(223, 419);
            this.generoComboBox.Name = "generoComboBox";
            this.generoComboBox.Size = new System.Drawing.Size(335, 30);
            this.generoComboBox.TabIndex = 7;
            // 
            // idEmpleadoLabel1
            // 
            this.idEmpleadoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "IdEmpleado", true));
            this.idEmpleadoLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idEmpleadoLabel1.Location = new System.Drawing.Point(219, 43);
            this.idEmpleadoLabel1.Name = "idEmpleadoLabel1";
            this.idEmpleadoLabel1.Size = new System.Drawing.Size(200, 23);
            this.idEmpleadoLabel1.TabIndex = 1;
            this.idEmpleadoLabel1.Text = "label1";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Nombre", true));
            this.nombreTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreTextBox.Location = new System.Drawing.Point(223, 88);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(335, 30);
            this.nombreTextBox.TabIndex = 1;
            // 
            // apellidosTextBox
            // 
            this.apellidosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Apellidos", true));
            this.apellidosTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellidosTextBox.Location = new System.Drawing.Point(223, 141);
            this.apellidosTextBox.Name = "apellidosTextBox";
            this.apellidosTextBox.Size = new System.Drawing.Size(335, 30);
            this.apellidosTextBox.TabIndex = 2;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Email", true));
            this.emailTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.Location = new System.Drawing.Point(223, 369);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(335, 30);
            this.emailTextBox.TabIndex = 6;
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Telefono", true));
            this.telefonoTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoTextBox.Location = new System.Drawing.Point(223, 311);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(335, 30);
            this.telefonoTextBox.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.salarioLabel1);
            this.groupBox2.Controls.Add(this.situacionLaboralComboBox);
            this.groupBox2.Controls.Add(situacionLaboralLabel);
            this.groupBox2.Controls.Add(puestoLabel);
            this.groupBox2.Controls.Add(this.puestoComboBox);
            this.groupBox2.Controls.Add(salarioLabel);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(703, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 229);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de cobro";
            // 
            // salarioLabel1
            // 
            this.salarioLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Salario", true));
            this.salarioLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salarioLabel1.Location = new System.Drawing.Point(212, 149);
            this.salarioLabel1.Name = "salarioLabel1";
            this.salarioLabel1.Size = new System.Drawing.Size(100, 23);
            this.salarioLabel1.TabIndex = 17;
            this.salarioLabel1.Text = "label1";
            // 
            // situacionLaboralComboBox
            // 
            this.situacionLaboralComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "SituacionLaboral", true));
            this.situacionLaboralComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.situacionLaboralComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.situacionLaboralComboBox.FormattingEnabled = true;
            this.situacionLaboralComboBox.Items.AddRange(new object[] {
            "Activo",
            "Baja",
            "Vacaciones"});
            this.situacionLaboralComboBox.Location = new System.Drawing.Point(216, 93);
            this.situacionLaboralComboBox.Name = "situacionLaboralComboBox";
            this.situacionLaboralComboBox.Size = new System.Drawing.Size(254, 30);
            this.situacionLaboralComboBox.TabIndex = 9;
            // 
            // puestoComboBox
            // 
            this.puestoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empleadoBindingSource, "Puesto", true));
            this.puestoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.puestoComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puestoComboBox.FormattingEnabled = true;
            this.puestoComboBox.Items.AddRange(new object[] {
            "Maestro de obra",
            "Capataz",
            "Albañil"});
            this.puestoComboBox.Location = new System.Drawing.Point(216, 40);
            this.puestoComboBox.Name = "puestoComboBox";
            this.puestoComboBox.Size = new System.Drawing.Size(254, 30);
            this.puestoComboBox.TabIndex = 8;
            this.puestoComboBox.SelectedIndexChanged += new System.EventHandler(this.puestoComboBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonInicio,
            this.toolStripButtonAnterior,
            this.toolstripLabelContadorEmpleados,
            this.toolStripButtonSiguiente,
            this.toolStripButtonFinal,
            this.toolStripSeparator1,
            this.toolStripButtonAnadir,
            this.toolStripButtonEliminar,
            this.toolStripButtonEditar,
            this.toolStripSeparator2,
            this.toolStripButtonGuardar,
            this.toolStripButtonImprimir,
            this.toolStripButtonInforme,
            this.toolStripSeparator3,
            this.toolStripComboBoxBuscarEmpleados,
            this.toolStripTextBoxBuscar,
            this.toolStripButtonBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1357, 28);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonInicio
            // 
            this.toolStripButtonInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInicio.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInicio.Image")));
            this.toolStripButtonInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInicio.Name = "toolStripButtonInicio";
            this.toolStripButtonInicio.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonInicio.ToolTipText = "Ir al principio";
            this.toolStripButtonInicio.Click += new System.EventHandler(this.toolStripButtonInicio_Click);
            // 
            // toolStripButtonAnterior
            // 
            this.toolStripButtonAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnterior.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAnterior.Image")));
            this.toolStripButtonAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnterior.Name = "toolStripButtonAnterior";
            this.toolStripButtonAnterior.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonAnterior.ToolTipText = "Anterior";
            this.toolStripButtonAnterior.Click += new System.EventHandler(this.toolStripButtonAnterior_Click);
            // 
            // toolstripLabelContadorEmpleados
            // 
            this.toolstripLabelContadorEmpleados.Name = "toolstripLabelContadorEmpleados";
            this.toolstripLabelContadorEmpleados.Size = new System.Drawing.Size(111, 25);
            this.toolstripLabelContadorEmpleados.Text = "toolStripLabel1";
            // 
            // toolStripButtonSiguiente
            // 
            this.toolStripButtonSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSiguiente.Image")));
            this.toolStripButtonSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSiguiente.Name = "toolStripButtonSiguiente";
            this.toolStripButtonSiguiente.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonSiguiente.ToolTipText = "Siguiente";
            this.toolStripButtonSiguiente.Click += new System.EventHandler(this.toolStripButtonSiguiente_Click);
            // 
            // toolStripButtonFinal
            // 
            this.toolStripButtonFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFinal.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFinal.Image")));
            this.toolStripButtonFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFinal.Name = "toolStripButtonFinal";
            this.toolStripButtonFinal.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonFinal.ToolTipText = "Ir al final";
            this.toolStripButtonFinal.Click += new System.EventHandler(this.toolStripButtonFinal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButtonAnadir
            // 
            this.toolStripButtonAnadir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnadir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAnadir.Image")));
            this.toolStripButtonAnadir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnadir.Name = "toolStripButtonAnadir";
            this.toolStripButtonAnadir.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonAnadir.ToolTipText = "Añadir empleado";
            this.toolStripButtonAnadir.Click += new System.EventHandler(this.toolStripButtonAnadir_Click);
            // 
            // toolStripButtonEliminar
            // 
            this.toolStripButtonEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEliminar.Image")));
            this.toolStripButtonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliminar.Name = "toolStripButtonEliminar";
            this.toolStripButtonEliminar.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonEliminar.ToolTipText = "Eliminar empleado";
            this.toolStripButtonEliminar.Click += new System.EventHandler(this.toolStripButtonEliminar_Click);
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonEditar.ToolTipText = "Editar empleado";
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButtonGuardar
            // 
            this.toolStripButtonGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGuardar.Image")));
            this.toolStripButtonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGuardar.Name = "toolStripButtonGuardar";
            this.toolStripButtonGuardar.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonGuardar.ToolTipText = "Guardar ";
            this.toolStripButtonGuardar.Click += new System.EventHandler(this.toolStripButtonGuardar_Click);
            // 
            // toolStripButtonImprimir
            // 
            this.toolStripButtonImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImprimir.Image")));
            this.toolStripButtonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImprimir.Name = "toolStripButtonImprimir";
            this.toolStripButtonImprimir.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonImprimir.ToolTipText = "Imprimir ";
            this.toolStripButtonImprimir.Click += new System.EventHandler(this.toolStripButtonImprimir_Click);
            // 
            // toolStripButtonInforme
            // 
            this.toolStripButtonInforme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInforme.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInforme.Image")));
            this.toolStripButtonInforme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInforme.Name = "toolStripButtonInforme";
            this.toolStripButtonInforme.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonInforme.ToolTipText = "Informe";
            this.toolStripButtonInforme.Click += new System.EventHandler(this.toolStripButtonInforme_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripComboBoxBuscarEmpleados
            // 
            this.toolStripComboBoxBuscarEmpleados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripComboBoxBuscarEmpleados.Items.AddRange(new object[] {
            "Id",
            "DNI",
            "Nombre"});
            this.toolStripComboBoxBuscarEmpleados.Name = "toolStripComboBoxBuscarEmpleados";
            this.toolStripComboBoxBuscarEmpleados.Size = new System.Drawing.Size(160, 28);
            this.toolStripComboBoxBuscarEmpleados.Text = "Buscar empleado";
            this.toolStripComboBoxBuscarEmpleados.ToolTipText = "Seleccione mediante que campo desea buscar al empleado";
            // 
            // toolStripTextBoxBuscar
            // 
            this.toolStripTextBoxBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxBuscar.Name = "toolStripTextBoxBuscar";
            this.toolStripTextBoxBuscar.Size = new System.Drawing.Size(132, 28);
            this.toolStripTextBoxBuscar.ToolTipText = "Escribe el empleado que desee buscar";
            // 
            // toolStripButtonBuscar
            // 
            this.toolStripButtonBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBuscar.Image")));
            this.toolStripButtonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBuscar.Name = "toolStripButtonBuscar";
            this.toolStripButtonBuscar.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonBuscar.ToolTipText = "Buscar";
            this.toolStripButtonBuscar.Click += new System.EventHandler(this.toolStripButtonBuscar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 759);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1357, 26);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancelar.FlatAppearance.BorderSize = 0;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.Image")));
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(1065, 633);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(183, 80);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.Transparent;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAceptar.Image")));
            this.buttonAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAceptar.Location = new System.Drawing.Point(820, 633);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(183, 80);
            this.buttonAceptar.TabIndex = 11;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // imagenPictureBox
            // 
            this.imagenPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.imagenPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagenPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imagenPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.empleadoBindingSource, "Imagen", true));
            this.imagenPictureBox.ErrorImage = null;
            this.imagenPictureBox.InitialImage = null;
            this.imagenPictureBox.Location = new System.Drawing.Point(919, 377);
            this.imagenPictureBox.Name = "imagenPictureBox";
            this.imagenPictureBox.Size = new System.Drawing.Size(277, 231);
            this.imagenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagenPictureBox.TabIndex = 21;
            this.imagenPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.imagenPictureBox, "Haga clic para insertar la imágen");
            this.imagenPictureBox.Click += new System.EventHandler(this.imagenPictureBox_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // empleadoTableAdapter
            // 
            this.empleadoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClienteTableAdapter = null;
            this.tableAdapterManager.DetalleFacturaTableAdapter = null;
            this.tableAdapterManager.DetallePresupuestoTableAdapter = null;
            this.tableAdapterManager.EmpleadoTableAdapter = this.empleadoTableAdapter;
            this.tableAdapterManager.FacturaTableAdapter = null;
            this.tableAdapterManager.MaterialTableAdapter = null;
            this.tableAdapterManager.ObraTableAdapter = null;
            this.tableAdapterManager.PresupuestoTableAdapter = null;
            this.tableAdapterManager.ServicioExternoTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = GestionRecoDuero.RecoDueroDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuarioTableAdapter = null;
            this.tableAdapterManager.VehiculoTableAdapter = null;
            // 
            // Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 785);
            this.Controls.Add(this.imagenPictureBox);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(imagenLabel);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonVolverInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Empleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Empleado_FormClosing);
            this.Load += new System.EventHandler(this.Empleado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Empleado_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.buttonVolverInicio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox buttonVolverInicio;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource empleadoBindingSource;
        private RecoDueroDataSetTableAdapters.EmpleadoTableAdapter empleadoTableAdapter;
        private RecoDueroDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonInicio;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnterior;
        private System.Windows.Forms.ToolStripLabel toolstripLabelContadorEmpleados;
        private System.Windows.Forms.ToolStripButton toolStripButtonSiguiente;
        private System.Windows.Forms.ToolStripButton toolStripButtonFinal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnadir;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonGuardar;
        private System.Windows.Forms.ToolStripButton toolStripButtonImprimir;
        private System.Windows.Forms.ToolStripButton toolStripButtonInforme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxBuscarEmpleados;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxBuscar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label idEmpleadoLabel1;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox apellidosTextBox;
        private System.Windows.Forms.ComboBox generoComboBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.ComboBox puestoComboBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.ComboBox situacionLaboralComboBox;
        private System.Windows.Forms.TextBox dNITextBox;
        private System.Windows.Forms.PictureBox imagenPictureBox;
        private System.Windows.Forms.DateTimePicker fechaNacimientoDateTimePicker;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label salarioLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}