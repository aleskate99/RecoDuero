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
    public partial class InformeVehiculos : Form
    {
        public InformeVehiculos()
        {
            InitializeComponent();
        }

        private void InformeVehiculos_Load(object sender, EventArgs e)
        {
            this.vehiculoTableAdapter.Fill(this.recoDueroDataSet.Vehiculo);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            vehiculoBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            //textBoxFiltrarTelefono.Clear();
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de vehículos?", "Cerrar informe vehículos", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
