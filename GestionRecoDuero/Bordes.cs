using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    internal class Bordes
    {
        public static void BordesRedondos(Form formulario)
        {
            int borderRadius = 20;
            GraphicsPath path = GetRoundedPath(formulario.ClientRectangle, borderRadius);
            formulario.Region = new Region(path);   
        }

        public static void BordesRedondosBoton(Button button)
        {
            int borderRadius = 20;
            GraphicsPath path = GetRoundedPath(button.ClientRectangle, borderRadius);
            button.Region = new Region(path);
        }

        private static GraphicsPath GetRoundedPath(Rectangle rect, int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = borderRadius * 2;
            Rectangle arcRect = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }

    }
}
