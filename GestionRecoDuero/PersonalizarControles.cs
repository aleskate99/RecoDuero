using System.Drawing;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    internal class PersonalizarControles
    {

        public static void PersonalizaTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            textBox.ForeColor = Color.Black;
            textBox.BorderStyle = BorderStyle.None;
            textBox.TextAlign = HorizontalAlignment.Left;


            textBox.Enter += (sender, e) =>
            {
                textBox.ForeColor = Color.Black;
            };

            textBox.Leave += (sender, e) =>
            {
                textBox.ForeColor = Color.Black;
            };
        }

        public static void PersonalizaControles(Control control)
        {
            control.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            control.ForeColor = Color.DimGray;

            control.BackColor = Color.White;
            control.Padding = new Padding(10);

            control.Enter += (sender, e) =>
            {
                control.BackColor = Color.LightGray;
            };

            control.Leave += (sender, e) =>
            {
                control.BackColor = Color.White;
            };

        }
    }
}
