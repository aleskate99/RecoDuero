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
    public partial class Obra : Form
    {
        public Obra()
        {
            InitializeComponent();
        }

        private void obraBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.obraBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);

        }

        private void Obra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'recoDueroDataSet.Obra' Puede moverla o quitarla según sea necesario.
            this.obraTableAdapter.Fill(this.recoDueroDataSet.Obra);

        }
    }
}
