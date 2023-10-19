using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            Bordes.BordesRedondos(this);
            labelUsuario.Text = DatosSesion.Email;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana Login?", "Cerrar Sesión", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void pictureBoxSlide_Click(object sender, EventArgs e)
        {
            if (panelzquierda.Width == 200)
            {
                panelzquierda.Width = 70;
            }
            else
            {
                panelzquierda.Width = 200;
            }  
        }

        private void panelArriba_MouseDown(object sender, MouseEventArgs e)
        {
            MoverPantalla.ReleaseCapture();
            MoverPantalla.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelCentral.Controls.Count > 0)
            {
                this.panelCentral.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelCentral.Controls.Add(fh);
            this.panelCentral.Tag = fh;
            fh.Show();
        }

        private void buttonEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Empleado());
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Cliente());
        }

        private void buttonMateriales_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new Material());
        }

        private void buttonObras_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new Obra());
        }

        private void buttonVehiculos_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new Vehiculo());
        }

        private void pictureBoxSalir_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana Login?", "Cerrar Sesión", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

     
    }
}

