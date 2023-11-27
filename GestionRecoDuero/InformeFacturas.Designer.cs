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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeFacturas));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.buttonVolverInicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.buttonVolverInicio.UseVisualStyleBackColor = false;
            this.buttonVolverInicio.Click += new System.EventHandler(this.buttonVolverInicio_Click);
            // 
            // InformeFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1359, 758);
            this.Controls.Add(this.buttonVolverInicio);
            this.helpProvider1.SetHelpKeyword(this, "17");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformeFacturas";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeFacturas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button buttonVolverInicio;
    }
}