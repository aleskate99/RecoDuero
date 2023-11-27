namespace GestionRecoDuero
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recoDueroDataSet = new GestionRecoDuero.RecoDueroDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelPass = new System.Windows.Forms.LinkLabel();
            this.buttonAcceder = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.buttonMostrarPass = new System.Windows.Forms.Button();
            this.usuarioTableAdapter = new GestionRecoDuero.RecoDueroDataSetTableAdapters.UsuarioTableAdapter();
            this.tableAdapterManager = new GestionRecoDuero.RecoDueroDataSetTableAdapters.TableAdapterManager();
            this.linkLabelRegistro = new System.Windows.Forms.LinkLabel();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 424);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.emailTextBox.Location = new System.Drawing.Point(471, 139);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(335, 25);
            this.emailTextBox.TabIndex = 1;
            this.emailTextBox.Text = "EMAIL";
            this.emailTextBox.Enter += new System.EventHandler(this.emailTextBox_Enter);
            this.emailTextBox.Leave += new System.EventHandler(this.emailTextBox_Leave);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.passwordTextBox.Location = new System.Drawing.Point(471, 197);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(335, 25);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "CONTRASEÑA";
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataMember = "Usuario";
            this.usuarioBindingSource.DataSource = this.recoDueroDataSet;
            // 
            // recoDueroDataSet
            // 
            this.recoDueroDataSet.DataSetName = "RecoDueroDataSet";
            this.recoDueroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(536, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "LOGIN";
            // 
            // linkLabelPass
            // 
            this.linkLabelPass.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.linkLabelPass.AutoSize = true;
            this.linkLabelPass.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabelPass.Location = new System.Drawing.Point(521, 356);
            this.linkLabelPass.Name = "linkLabelPass";
            this.linkLabelPass.Size = new System.Drawing.Size(179, 16);
            this.linkLabelPass.TabIndex = 5;
            this.linkLabelPass.TabStop = true;
            this.linkLabelPass.Text = "¿Ha olvidado la contraseña?";
            this.linkLabelPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPass_LinkClicked);
            // 
            // buttonAcceder
            // 
            this.buttonAcceder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonAcceder.FlatAppearance.BorderSize = 0;
            this.buttonAcceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.buttonAcceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcceder.ForeColor = System.Drawing.Color.DimGray;
            this.buttonAcceder.Location = new System.Drawing.Point(362, 294);
            this.buttonAcceder.Name = "buttonAcceder";
            this.buttonAcceder.Size = new System.Drawing.Size(510, 50);
            this.buttonAcceder.TabIndex = 4;
            this.buttonAcceder.Text = "ACCEDER";
            this.buttonAcceder.UseVisualStyleBackColor = false;
            this.buttonAcceder.Click += new System.EventHandler(this.buttonAcceder_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(941, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(33, 41);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(902, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(33, 41);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // buttonMostrarPass
            // 
            this.buttonMostrarPass.BackColor = System.Drawing.Color.Transparent;
            this.buttonMostrarPass.FlatAppearance.BorderSize = 0;
            this.buttonMostrarPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMostrarPass.Image = ((System.Drawing.Image)(resources.GetObject("buttonMostrarPass.Image")));
            this.buttonMostrarPass.Location = new System.Drawing.Point(887, 184);
            this.buttonMostrarPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMostrarPass.Name = "buttonMostrarPass";
            this.buttonMostrarPass.Size = new System.Drawing.Size(59, 49);
            this.buttonMostrarPass.TabIndex = 3;
            this.buttonMostrarPass.UseVisualStyleBackColor = false;
            this.buttonMostrarPass.Click += new System.EventHandler(this.buttonMostrarPassAcceder_Click);
            // 
            // usuarioTableAdapter
            // 
            this.usuarioTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClienteTableAdapter = null;
            this.tableAdapterManager.DetalleFacturaTableAdapter = null;
            this.tableAdapterManager.DetallePresupuestoTableAdapter = null;
            this.tableAdapterManager.EmpleadoTableAdapter = null;
            this.tableAdapterManager.FacturaTableAdapter = null;
            this.tableAdapterManager.MaterialTableAdapter = null;
            this.tableAdapterManager.ObraTableAdapter = null;
            this.tableAdapterManager.PresupuestoTableAdapter = null;
            this.tableAdapterManager.ServicioExternoTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = GestionRecoDuero.RecoDueroDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuarioTableAdapter = this.usuarioTableAdapter;
            this.tableAdapterManager.VehiculoTableAdapter = null;
            // 
            // linkLabelRegistro
            // 
            this.linkLabelRegistro.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.linkLabelRegistro.AutoSize = true;
            this.linkLabelRegistro.ForeColor = System.Drawing.Color.DimGray;
            this.linkLabelRegistro.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabelRegistro.Location = new System.Drawing.Point(580, 388);
            this.linkLabelRegistro.Name = "linkLabelRegistro";
            this.linkLabelRegistro.Size = new System.Drawing.Size(77, 16);
            this.linkLabelRegistro.TabIndex = 6;
            this.linkLabelRegistro.TabStop = true;
            this.linkLabelRegistro.Text = "Registrarse";
            this.linkLabelRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegistro_LinkClicked);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "AyudaRecoDuero.chm";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(994, 424);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.linkLabelRegistro);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.buttonMostrarPass);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.buttonAcceder);
            this.Controls.Add(this.linkLabelPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.helpProvider1.SetHelpKeyword(this, "1");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Opacity = 0.9D;
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoDueroDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelPass;
        private System.Windows.Forms.Button buttonAcceder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Button buttonMostrarPass;
        private RecoDueroDataSet recoDueroDataSet;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private RecoDueroDataSetTableAdapters.UsuarioTableAdapter usuarioTableAdapter;
        private RecoDueroDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.LinkLabel linkLabelRegistro;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

