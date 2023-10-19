using System.Runtime.InteropServices;


namespace GestionRecoDuero
{
    internal class MoverPantalla
    {
        // Para poder mover la pantalla dado que no hay controles nativos si no creados por mi mediante imagenes y botones
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparm, int lparam);     
    }
}
