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
    public partial class InformeClientes : Form
    {
        public InformeClientes()
        {
            InitializeComponent();
        }

        private void InformeClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'recoDueroDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.recoDueroDataSet.Cliente);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            clienteBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
            textBoxFiltrarTelefono.Clear();
        }

        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            clienteBindingSource.Filter = "Nombre='" + textBoxFiltrarNombre.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
        }

        private void buttonFiltrarTelefono_Click(object sender, EventArgs e)
        {
            clienteBindingSource.Filter = "Telefono='" + textBoxFiltrarTelefono.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarTelefono.Clear();
        }

        private void buttonFiltrarTipo_Click(object sender, EventArgs e)
        {
            clienteBindingSource.Filter = "Tipo='" + comboBoxFiltrarTipo.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarTipo.Text = (" ");
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de clientes?", "Cerrar informe clientes", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
