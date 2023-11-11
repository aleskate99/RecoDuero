using System;
using System.Text.RegularExpressions;
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

            if (Regex.IsMatch(dni, patronDNI))
            {
                // Extraer los números del DNI
                string numerosDNI = dni.Substring(0, 8);

                // Extraer la letra del DNI
                char letraDNI = char.ToUpper(dni[8]);

                // Calcular la letra correspondiente a los números
                string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
                int resto = int.Parse(numerosDNI) % 23;
                char letraCalculada = letras[resto];

                // Comprobar si la letra calculada es igual a la letra del DNI
                return letraDNI == letraCalculada;
            }

            return false;

        }

        public static bool ComprobarTelefono(String telefono)
        {
            string patronTelefono = "^[679][0-9]{8}$";
            return Regex.IsMatch(telefono, patronTelefono);
        }

        public static bool ComprobarMatricula(String matricula)
        {
            string patronMatricula = @"^\d{4}[A-Z]{3}$";
            return Regex.IsMatch(matricula, patronMatricula);
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
