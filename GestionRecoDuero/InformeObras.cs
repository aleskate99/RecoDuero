using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class InformeObras : Form
    {
        public InformeObras()
        {
            InitializeComponent();
        }

        private void InformeObras_Load(object sender, EventArgs e)
        {
            this.obraTableAdapter.Fill(this.recoDueroDataSet.Obra);
            this.reportViewer1.RefreshReport();
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de obras?", "Cerrar informe obras", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }


    }
}
