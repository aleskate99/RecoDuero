using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        //Controla mayusculas,minusculas,Ñ,ñ y vocales acentuadas
        public static bool ContieneSoloLetras(String texto)
        {
            string patronLetras = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]+$";
            return Regex.IsMatch(texto, patronLetras);
        }

    }
}
