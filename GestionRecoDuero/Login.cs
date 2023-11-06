using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace GestionRecoDuero

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Bordes.BordesRedondos(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.usuarioTableAdapter.Fill(this.recoDueroDataSet.Usuario);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            MoverPantalla.ReleaseCapture();
            MoverPantalla.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverPantalla.ReleaseCapture();
            MoverPantalla.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonAcceder_Click(object sender, EventArgs e)
        {
            string emailUsuario = emailTextBox.Text;
            string pass = passwordTextBox.Text;

            if (!Comun.EsDireccionCorreoValida(emailUsuario))
            {
                Comun.MostrarMensajeDeError("El formato del email introducido no es correcto.", "Formato de Email Erróneo");
                return;
            }

            var indiceResultadoBusquedaUsuario = usuarioBindingSource.Find("Email", emailUsuario);
            if (indiceResultadoBusquedaUsuario == -1)
            {
                Comun.MostrarMensajeDeError("Email no encontrado", "Error en el mail");
                return;
            }

            //Encriptar.EncriptarMD5(passwordTextBox.Text);
            var usuarioRow = recoDueroDataSet.Tables["Usuario"].Rows[indiceResultadoBusquedaUsuario];
            var passwordUsuario = usuarioRow["Password"].ToString();
            DatosSesion.Email = usuarioRow["Email"].ToString();

            if (passwordUsuario == pass)
            {
                passwordTextBox.Clear();
                AbrirInicioConBienvenida();
            }
            else
            {
                Comun.MostrarMensajeDeError("La contraseña no coincide", "Error en la contraseña");
                passwordTextBox.Clear();
            }

        }

        private void AbrirInicioConBienvenida()
        {
            Hide();
            Bienvenida bienvenida = new Bienvenida();
            bienvenida.ShowDialog();

            Inicio inicio = new Inicio();
            inicio.ShowDialog(this);
        }

        private void buttonMostrarPassAcceder_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
        }

        private void linkLabelRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Registro))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    break;
                }
            }
            if (!abierto)
            {
                Registro registro = new Registro();
                Hide();
                registro.Show();  
            }
        }

        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "EMAIL")
            {
                emailTextBox.Text = "";
                emailTextBox.ForeColor = Color.LightGray;
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "")
            {
                emailTextBox.Text = "EMAIL";
                emailTextBox.ForeColor = Color.DimGray;
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "CONTRASEÑA")
            {
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = Color.LightGray;
                passwordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "")
            {
                passwordTextBox.Text = "CONTRASEÑA";
                passwordTextBox.ForeColor = Color.DimGray;
            }
        }

        //TODO: REVISAR LO DEL CORREO
        private void linkLabelPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EnvioMail mail = new EnvioMail();

            var existeMail = usuarioBindingSource.Find("Email", emailTextBox.Text);

            if (existeMail != -1)
            {
                var usuario = usuarioBindingSource[existeMail] as DataRowView;
                usuario["Password"] = "recoDuero00!";
                tableAdapterManager.UpdateAll(recoDueroDataSet);

                mail.envioCorreo(emailTextBox.Text, true);
                MessageBox.Show("Correo enviado!");
            }
            else
            {
                Comun.MostrarMensajeDeError("Email no encontrado", "Error en la búsqueda del email");
                return;
            }  
        }

        //Atajos de teclado
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            //Acceder
            if (e.KeyCode == Keys.Enter)
            {
                buttonAcceder_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }
        }
    }
}
