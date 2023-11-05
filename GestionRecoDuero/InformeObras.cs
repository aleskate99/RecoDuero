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

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            obraBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
        }

        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            obraBindingSource.Filter = "Nombre='" + textBoxFiltrarNombre.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
        }

        private void buttonFiltrarEstado_Click(object sender, EventArgs e)
        {
            obraBindingSource.Filter = "Estado='" + comboBoxFiltrarEstado.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarEstado.Text = (" ");
        }

        private void buttonFiltrarTipo_Click(object sender, EventArgs e)
        {
            obraBindingSource.Filter = "Tipo='" + comboBoxFiltrarTipo.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarTipo.Text = (" ");
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
