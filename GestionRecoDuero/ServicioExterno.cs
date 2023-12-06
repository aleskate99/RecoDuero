using GestionRecoDuero.RecoDueroDataSetTableAdapters;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static GestionRecoDuero.RecoDueroDataSet;

namespace GestionRecoDuero
{
    public partial class ServicioExterno : Form
    {
        private bool datosGuardados = true;

        public ServicioExterno()
        {
            InitializeComponent();
            KeyPreview = true;

            //Redondear los controles
            Bordes.BordesRedondosBoton(buttonAceptar);
            Bordes.BordesRedondosBoton(buttonCancelar);
        }

        private void ServicioExterno_Load(object sender, EventArgs e)
        {
            this.servicioExternoTableAdapter.Fill(this.recoDueroDataSet.ServicioExterno);
            AjustarImagenes();
            EstadoControlesInicioApp();
            RefrescarToolstripLabelServicioExterno();
            CargarObras(); //Para cargar la ubicación de las obras
            toolStripStatusLabel1.Text = "Inicio";
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar servicio externo", MessageBoxButtons.OKCancel);
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
            //Botones
            toolStripButtonInicio.Enabled = false;
            toolStripButtonAnterior.Enabled = false;

            //Campos
            OcultarCampos();

            //Aceptar y cancelar invisibles hasta que se realice una operación
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            if (servicioExternoBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarServiciosExternos.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }
            else if (servicioExternoBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarServiciosExternos.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
            else
            {
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;

                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarServiciosExternos.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            // Comprobar si no hay registros en el origen de datos
            if (servicioExternoBindingSource.Count <= 0)
                return;

            // Mover el cursor del origen de datos al registro especificado por 'index'
            servicioExternoBindingSource.Position = indice;

            // Determinar si el registro actual es el primer o el último
            bool enPrimerRegistro = servicioExternoBindingSource.Position == 0;
            bool enUltimoRegistro = servicioExternoBindingSource.Position == servicioExternoBindingSource.Count - 1;

            // Habilitar o deshabilitar los botones de navegación según la posición del registro
            toolStripButtonInicio.Enabled = !enPrimerRegistro;
            toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            toolStripButtonFinal.Enabled = !enUltimoRegistro;

            RefrescarToolstripLabelServicioExterno();
        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            NavegarRegistro(servicioExternoBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            NavegarRegistro(servicioExternoBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            NavegarRegistro(servicioExternoBindingSource.Count - 1); // Ir al último registro
        }

        //AÑADIR
        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir servicio externo";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            servicioExternoBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();

            RefrescarToolstripLabelServicioExterno();
            datosGuardados = false;

            ((DataRowView)servicioExternoBindingSource.Current)["Tipo"] = tipoComboBox.SelectedItem.ToString();
            ((DataRowView)servicioExternoBindingSource.Current)["Estado"] = estadoComboBox.SelectedItem.ToString();

            ((DataRowView)servicioExternoBindingSource.Current)["Coste"] = (int)costeNumericUpDown.Value;
            ((DataRowView)servicioExternoBindingSource.Current)["DuracionServicio"] = (int)duracionServicioNumericUpDown.Value;

            if (obraComboBox.Items.Count > 0)
            {
                CargarObras();
                ((DataRowView)servicioExternoBindingSource.Current)["Obra"] = obraComboBox.SelectedItem.ToString();
            }
        }

        private void HabilitarControlesEnAnadir()
        {
            //Botones
            buttonAceptar.Visible = true;
            buttonCancelar.Visible = true;
            toolStripButtonGuardar.Enabled = false;

            //Campos
            MostrarCampos();

            //Campos por defecto a una opción
            tipoComboBox.SelectedIndex = 0;
            estadoComboBox.SelectedIndex = 0;
            costeNumericUpDown.Value = 0;
            duracionServicioNumericUpDown.Value = 0;
        }

        private void DeshabilitarBotonesEnAnadir()
        {
            //Deshabilita todos los botones en Añadir salvo aceptar cancelar y guardar
            toolStripButtonAnadir.Enabled = false;
            toolStripButtonAnterior.Enabled = false;
            toolStripButtonInicio.Enabled = false;
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;
            toolStripButtonEditar.Enabled = false;
            toolStripButtonEliminar.Enabled = false;
            toolStripButtonBuscar.Enabled = false;
            toolStripComboBoxBuscarServiciosExternos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //ELIMINAR
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar servicio externo";

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el servicio externo?", "Confirmación eliminar servicio externo", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (servicioExternoBindingSource.Count <= 0)
                {
                    Comun.MostrarMensajeDeError("No se puede eliminar el servicio externo porque no existe en la base de datos.", "Error en la eliminación de un servicio externo");
                }
                else
                {
                    servicioExternoBindingSource.RemoveCurrent();
                    servicioExternoBindingSource.EndEdit();
                    this.servicioExternoTableAdapter.Update(this.recoDueroDataSet);
                }

                if (servicioExternoBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (servicioExternoBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (servicioExternoBindingSource.Position + 1 == servicioExternoBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }

            RefrescarToolstripLabelServicioExterno();
        }

        //EDITAR
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar servicio externo";
            EstadoControlesEditar();
            ComprobarDatosIntroducidos();
            datosGuardados = false;
        }

        private void EstadoControlesEditar()
        {
            //Botones
            buttonAceptar.Visible = true;
            buttonCancelar.Visible = true;

            //Campos
            MostrarCampos();

            //Botones barra
            toolStripButtonAnadir.Enabled = false;
            toolStripButtonAnterior.Enabled = false;
            toolStripButtonInicio.Enabled = false;
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;
            toolStripButtonEditar.Enabled = false;
            toolStripButtonEliminar.Enabled = false;
            toolStripButtonGuardar.Enabled = false;
            toolStripButtonBuscar.Enabled = false;
            toolStripComboBoxBuscarServiciosExternos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //GUARDAR
        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();

                servicioExternoBindingSource.EndEdit();
                this.servicioExternoTableAdapter.Update(this.recoDueroDataSet);

                EstadoControlesGuardar();
                RefrescarToolstripLabelServicioExterno();

                Comun.MostrarMensajeDeError("Guardado con éxito.", "Guardado con éxito");
                datosGuardados = true;
            }
        }

        private void EstadoControlesGuardar()
        {
            toolStripButtonAnadir.Enabled = true;
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;
            toolStripButtonGuardar.Enabled = false;
            toolStripButtonBuscar.Enabled = true;

            if (servicioExternoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (servicioExternoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (servicioExternoBindingSource.Position + 1 == servicioExternoBindingSource.Count && servicioExternoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (servicioExternoBindingSource.Position + 1 == servicioExternoBindingSource.Count && servicioExternoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (servicioExternoBindingSource.Count > 2 && servicioExternoBindingSource.Position + 1 != servicioExternoBindingSource.Count && servicioExternoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (servicioExternoBindingSource.Position + 1 == 1 && servicioExternoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            //Botones
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarServiciosExternos.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;

            //Campos
            OcultarCampos();
        }

        //IMPRIMIR
        private void toolStripButtonImprimir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Imprimiendo...";

            PrintDocument printDocument1 = new PrintDocument();

            // Manejar el evento PrintPage para imprimir los campos y la imagen
            printDocument1.PrintPage += (sender1, e1) =>
            {
                using (var font = new Font("Times New Roman", 12))
                {
                    float y = 100;

                    // Crear un método para imprimir cada línea
                    void PrintLine(string label, string value)
                    {
                        e1.Graphics.DrawString(label + value, font, Brushes.Black, new RectangleF(50, y, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                        y += 25;
                    }

                    PrintLine("Id: ", idServicioExternoLabel1.Text);
                    PrintLine("Empresa: ", empresaTextBox.Text);
                    PrintLine("Dirección: ", direccionTextBox.Text);
                    PrintLine("Teléfono: ", telefonoTextBox.Text);
                    PrintLine("Email: ", emailTextBox.Text);
                    PrintLine("Tipo: ", tipoComboBox.Text);
                    PrintLine("Estado: ", estadoComboBox.Text);

                    PrintLine("Coste: ", costeNumericUpDown.Text);
                    PrintLine("Duración: ", duracionServicioNumericUpDown.Text);
                    PrintLine("Obra: ", obraComboBox.Text);
                    PrintLine("Descripción: ", descripcionTextBox.Text);
                }
            };

            // Mostrar el cuadro de diálogo de impresión
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.AllowPrintToFile = false;
            printDialog1.AllowSelection = false;
            printDialog1.AllowSomePages = false;
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error de impresión al imprimir el formulario", "Imprimir formulario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //INFORME
        private void toolStripButtonInforme_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Informe Servicios Externos";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformeServiciosExternos))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.BringToFront();
                    abierto = true;
                    break;
                }
            }
            if (!abierto)
            {
                InformeServiciosExternos informeServiciosExternos = new InformeServiciosExternos();
                informeServiciosExternos.ShowDialog();
            }
        }

        //BUSCAR
        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar servicio externo";
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBoxBuscar.Text))
                {
                    Comun.MostrarMensajeDeError("Introduzca un campo a buscar en el cuadro de texto.", "Introduzca un campo");
                }
                else
                {
                    //ID
                    if (toolStripComboBoxBuscarServiciosExternos.Text.Equals("Id"))
                    {
                        if (!Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un número, no letras.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (servicioExternoBindingSource.Find("IdServicioExterno", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El servicio externo no existe.", "Servicio externo no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            servicioExternoBindingSource.Position = servicioExternoBindingSource.Find("IdServicioExterno", toolStripTextBoxBuscar.Text);
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                    }

                    //Empresa
                    if (toolStripComboBoxBuscarServiciosExternos.Text.Equals("Empresa"))
                    {
                        if (servicioExternoBindingSource.Find("Empresa", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El servicio externo no existe.", "Servicio externo no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            servicioExternoBindingSource.Position = servicioExternoBindingSource.Find("Empresa", toolStripTextBoxBuscar.Text);
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                    }

                }
                RefrescarToolstripLabelServicioExterno();

                EstadoControlesBuscar();
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (servicioExternoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (servicioExternoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (servicioExternoBindingSource.Position + 1 == servicioExternoBindingSource.Count && servicioExternoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (servicioExternoBindingSource.Position + 1 == servicioExternoBindingSource.Count && servicioExternoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (servicioExternoBindingSource.Count > 2 && servicioExternoBindingSource.Position + 1 != servicioExternoBindingSource.Count && servicioExternoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (servicioExternoBindingSource.Position + 1 == 1 && servicioExternoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }
        }

        //ACEPTAR
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();
                servicioExternoBindingSource.EndEdit();
                EstadoControlesAceptar();
                datosGuardados = false;
            }
        }

        private void EstadoControlesAceptar()
        {
            HabilitarControlesComunes();
            toolStripButtonGuardar.Enabled = true;
        }

        //CANCELAR
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Quiere cancelar la operación?", "Confirmación botón cancelar", MessageBoxButtons.OKCancel);
            if (resultado == DialogResult.OK)
            {
                servicioExternoBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
                datosGuardados = true;
            }
            RefrescarToolstripLabelServicioExterno();
        }

        private void EstadoControlesCancelar()
        {
            HabilitarControlesComunes();
        }

        //MÉTODOS
        private void RefrescarToolstripLabelServicioExterno()
        {
            this.toolstripLabelContadorServicioExterno.Text = $"Servicio externo {servicioExternoBindingSource.Position + 1} de {servicioExternoBindingSource.Count}";
        }

        private void HabilitarControlesComunes()
        {
            // Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarServiciosExternos.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;

            // Campos
            OcultarCampos();

            // Botones
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            // Flechas
            ActualizarEstadoFlechas();
        }

        private void ActualizarEstadoFlechas()
        {
            bool tieneRegistros = servicioExternoBindingSource.Count > 0;
            bool esElPrimero = servicioExternoBindingSource.Position == 0;
            bool esElUltimo = servicioExternoBindingSource.Position == servicioExternoBindingSource.Count - 1;

            toolStripButtonInicio.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonAnterior.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonSiguiente.Enabled = !esElUltimo && tieneRegistros;
            toolStripButtonFinal.Enabled = !esElUltimo && tieneRegistros;
        }

        private void OcultarCampos()
        {
            idServicioExternoLabel1.Enabled = false;
            empresaTextBox.Enabled = false;
            direccionTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            tipoComboBox.Enabled = false;
            estadoComboBox.Enabled = false;

            costeNumericUpDown.Enabled = false;
            duracionServicioNumericUpDown.Enabled = false;
            obraComboBox.Enabled = false;
            descripcionTextBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idServicioExternoLabel1.Enabled = true;
            empresaTextBox.Enabled = true;
            direccionTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            tipoComboBox.Enabled = true;
            estadoComboBox.Enabled = true;

            costeNumericUpDown.Enabled = true;
            duracionServicioNumericUpDown.Enabled = true;
            obraComboBox.Enabled = true;
            descripcionTextBox.Enabled = true;
        }

        private void duracionServicioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (duracionServicioNumericUpDown.Value == 1)
            {
                label1.Text = "mes";
            }
            else
            {
                label1.Text = "meses";
            }
        }

        //COMPROBAR DATOS
        private bool ComprobarDatosIntroducidos()
        {
            //Empresa 
            if (string.IsNullOrWhiteSpace(empresaTextBox.Text))
            {
                errorProvider1.SetError(empresaTextBox, " Empresa obligatoria");
                empresaTextBox.Clear();
                return false;
            }

            //Telefono
            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                errorProvider1.SetError(telefonoTextBox, " Teléfono obligatorio");
                telefonoTextBox.Clear();
                return false;
            }
            else if (!Comun.ComprobarTelefono(telefonoTextBox.Text))
            {
                errorProvider1.SetError(telefonoTextBox, "Formato de teléfono no válido, debe empezar por 6,7 o 9 y contener 9 números");
                telefonoTextBox.Clear();
                return false;
            }

            //Email
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                errorProvider1.SetError(emailTextBox, " Email obligatorio");
                emailTextBox.Clear();
                return false;
            }
            else if (!(Comun.EsDireccionCorreoValida(emailTextBox.Text)) && emailTextBox.Text.Length != 0)
            {
                errorProvider1.SetError(emailTextBox, "Formato de email no válido");
                emailTextBox.Clear();
                return false;
            }

            //si todo es valido
            return true;
        }

        private void CargarObras()
        {
            ObraTableAdapter obraTableAdapter = new ObraTableAdapter();
            ObraDataTable obrasData = obraTableAdapter.GetData();

            // Configurar el ComboBox
            obraComboBox.DataSource = obrasData;
            obraComboBox.DisplayMember = "Ubicacion";

            if (obraComboBox.Items.Count > 0)
            {
                obraComboBox.SelectedIndex = 0;
            }
            else
            {
                obraComboBox.Text = "No hay obras";
            }
        }

        //Atajos de teclado
        private void ServicioExterno_KeyDown(object sender, KeyEventArgs e)
        {
            //Añadir
            if (e.Control && e.KeyCode == Keys.A)
            {
                toolStripButtonAnadir_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Eliminar (control suprimir)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                toolStripButtonEliminar_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Editar
            if (e.Control && e.KeyCode == Keys.E)
            {
                toolStripButtonEditar_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Guardar
            if (e.Control && e.KeyCode == Keys.S)
            {
                toolStripButtonGuardar_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Imprimir
            if (e.Control && e.KeyCode == Keys.P)
            {
                toolStripButtonImprimir_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            // Informe
            if (e.Control && e.KeyCode == Keys.I)
            {
                toolStripButtonInforme_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Buscar
            if (e.Control && e.KeyCode == Keys.F)
            {
                toolStripButtonBuscar_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Cancelar
            if (e.KeyCode == Keys.Escape)
            {
                buttonCancelar_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }
        }

        private void ServicioExterno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.servicioExternoBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);
                    }
                    else
                    {
                        Comun.MostrarMensajeDeError("Hay datos erróneos porfavor reviselo", "Error al guardar");
                        // Cancela el cierre del formulario
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
