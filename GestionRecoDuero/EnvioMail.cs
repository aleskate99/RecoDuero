using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

            string idCliente = "1050222614005-ut0umllaa69cv2tdgkd4q7ef2oc68p4s.apps.googleusercontent.com";
            string secretoCliente = "1050222614005-ut0umllaa69cv2tdgkd4q7ef2oc68p4s.apps.googleusercontent.com";

            try
            {
                UserCredential credential;
                using (var stream = new System.IO.FileStream("token.json", System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    string[] scopes = { GmailService.Scope.GmailSend };
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        new ClientSecrets
                        {
                            ClientId = idCliente,
                            ClientSecret = secretoCliente
                        },
                        scopes,
                        "usuario",
                        CancellationToken.None,
                        new FileDataStore("token.json")).Result;
                }

                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "RecoDuero"
                });


                // Verificar si la dirección de correo electrónico de destino no está vacía
                if (string.IsNullOrEmpty(correoDestino))
                {
                    MessageBox.Show("La dirección de correo electrónico de destino es inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurar la información del remitente
                string remitente = "recoduerosl@gmail.com"; //TODO Crear correo de prueba
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
