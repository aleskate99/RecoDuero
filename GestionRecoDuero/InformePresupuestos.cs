using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class InformePresupuestos : Form
    {
        public InformePresupuestos()
        {
            InitializeComponent();
        }

        private void InformePresupuestos_Load(object sender, EventArgs e)
        {
            this.presupuestoTableAdapter.Fill(this.recoDueroDataSet.Presupuesto);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            presupuestoBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarResponsable.Clear();
            textBoxFiltrarCliente.Clear();
        }

        private void buttonFiltrarResponsable_Click(object sender, EventArgs e)
        {
            presupuestoBindingSource.Filter = "Responsable='" + textBoxFiltrarResponsable.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarResponsable.Clear();
        }

        private void buttonFiltrarCliente_Click(object sender, EventArgs e)
        {
            presupuestoBindingSource.Filter = "Cliente='" + textBoxFiltrarCliente.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarCliente.Clear();
        }

        private void buttonFiltrarEstado_Click(object sender, EventArgs e)
        {
            presupuestoBindingSource.Filter = "Estado='" + comboBoxFiltrarEstado.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarEstado.Text = (" ");
        }

        private void buttonFiltrarMetodo_Click(object sender, EventArgs e)
        {
            presupuestoBindingSource.Filter = "Metodo='" + comboBoxFiltrarMetodo.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarMetodo.Text = (" ");
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de presupuestos?", "Cerrar informe presupuestos", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
