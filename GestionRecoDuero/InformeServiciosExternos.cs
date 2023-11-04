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
    public partial class InformeServiciosExternos : Form
    {
        public InformeServiciosExternos()
        {
            InitializeComponent();
        }

        private void InformeServiciosExternos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'recoDueroDataSet.ServicioExterno' Puede moverla o quitarla según sea necesario.
            this.servicioExternoTableAdapter.Fill(this.recoDueroDataSet.ServicioExterno);

            this.reportViewer1.RefreshReport();
        }
    }
}
