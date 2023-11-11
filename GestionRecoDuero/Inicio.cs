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
                EmpleadoAbierto();
                ClienteAbierto();
                MaterialAbierto();
                ObraAbierto();
                VehiculoAbierto();
                ServicioExternoAbierto();
                PresupuestoAbierto();
                FacturaAbierto();
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

        private void CerrarFormInPanel(object Formhijo)
        {
            if (this.panelCentral.Controls.Count > 0)
            {
                Form formHijo = this.panelCentral.Controls[0] as Form;

                // Cierra el formulario hijo si existe
                if (formHijo != null)
                {
                    formHijo.Close();
                    this.panelCentral.Controls.Remove(formHijo);
                }
            }
        }

        //Comprobar formularios abiertos
        private void EmpleadoAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Empleado))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        private void ClienteAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Cliente))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }  

        private void MaterialAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Material))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        private void ObraAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Obra))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        private void VehiculoAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Vehiculo))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        private void ServicioExternoAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(ServicioExterno))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        private void PresupuestoAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Presupuesto))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        private void FacturaAbierto()
        {
            Boolean abierto = false;
            Form formAbierto = null;

            //comprobamos que no esta abierto el formulario cliente
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Factura))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    formAbierto = frm;
                    break;
                }
            }
            if (abierto)
            {
                CerrarFormInPanel(formAbierto);
            }
        }

        // BOTONES
        private void buttonEmpleados_Click(object sender, EventArgs e)
        {
            ClienteAbierto();
            MaterialAbierto();
            ObraAbierto();
            VehiculoAbierto();
            ServicioExternoAbierto();
            PresupuestoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new Empleado());
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            MaterialAbierto();
            ObraAbierto();
            VehiculoAbierto();
            ServicioExternoAbierto();
            PresupuestoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new Cliente());
        }

        private void buttonMateriales_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            ClienteAbierto();
            ObraAbierto();
            VehiculoAbierto();
            ServicioExternoAbierto();
            PresupuestoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new Material());
        }

        private void buttonObras_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            ClienteAbierto();
            MaterialAbierto();
            VehiculoAbierto();
            ServicioExternoAbierto();
            PresupuestoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new Obra());
        }

        private void buttonVehiculos_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            ClienteAbierto();
            MaterialAbierto();
            ObraAbierto();
            ServicioExternoAbierto();
            PresupuestoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new Vehiculo());
        }

        private void buttonServiciosExternos_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            ClienteAbierto();
            MaterialAbierto();
            ObraAbierto();
            VehiculoAbierto();
            PresupuestoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new ServicioExterno());
        }

        private void buttonPresupuesto_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            ClienteAbierto();
            MaterialAbierto();
            ObraAbierto();
            VehiculoAbierto();
            ServicioExternoAbierto();
            FacturaAbierto();
            AbrirFormInPanel(new Presupuesto());
        }

        private void buttonFactura_Click(object sender, EventArgs e)
        {
            EmpleadoAbierto();
            ClienteAbierto();
            MaterialAbierto();
            ObraAbierto();
            VehiculoAbierto();
            ServicioExternoAbierto();
            PresupuestoAbierto();
            AbrirFormInPanel(new Factura());
        }

        private void pictureBoxCerrarApp_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Cerrar Aplicación", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                //Application.Exit();
                Environment.Exit(0);
            }
        }
    }
}

