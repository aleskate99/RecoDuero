using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class InformeFacturas : Form
    {
        public InformeFacturas()
        {
            InitializeComponent();
        }

        private void InformeFacturas_Load(object sender, EventArgs e)
        {
            this.facturaTableAdapter.Fill(this.recoDueroDataSet.Factura);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            facturaBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarEmpleado.Clear();
            textBoxFiltrarCliente.Clear();
        }

        private void buttonFiltrarEmpleado_Click(object sender, EventArgs e)
        {
            facturaBindingSource.Filter = "Empleado='" + textBoxFiltrarEmpleado.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarEmpleado.Clear();
        }

        private void buttonFiltrarCliente_Click(object sender, EventArgs e)
        {
            facturaBindingSource.Filter = "Cliente='" + textBoxFiltrarCliente.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarCliente.Clear();
        }

        private void buttonFiltrarEstado_Click(object sender, EventArgs e)
        {
            facturaBindingSource.Filter = "Estado='" + comboBoxFiltrarEstado.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarEstado.Text = (" ");
        }

        private void buttonFiltrarMetodo_Click(object sender, EventArgs e)
        {
            facturaBindingSource.Filter = "Metodo='" + comboBoxFiltrarMetodo.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarMetodo.Text = (" ");
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de facturas?", "Cerrar informe facturas", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
