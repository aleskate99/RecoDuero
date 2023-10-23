using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    internal class EnvioMail
    {
        public void envioCorreo(string correoDestino, bool recuperarPass)
        {
            // Configurar la información del destinatario
            string asunto = "";
            string cuerpo = "";

            try
            {
                // Configurar la información del remitente (debe ser una cuenta de Outlook o Hotmail)
                string remitente = "recoduerosl@hotmail.com";
                string contraseña = "recoDuero00!";

                // Configurar el cliente SMTP de Outlook
                SmtpClient clienteSmtp = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(remitente, contraseña),
                    EnableSsl = true,
                };

                // Crear el mensaje de correo
                if (recuperarPass)
                {
                    asunto = "Nueva contraseña";
                    cuerpo = "Se ha restablecido la contraseña para el usuario " + correoDestino + " con el valor recoDuero00!";
                }
                else
                {
                    asunto = "Nuevo usuario en recoduero";
                    cuerpo = "A partir de ahora podrá acceder a la app de recoDuero con el usuario " + correoDestino;
                }
                MailMessage mensaje = new MailMessage(remitente, correoDestino, asunto, cuerpo);

                // Enviar el correo
                clienteSmtp.Send(mensaje);

                MessageBox.Show("Correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
