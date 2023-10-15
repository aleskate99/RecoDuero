using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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
                // Verificar si la dirección de correo electrónico de destino no está vacía
                if (string.IsNullOrEmpty(correoDestino))
                {
                    MessageBox.Show("La dirección de correo electrónico de destino es inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurar la información del remitente
                string remitente = "recoduerozamora@gmail.com"; //TODO Crear correo de prueba
                string contraseña = "recoDuero00!";

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

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 465); //465 puerto seguro
                clienteSmtp.EnableSsl = true;
                
                
                //clienteSmtp.Timeout = 600000;
                //clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);

                // Crear el mensaje de correo
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
