using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class InformeServiciosExternos : Form
    {
        public InformeServiciosExternos()
        {
            InitializeComponent();
        }

        private void InformeServiciosExternos_Load(object sender, EventArgs e)
        {
            this.servicioExternoTableAdapter.Fill(this.recoDueroDataSet.ServicioExterno);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            servicioExternoBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarEmpresa.Clear();
        }

        private void buttonFiltrarEmpresa_Click(object sender, EventArgs e)
        {
            servicioExternoBindingSource.Filter = "Empresa='" + textBoxFiltrarEmpresa.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarEmpresa.Clear();
        }

        private void buttonFiltrarEstado_Click(object sender, EventArgs e)
        {
            servicioExternoBindingSource.Filter = "Estado='" + comboBoxFiltrarEstado.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarEstado.Text = (" ");
        }

        private void buttonFiltrarTipo_Click(object sender, EventArgs e)
        {
            servicioExternoBindingSource.Filter = "Tipo='" + comboBoxFiltrarTipo.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarTipo.Text = (" ");
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de servicios externos?", "Cerrar informe servicios externos", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
