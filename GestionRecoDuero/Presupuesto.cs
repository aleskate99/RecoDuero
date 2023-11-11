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
    public partial class Presupuesto : Form
    {
        public Presupuesto()
        {
            InitializeComponent();
            KeyPreview = true;

            //Redondear controles
            //Bordes.BordesRedondosBoton(buttonAceptar);
            //Bordes.BordesRedondosBoton(buttonCancelar);
        }

        private void Presupuesto_Load(object sender, EventArgs e)
        {
            AjustarImagenes();
            EstadoControlesInicioApp();
            //RefrescarToolstripLabelEmpleado();
            toolStripStatusLabel1.Text = "Inicio";
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar presupuestos", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void AjustarImagenes()
        {
            AjustarBoton(toolStripButtonAnadir);
            AjustarBoton(toolStripButtonEliminar);
            AjustarBoton(toolStripButtonEditar);
            AjustarBoton(toolStripButtonGuardar);
            AjustarBoton(toolStripButtonBuscar);
            AjustarBoton(toolStripButtonImprimir);
            AjustarBoton(toolStripButtonAnterior);
            AjustarBoton(toolStripButtonInicio);
            AjustarBoton(toolStripButtonInforme);
            AjustarBoton(toolStripButtonSiguiente);
            AjustarBoton(toolStripButtonFinal);
        }

        private void AjustarBoton(ToolStripButton boton)
        {
            boton.AutoSize = false;
            boton.Width = 50;
            boton.Height = 50;
            boton.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void EstadoControlesInicioApp()
        {
            ////Botones
            //toolStripButtonInicio.Enabled = false;
            //toolStripButtonAnterior.Enabled = false;

            ////Campos
            //OcultarCampos();

            ////Aceptar y cancelar invisibles hasta que se realice una operación
            //buttonAceptar.Visible = false;
            //buttonCancelar.Visible = false;

            //if (empleadoBindingSource.Count < 1)
            //{
            //    toolStripButtonEliminar.Enabled = false;
            //    toolStripButtonEditar.Enabled = false;
            //    toolStripButtonGuardar.Enabled = false;
            //    toolStripComboBoxBuscarEmpleados.Enabled = false;
            //    toolStripTextBoxBuscar.Enabled = false;
            //    toolStripButtonBuscar.Enabled = false;
            //    toolStripButtonSiguiente.Enabled = false;
            //    toolStripButtonFinal.Enabled = false;
            //}

            //else if (empleadoBindingSource.Count == 1)
            //{
            //    toolStripButtonSiguiente.Enabled = false;
            //    toolStripButtonFinal.Enabled = false;
            //    toolStripButtonAnterior.Enabled = false;
            //    toolStripButtonInicio.Enabled = false;
            //    toolStripButtonEliminar.Enabled = true;
            //    toolStripButtonEditar.Enabled = true;
            //    toolStripButtonGuardar.Enabled = false;
            //    toolStripComboBoxBuscarEmpleados.Enabled = true;
            //    toolStripTextBoxBuscar.Enabled = true;
            //    toolStripButtonBuscar.Enabled = true;
            //}
            //else
            //{

            //    toolStripButtonSiguiente.Enabled = true;
            //    toolStripButtonFinal.Enabled = true;
            //    toolStripButtonAnterior.Enabled = false;
            //    toolStripButtonInicio.Enabled = false;

            //    toolStripButtonEliminar.Enabled = true;
            //    toolStripButtonEditar.Enabled = true;
            //    toolStripButtonGuardar.Enabled = false;
            //    toolStripComboBoxBuscarEmpleados.Enabled = true;
            //    toolStripTextBoxBuscar.Enabled = true;
            //    toolStripButtonBuscar.Enabled = true;
            //}
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            //// Comprobar si no hay registros en el origen de datos
            //if (empleadoBindingSource.Count <= 0)
            //    return;

            //// Mover el cursor del origen de datos al registro especificado por 'index'
            //empleadoBindingSource.Position = indice;

            //// Determinar si el registro actual es el primer o el último
            //bool enPrimerRegistro = empleadoBindingSource.Position == 0;
            //bool enUltimoRegistro = empleadoBindingSource.Position == empleadoBindingSource.Count - 1;

            //// Habilitar o deshabilitar los botones de navegación según la posición del registro
            //toolStripButtonInicio.Enabled = !enPrimerRegistro;
            //toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            //toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            //toolStripButtonFinal.Enabled = !enUltimoRegistro;

            //RefrescarToolstripLabelEmpleado();
        }


        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            //NavegarRegistro(empleadoBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            //NavegarRegistro(empleadoBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            //NavegarRegistro(empleadoBindingSource.Count - 1); // Ir al último registro
        }

        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonImprimir_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void buttonAniadirLinea_Click(object sender, EventArgs e)
        {
            //detalleReservaBindingSource.AddNew();

            ////Campos
            //idDetalleReservaLabel1.Enabled = true;
            //idHabitacionTextBox.Enabled = true;
            //idReservaLabel3.Enabled = true;
            //precioTextBox.Enabled = true;

            ////Botones
            //buttonAceptarDetalleReserva.Visible = true;
            //buttonCancelarDetalleReserva.Visible = true;
        }

        private void buttonBorrarLinea_Click(object sender, EventArgs e)
        {
            //if (detalleReservaBindingSource.Count <= 0)
            //{
            //    MessageBox.Show("No se puede eliminar la línea porque no hay ninguna ", "Error en la eliminación de un cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    detalleReservaBindingSource.RemoveCurrent();
            //    this.reservaTableAdapter.Update(this.hotelDataSet);
            //}
        }

        private void buttonEditarLinea_Click(object sender, EventArgs e)
        {
            //Campos
            //idDetalleReservaLabel1.Enabled = true;
            //idHabitacionTextBox.Enabled = true;
            //idReservaLabel3.Enabled = true;
            //precioTextBox.Enabled = true;

            ////Botones
            //buttonAceptarDetalleReserva.Visible = true;
            //buttonCancelarDetalleReserva.Visible = true;
        }

        private void buttonAceptarDetalleReserva_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos2() == true)
            {

                //this.detalleReservaBindingSource.EndEdit();
                //this.detalleReservaTableAdapter.Update(this.hotelDataSet);
                //this.reservaTableAdapter.Update(this.hotelDataSet);
                //precioTotalLabel1.Text = (Convert.ToInt32(precioTotalLabel1.Text) + Convert.ToInt32(precioTextBox.Text)).ToString();

                ////Campos
                //idDetalleReservaLabel1.Enabled = false;
                //idHabitacionTextBox.Enabled = false;
                //idReservaLabel3.Enabled = false;
                //precioTextBox.Enabled = false;

                ////Botones
                //buttonAceptarDetalleReserva.Visible = false;
                //buttonCancelarDetalleReserva.Visible = false;
            }
        }

        private void buttonCancelarDetalleReserva_Click(object sender, EventArgs e)
        {
            //this.detalleReservaBindingSource.CancelEdit();

            ////Campos
            //idDetalleReservaLabel1.Enabled = false;
            //idHabitacionTextBox.Enabled = false;
            //idReservaLabel3.Enabled = false;
            //precioTextBox.Enabled = false;

            ////Botones
            //buttonAceptarDetalleReserva.Visible = false;
            //buttonCancelarDetalleReserva.Visible = false;
        }

        private bool ComprobarDatosIntroducidos2()
        {

            //if (idHabitacionTextBox.Text.Length == 0)
            //{
            //    errorProvider1.SetError(idHabitacionTextBox, "No puede dejar este campo vacío ");
            //    idHabitacionTextBox.Clear();
            //    return false;
            //}
            //else if (ContieneNumeros(idHabitacionTextBox.Text) == false && (idHabitacionTextBox.Text.Length != 0))
            //{
            //    errorProvider1.SetError(idHabitacionTextBox, "Solo puede introducir números ");
            //    idHabitacionTextBox.Clear();
            //    return false;
            //}


            //si todo es valido
            return true;
        }

        private void Presupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
