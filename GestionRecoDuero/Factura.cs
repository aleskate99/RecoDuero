using System;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Factura : Form
    {
        private bool datosGuardados = true;

        public Factura()
        {
            InitializeComponent();
            KeyPreview = true;

            //Redondear controles
            //Bordes.BordesRedondosBoton(buttonAceptar);
            //Bordes.BordesRedondosBoton(buttonCancelar);
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            AjustarImagenes();
            EstadoControlesInicioApp();
            //RefrescarToolstripLabelEmpleado();
            toolStripStatusLabel1.Text = "Inicio";
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar facturas", MessageBoxButtons.OKCancel);
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

        private void toolStripButtonInforme_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
