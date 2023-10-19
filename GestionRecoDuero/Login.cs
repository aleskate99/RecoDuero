using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static GestionRecoDuero.RecoDueroDataSet;
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
            Application.Exit();
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

        private bool EsDireccionCorreoValida(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }

        private void buttonAcceder_Click(object sender, EventArgs e)
        {
            string usuario = emailTextBox.Text;
            string pass = passwordTextBox.Text;

            if (EsDireccionCorreoValida(emailTextBox.Text))
            {
                //Compruebo si existe el email
                var indiceResultadoBusquedaUsuario = usuarioBindingSource.Find("Email", usuario);
                if (indiceResultadoBusquedaUsuario != -1)
                {
                    //Encriptar.EncriptarMD5(pass);
                    var usuarioRow = recoDueroDataSet.Tables["Usuario"].Rows[indiceResultadoBusquedaUsuario];
                    var passwordUsuario = usuarioRow["Password"].ToString();
                    DatosSesion.Email = usuarioRow["Email"].ToString();

                    if (passwordUsuario == pass)
                    {
                        passwordTextBox.Clear();

                        Hide();
                        Bienvenida bienvenida = new Bienvenida();
                        bienvenida.ShowDialog();

                        Inicio inicio = new Inicio();
                        inicio.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("La contraseña no coincide", "Error en la contraseña", MessageBoxButtons.OKCancel);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de Usuario no encontrado", "Error en el mail", MessageBoxButtons.OKCancel);
                    return;
                }
            }
            else
            {
                MessageBox.Show("El formato del email introducido no es correcto.", "Formato de Email Erróneo", MessageBoxButtons.OKCancel);
                return;
            }
            
        }

        private void buttonMostrarPassAcceder_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
        }

        private void usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usuarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);
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
                mail.envioCorreo(emailTextBox.Text , true);
                MessageBox.Show("Correo enviado!");  
            }
            else
            {
                MessageBox.Show("Nombre de Usuario no encontrado");
                return;
            }  
        }

        //Atajos de teclado
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            //Aceptar
            if (e.KeyCode == Keys.Enter)
            {
                buttonAcceder_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }
        }
    }
}
