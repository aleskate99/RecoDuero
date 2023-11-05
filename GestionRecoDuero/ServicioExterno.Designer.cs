namespace GestionRecoDuero
{
    partial class ServicioExterno
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
            System.Windows.Forms.Label idServicioExternoLabel;
            System.Windows.Forms.Label empresaLabel;
            System.Windows.Forms.Label telefonoLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label direccionLabel;
            System.Windows.Forms.Label tipoLabel;
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label costeLabel;
            System.Windows.Forms.Label duracionServicioLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicioExterno));
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.servicioExternoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicioExternoTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.ServicioExternoTableAdapter();
            this.tableAdapterManager = new GestionRecoDuero.RecoDueroDataSetTableAdapters.TableAdapterManager();
            this.idServicioExternoLabel1 = new System.Windows.Forms.Label();
            this.empresaTextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.tipoComboBox = new System.Windows.Forms.ComboBox();
            this.estadoComboBox = new System.Windows.Forms.ComboBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.costeTextBox = new System.Windows.Forms.TextBox();
            this.duracionServicioTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonInicio = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAnterior = new System.Windows.Forms.ToolStripButton();
            this.toolstripLabelContadorServicioExterno = new System.Windows.Forms.ToolStripLabel();
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
            this.toolStripComboBoxBuscarServiciosExternos = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBoxBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonVolverInicio = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            idServicioExternoLabel = new System.Windows.Forms.Label();
            empresaLabel = new System.Windows.Forms.Label();
            telefonoLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            direccionLabel = new System.Windows.Forms.Label();
            tipoLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            costeLabel = new System.Windows.Forms.Label();
            duracionServicioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicioExternoBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonVolverInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idServicioExternoLabel
            // 
            idServicioExternoLabel.AutoSize = true;
            idServicioExternoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idServicioExternoLabel.Location = new System.Drawing.Point(15, 54);
            idServicioExternoLabel.Name = "idServicioExternoLabel";
            idServicioExternoLabel.Size = new System.Drawing.Size(183, 22);
            idServicioExternoLabel.TabIndex = 1;
            idServicioExternoLabel.Text = "Id Servicio Externo *\r\n";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            empresaLabel.Location = new System.Drawing.Point(15, 110);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new System.Drawing.Size(95, 22);
            empresaLabel.TabIndex = 3;
            empresaLabel.Text = "Empresa *";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            telefonoLabel.Location = new System.Drawing.Point(16, 241);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new System.Drawing.Size(94, 22);
            telefonoLabel.TabIndex = 5;
            telefonoLabel.Text = "Teléfono *";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.Location = new System.Drawing.Point(16, 306);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(73, 22);
            emailLabel.TabIndex = 7;
            emailLabel.Text = "Email *";
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            direccionLabel.Location = new System.Drawing.Point(15, 175);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new System.Drawing.Size(90, 22);
            direccionLabel.TabIndex = 9;
            direccionLabel.Text = "Dirección";
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoLabel.Location = new System.Drawing.Point(15, 374);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(61, 22);
            tipoLabel.TabIndex = 11;
            tipoLabel.Text = "Tipo *";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            estadoLabel.Location = new System.Drawing.Point(16, 440);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(81, 22);
            estadoLabel.TabIndex = 13;
            estadoLabel.Text = "Estado *";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(656, 306);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(109, 22);
            descripcionLabel.TabIndex = 15;
            descripcionLabel.Text = "Descripción";
            // 
            // costeLabel
            // 
            costeLabel.AutoSize = true;
            costeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            costeLabel.Location = new System.Drawing.Point(656, 181);
            costeLabel.Name = "costeLabel";
            costeLabel.Size = new System.Drawing.Size(71, 22);
            costeLabel.TabIndex = 17;
            costeLabel.Text = "Coste *";
            // 
            // duracionServicioLabel
            // 
            duracionServicioLabel.AutoSize = true;
            duracionServicioLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            duracionServicioLabel.Location = new System.Drawing.Point(656, 242);
            duracionServicioLabel.Name = "duracionServicioLabel";
            duracionServicioLabel.Size = new System.Drawing.Size(174, 22);
            duracionServicioLabel.TabIndex = 19;
            duracionServicioLabel.Text = "Duración Servicio *";
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClienteTableAdapter = null;
            this.tableAdapterManager.EmpleadoTableAdapter = null;
            this.tableAdapterManager.FacturaTableAdapter = null;
            this.tableAdapterManager.MaterialTableAdapter = null;
            this.tableAdapterManager.ObraTableAdapter = null;
            this.tableAdapterManager.PresupuestoTableAdapter = null;
            this.tableAdapterManager.ServicioExternoTableAdapter = this.servicioExternoTableAdapter;
            this.tableAdapterManager.UpdateOrder = GestionRecoDuero.RecoDueroDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuarioTableAdapter = null;
            this.tableAdapterManager.VehiculoTableAdapter = null;
            // 
            // idServicioExternoLabel1
            // 
            this.idServicioExternoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "IdServicioExterno", true));
            this.idServicioExternoLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idServicioExternoLabel1.Location = new System.Drawing.Point(239, 54);
            this.idServicioExternoLabel1.Name = "idServicioExternoLabel1";
            this.idServicioExternoLabel1.Size = new System.Drawing.Size(121, 23);
            this.idServicioExternoLabel1.TabIndex = 2;
            this.idServicioExternoLabel1.Text = "label1";
            // 
            // empresaTextBox
            // 
            this.empresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Empresa", true));
            this.empresaTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresaTextBox.Location = new System.Drawing.Point(243, 107);
            this.empresaTextBox.Name = "empresaTextBox";
            this.empresaTextBox.Size = new System.Drawing.Size(253, 30);
            this.empresaTextBox.TabIndex = 1;
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Telefono", true));
            this.telefonoTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoTextBox.Location = new System.Drawing.Point(244, 238);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(253, 30);
            this.telefonoTextBox.TabIndex = 3;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Email", true));
            this.emailTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.Location = new System.Drawing.Point(244, 303);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(253, 30);
            this.emailTextBox.TabIndex = 4;
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Direccion", true));
            this.direccionTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionTextBox.Location = new System.Drawing.Point(243, 172);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(253, 30);
            this.direccionTextBox.TabIndex = 2;
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Tipo", true));
            this.tipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Items.AddRange(new object[] {
            "Transporte",
            "Materiales",
            "Consultoría",
            "Mantenimiento"});
            this.tipoComboBox.Location = new System.Drawing.Point(243, 371);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(253, 30);
            this.tipoComboBox.TabIndex = 5;
            // 
            // estadoComboBox
            // 
            this.estadoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Estado", true));
            this.estadoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estadoComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoComboBox.FormattingEnabled = true;
            this.estadoComboBox.Items.AddRange(new object[] {
            "En curso",
            "Completado",
            "Pendiente",
            "Cancelado"});
            this.estadoComboBox.Location = new System.Drawing.Point(244, 437);
            this.estadoComboBox.Name = "estadoComboBox";
            this.estadoComboBox.Size = new System.Drawing.Size(253, 30);
            this.estadoComboBox.TabIndex = 6;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Descripcion", true));
            this.descripcionTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionTextBox.Location = new System.Drawing.Point(878, 307);
            this.descripcionTextBox.Multiline = true;
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(249, 152);
            this.descripcionTextBox.TabIndex = 9;
            // 
            // costeTextBox
            // 
            this.costeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "Coste", true));
            this.costeTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costeTextBox.Location = new System.Drawing.Point(878, 181);
            this.costeTextBox.Name = "costeTextBox";
            this.costeTextBox.Size = new System.Drawing.Size(249, 30);
            this.costeTextBox.TabIndex = 7;
            // 
            // duracionServicioTextBox
            // 
            this.duracionServicioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.servicioExternoBindingSource, "DuracionServicio", true));
            this.duracionServicioTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duracionServicioTextBox.Location = new System.Drawing.Point(878, 243);
            this.duracionServicioTextBox.Name = "duracionServicioTextBox";
            this.duracionServicioTextBox.Size = new System.Drawing.Size(249, 30);
            this.duracionServicioTextBox.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonInicio,
            this.toolStripButtonAnterior,
            this.toolstripLabelContadorServicioExterno,
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
            this.toolStripComboBoxBuscarServiciosExternos,
            this.toolStripTextBoxBuscar,
            this.toolStripButtonBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1341, 28);
            this.toolStrip1.TabIndex = 34;
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
            // toolstripLabelContadorServicioExterno
            // 
            this.toolstripLabelContadorServicioExterno.Name = "toolstripLabelContadorServicioExterno";
            this.toolstripLabelContadorServicioExterno.Size = new System.Drawing.Size(111, 25);
            this.toolstripLabelContadorServicioExterno.Text = "toolStripLabel1";
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
            this.toolStripButtonAnadir.ToolTipText = "Añadir servicio externo";
            this.toolStripButtonAnadir.Click += new System.EventHandler(this.toolStripButtonAnadir_Click);
            // 
            // toolStripButtonEliminar
            // 
            this.toolStripButtonEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEliminar.Image")));
            this.toolStripButtonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliminar.Name = "toolStripButtonEliminar";
            this.toolStripButtonEliminar.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonEliminar.ToolTipText = "Eliminar servicio externo";
            this.toolStripButtonEliminar.Click += new System.EventHandler(this.toolStripButtonEliminar_Click);
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditar.Image")));
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(29, 25);
            this.toolStripButtonEditar.ToolTipText = "Editar servicio externo";
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
            // toolStripComboBoxBuscarServiciosExternos
            // 
            this.toolStripComboBoxBuscarServiciosExternos.Items.AddRange(new object[] {
            "Nombre"});
            this.toolStripComboBoxBuscarServiciosExternos.Name = "toolStripComboBoxBuscarServiciosExternos";
            this.toolStripComboBoxBuscarServiciosExternos.Size = new System.Drawing.Size(160, 28);
            this.toolStripComboBoxBuscarServiciosExternos.Text = "Buscar servicio";
            this.toolStripComboBoxBuscarServiciosExternos.ToolTipText = "Seleccione mediante que campo desea buscar el servicio externo\r\n";
            // 
            // toolStripTextBoxBuscar
            // 
            this.toolStripTextBoxBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxBuscar.Name = "toolStripTextBoxBuscar";
            this.toolStripTextBoxBuscar.Size = new System.Drawing.Size(132, 28);
            this.toolStripTextBoxBuscar.ToolTipText = "Escribe el servicio externo que desee buscar";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 768);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1341, 26);
            this.statusStrip1.TabIndex = 35;
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
            this.buttonCancelar.Location = new System.Drawing.Point(973, 554);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(183, 80);
            this.buttonCancelar.TabIndex = 11;
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
            this.buttonAceptar.Location = new System.Drawing.Point(725, 554);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(183, 80);
            this.buttonAceptar.TabIndex = 10;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonVolverInicio
            // 
            this.buttonVolverInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVolverInicio.Image = ((System.Drawing.Image)(resources.GetObject("buttonVolverInicio.Image")));
            this.buttonVolverInicio.Location = new System.Drawing.Point(1245, 126);
            this.buttonVolverInicio.Name = "buttonVolverInicio";
            this.buttonVolverInicio.Size = new System.Drawing.Size(60, 54);
            this.buttonVolverInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonVolverInicio.TabIndex = 40;
            this.buttonVolverInicio.TabStop = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1140, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 60;
            this.label1.Text = "meses";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(idServicioExternoLabel);
            this.groupBox1.Controls.Add(this.estadoComboBox);
            this.groupBox1.Controls.Add(estadoLabel);
            this.groupBox1.Controls.Add(this.tipoComboBox);
            this.groupBox1.Controls.Add(tipoLabel);
            this.groupBox1.Controls.Add(this.direccionTextBox);
            this.groupBox1.Controls.Add(direccionLabel);
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Controls.Add(this.idServicioExternoLabel1);
            this.groupBox1.Controls.Add(emailLabel);
            this.groupBox1.Controls.Add(empresaLabel);
            this.groupBox1.Controls.Add(this.telefonoTextBox);
            this.groupBox1.Controls.Add(this.empresaTextBox);
            this.groupBox1.Controls.Add(telefonoLabel);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(34, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 508);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del servicio externo";
            // 
            // ServicioExterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 794);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonVolverInicio);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(descripcionLabel);
            this.Controls.Add(this.descripcionTextBox);
            this.Controls.Add(costeLabel);
            this.Controls.Add(this.costeTextBox);
            this.Controls.Add(duracionServicioLabel);
            this.Controls.Add(this.duracionServicioTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServicioExterno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServicioExterno";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServicioExterno_FormClosed);
            this.Load += new System.EventHandler(this.ServicioExterno_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServicioExterno_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicioExternoBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonVolverInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource servicioExternoBindingSource;
        private RecoDueroDataSetTableAdapters.ServicioExternoTableAdapter servicioExternoTableAdapter;
        private RecoDueroDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label idServicioExternoLabel1;
        private System.Windows.Forms.TextBox empresaTextBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.ComboBox tipoComboBox;
        private System.Windows.Forms.ComboBox estadoComboBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox costeTextBox;
        private System.Windows.Forms.TextBox duracionServicioTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonInicio;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnterior;
        private System.Windows.Forms.ToolStripLabel toolstripLabelContadorServicioExterno;
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
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxBuscarServiciosExternos;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxBuscar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.PictureBox buttonVolverInicio;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}