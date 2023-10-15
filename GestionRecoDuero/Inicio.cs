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
            BordesRedondos();
            labelUsuario.Text = DatosSesion.Email;
        }

        private void BordesRedondos()
        {
            int borderRadius = 20; // Puedes ajustar este valor según tus preferencias
            GraphicsPath path = GetRoundedPath(this.ClientRectangle, borderRadius);
            this.Region = new Region(path);

        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = borderRadius * 2;
            Rectangle arcRect = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Para poder mover la pantalla dado que no hay controles nativos si no creados por mi mediante imagenes y botones
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparm, int lparam);


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
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

