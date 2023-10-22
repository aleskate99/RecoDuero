using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    internal class Comun
    {
        public static bool ContieneNumeros(String texto)
        {
            string patronNumeros = @"^\d+$";
            return Regex.IsMatch(texto, patronNumeros);
        }

        public static bool ComprobarDni(String dni)
        {
            string patronDNI = @"^\d{8}[A-Z]$";
            return Regex.IsMatch(dni, patronDNI);
        }

        public static bool ComprobarTelefono(String telefono)
        {
            string patronTelefono = "^[679][0-9]{8}$";
            return Regex.IsMatch(telefono, patronTelefono);
        }

        //Controla mayusculas,minusculas,Ñ,ñ y vocales acentuadas
        public static bool ContieneSoloLetras(String texto)
        {
            string patronLetras = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$";
            return Regex.IsMatch(texto, patronLetras);
        }

        public static bool EsDireccionCorreoValida(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }


        //Comprueba que tenga al menos 1 mayuscula,1 minuscula,1 numero y 1 caracter especial
        public static bool VerificarPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).*$");
        }

        public static void MostrarMensajeDeError(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

    }
}
