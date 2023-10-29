﻿using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class InformeEmpleados : Form
    {
        public InformeEmpleados()
        {
            InitializeComponent();
        }

        private void InformeEmpleados_Load(object sender, EventArgs e)
        {
            this.empleadoTableAdapter.Fill(this.recoDueroDataSet.Empleado);
            this.reportViewer1.RefreshReport();
        }

        private void buttonQuitarFiltro_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.RemoveFilter();
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
            textBoxFiltrarDNI.Clear();
        }

        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.Filter = "Nombre='" + textBoxFiltrarNombre.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarNombre.Clear();
        }

        private void buttonFiltrarDni_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.Filter = "DNI='" + textBoxFiltrarDNI.Text + "'";
            reportViewer1.RefreshReport();
            textBoxFiltrarDNI.Clear();
        }

        private void buttonFiltrarPuesto_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.Filter = "Puesto='" + comboBoxFiltrarPuesto.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarPuesto.Text = (" ");
        }

        private void buttonFiltrarSituacionLaboral_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.Filter = "SituacionLaboral='" + comboBoxFiltrarSituacionLaboral.Text + "'";
            reportViewer1.RefreshReport();
            comboBoxFiltrarSituacionLaboral.Text = (" ");
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana de empleados?", "Cerrar informe empleados", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
