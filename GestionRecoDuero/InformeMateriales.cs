using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class InformeMateriales : Form
    {
        public InformeMateriales()
        {
            InitializeComponent();
        }

        private void InformeMateriales_Load(object sender, EventArgs e)
        {
            this.materialTableAdapter.Fill(this.recoDueroDataSet.Material);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            materialBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
            textBoxFiltrarDistribuidor.Clear();
        }

        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            materialBindingSource.Filter = "Nombre='" + textBoxFiltrarNombre.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
        }

        private void buttonFiltrarDistribuidor_Click(object sender, EventArgs e)
        {
            materialBindingSource.Filter = "Distribuidor='" + textBoxFiltrarDistribuidor.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarDistribuidor.Clear();
        }

        private void buttonFiltrarEstado_Click(object sender, EventArgs e)
        {
            materialBindingSource.Filter = "Estado='" + comboBoxFiltrarEstado.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarEstado.Text = (" ");
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de materiales?", "Cerrar informe materiales", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
