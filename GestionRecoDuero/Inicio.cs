using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            Bordes.BordesRedondos(this);
            //labelUsuario.Text = DatosSesion.Email.ToString();
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
                labelUsuario.Text = "Usuario";
            }
            else
            {
                panelzquierda.Width = 200;
                labelUsuario.Text = DatosSesion.Email.ToString();
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
            AbrirFormInPanel(new Material());
        }

        private void buttonObras_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Obra());
        }

        private void buttonVehiculos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Vehiculo());
        }

        private void buttonServiciosExternos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ServicioExterno());
        }

        private void buttonPresupuesto_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new Presupuesto());
        }

        private void buttonFactura_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new Factura());
        }

        private void pictureBoxCerrarApp_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Cerrar Aplicación", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}

