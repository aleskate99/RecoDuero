using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            Bordes.BordesRedondos(this);
        }
        
        private void Registro_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'recoDueroDataSet.Usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.recoDueroDataSet.Usuario);

            usuarioTextBox.DataBindings.Clear();
            emailTextBox.DataBindings.Clear();
            passwordTextBox.DataBindings.Clear();

            usuarioTextBox.DataBindings.Add("Text", usuarioBindingSource, "Usuario");
            emailTextBox.DataBindings.Add("Text", usuarioBindingSource, "Email");
            passwordTextBox.DataBindings.Add("Text", usuarioBindingSource, "Password");

            usuarioBindingSource.AddNew();

            usuarioTextBox.Text = "USUARIO";
            emailTextBox.Text = "EMAIL";
            passwordTextBox.Text = "CONTRASEÑA";

        }

        // MOVER LA PANTALLA
        private void Registro_MouseDown(object sender, MouseEventArgs e)
        {
            MoverPantalla.ReleaseCapture();
            MoverPantalla.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //BOTONES
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            bool passwordValida = Comun.VerificarPassword(passwordTextBox.Text);

            //Compruebo que sea la dirección de correo válida
            if (Comun.EsDireccionCorreoValida(emailTextBox.Text))
            {
                //Compruebo si existe el email
                var emailUsuario = usuarioBindingSource.Find("Email", emailTextBox.Text);
                if (emailUsuario == -1)
                {
                    // Comprueba que la contraseña sea válida
                    if (passwordValida)
                    {
                        usuarioBindingSource.EndEdit();
                        tableAdapterManager.UpdateAll(recoDueroDataSet);

                        EnvioMail mail = new EnvioMail();
                        mail.envioCorreo(emailTextBox.Text, false);

                        //Limpio los campos
                        usuarioTextBox.Clear();
                        emailTextBox.Clear();
                        passwordTextBox.Clear();

                        Login login = new Login();
                        Close();
                        login.Show();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe poseer al menos una minúscula, una mayúscula,un número y un carácter especial", "Error en la contraseña", MessageBoxButtons.OKCancel);
                        passwordTextBox.Clear();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("El email ya está en uso.", "Email no encontrado", MessageBoxButtons.OKCancel);
                    return;
                }
            }
            else
            {
                MessageBox.Show("El formato del email introducido no es correcto.", "Formato de Email Erróneo", MessageBoxButtons.OKCancel);
                return;
            }  

        }

        private void buttonMostrarPass_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
        }

        // TEXTBOXS

        //Usuario
        private void usuarioTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (usuarioTextBox.Text.Length > 30)
            {
                errorProvider1.SetError(usuarioTextBox, "El nombre de usuario no debe superar los 30 caracteres introducidos ");
                usuarioTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void usuarioTextBox_Validated(object sender, EventArgs e)
        {
            // Si todas las condiciones se cumplen se limpia los errores del ErrorProvider
            errorProvider1.SetError(usuarioTextBox, "");
            errorProvider1.Clear();
        }

        private void usuarioTextBox_Enter(object sender, EventArgs e)
        {
            if (usuarioTextBox.Text == "USUARIO")
            {
                usuarioTextBox.Text = "";
                usuarioTextBox.ForeColor = Color.LightGray;
            }
        }

        private void usuarioTextBox_Leave(object sender, EventArgs e)
        {
            if (usuarioTextBox.Text == "")
            {
                usuarioTextBox.Text = "USUARIO";
                usuarioTextBox.ForeColor = Color.DimGray;
            }
        }

        // Email
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (emailTextBox.Text.Length > 50)
            {
                errorProvider1.SetError(emailTextBox, "El email no debe superar los 50 caracteres introducidos ");
                emailTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void emailTextBox_Validated(object sender, EventArgs e)
        {
            // Si todas las condiciones se cumplen se limpia los errores del ErrorProvider
            errorProvider1.SetError(usuarioTextBox, "");
            errorProvider1.Clear();
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

        // Password
        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (passwordTextBox.Text.Length > 30)
            {
                errorProvider1.SetError(passwordTextBox, "La contraseña no debe superar los 30 caracteres introducidos ");
                passwordTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void passwordTextBox_Validated(object sender, EventArgs e)
        {
            // Si todas las condiciones se cumplen se limpia los errores del ErrorProvider
            errorProvider1.SetError(usuarioTextBox, "");
            errorProvider1.Clear();
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
    }
}
