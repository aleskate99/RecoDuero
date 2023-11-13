using GestionRecoDuero.RecoDueroDataSetTableAdapters;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static GestionRecoDuero.RecoDueroDataSet;
using System.Drawing;

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
            // TODO: esta línea de código carga datos en la tabla 'recoDueroDataSet.DetalleFactura' Puede moverla o quitarla según sea necesario.
            this.detalleFacturaTableAdapter.Fill(this.recoDueroDataSet.DetalleFactura);
            this.facturaTableAdapter.Fill(this.recoDueroDataSet.Factura);
            AjustarImagenes();
            EstadoControlesInicioApp();
            RefrescarToolstripLabelFactura();
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
            //Botones
            toolStripButtonInicio.Enabled = false;
            toolStripButtonAnterior.Enabled = false;

            //Campos
            OcultarCampos();

            //Aceptar y cancelar invisibles hasta que se realice una operación
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            if (facturaBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarFacturas.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            else if (facturaBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarFacturas.Enabled = true;
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
                toolStripComboBoxBuscarFacturas.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            // Comprobar si no hay registros en el origen de datos
            if (facturaBindingSource.Count <= 0)
                return;

            // Mover el cursor del origen de datos al registro especificado por 'index'
            facturaBindingSource.Position = indice;

            // Determinar si el registro actual es el primer o el último
            bool enPrimerRegistro = facturaBindingSource.Position == 0;
            bool enUltimoRegistro = facturaBindingSource.Position == facturaBindingSource.Count - 1;

            // Habilitar o deshabilitar los botones de navegación según la posición del registro
            toolStripButtonInicio.Enabled = !enPrimerRegistro;
            toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            toolStripButtonFinal.Enabled = !enUltimoRegistro;

            RefrescarToolstripLabelFactura();
        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            NavegarRegistro(facturaBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            NavegarRegistro(facturaBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            NavegarRegistro(facturaBindingSource.Count - 1); // Ir al último registro
        }

        //AÑADIR
        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir factura";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            facturaBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();

            RefrescarToolstripLabelFactura();
            datosGuardados = false;
        }

        private void HabilitarControlesEnAnadir()
        {
            //Botones
            buttonAceptar.Visible = true;
            buttonCancelar.Visible = true;
            toolStripButtonGuardar.Enabled = false;

            //Campos
            MostrarCampos();

            //ComboBox por defecto a una opción
            estadoPagoComboBox.SelectedIndex = 0;
            metodoPagoComboBox.SelectedIndex = 0;

            //Imagen
            //imagenPictureBox.Image = 
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
            toolStripComboBoxBuscarFacturas.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //ELIMINAR
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar factura";

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar la factura?", "Confirmación eliminar factura", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (facturaBindingSource.Count <= 0)
                {
                    Comun.MostrarMensajeDeError("No se puede eliminar la factura porque no existe en la base de datos.", "Error en la eliminación de una factura");
                }
                else
                {
                    facturaBindingSource.RemoveCurrent();
                    facturaBindingSource.EndEdit();
                    this.facturaTableAdapter.Update(this.recoDueroDataSet);
                }

                if (facturaBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (facturaBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (facturaBindingSource.Position + 1 == facturaBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }

            RefrescarToolstripLabelFactura();
        }

        //EDITAR
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar factura";
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
            toolStripComboBoxBuscarFacturas.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //GUARDAR
        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();

                facturaBindingSource.EndEdit();
                this.facturaTableAdapter.Update(this.recoDueroDataSet);

                EstadoControlesGuardar();
                RefrescarToolstripLabelFactura();

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

            if (facturaBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (facturaBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (facturaBindingSource.Position + 1 == facturaBindingSource.Count && facturaBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (facturaBindingSource.Position + 1 == facturaBindingSource.Count && facturaBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (facturaBindingSource.Count > 2 && facturaBindingSource.Position + 1 != facturaBindingSource.Count && facturaBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (facturaBindingSource.Position + 1 == 1 && facturaBindingSource.Count > 1)
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
            toolStripComboBoxBuscarFacturas.Enabled = true;
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

                    PrintLine("Id Factura: ", idFacturaLabel1.Text);
                    PrintLine("Obra: ", obraComboBox.Text);
                    PrintLine("Cliente: ", clienteComboBox.Text);
                    PrintLine("Responsable: ", empleadoComboBox.Text);
                    PrintLine("Total factura: ", totalFacturaTextBox.Text);

                    PrintLine("Fecha de emisión: ", fechaEmisionDateTimePicker.Text);
                    PrintLine("Estado: ", estadoPagoComboBox.Text);
                    PrintLine("Método: ", metodoPagoComboBox.Text);
                    PrintLine("Impuestos: ", impuestosTextBox.Text);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error de impresión al imprimir el formulario", "Imprimir formulario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //INFORME
        private void toolStripButtonInforme_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Informe Facturas";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformeFacturas))
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
                InformeFacturas informeFacturas = new InformeFacturas();
                informeFacturas.ShowDialog();
            }
        }

        //BUSCAR
        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar facturas";
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBoxBuscar.Text))
                {
                    Comun.MostrarMensajeDeError("Introduzca un campo a buscar en el cuadro de texto.", "Introduzca un campo");
                }
                else
                {
                    //ID
                    if (toolStripComboBoxBuscarFacturas.Text.Equals("Id"))
                    {
                        if (!Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un número, no letras.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (facturaBindingSource.Find("IdFactura", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("La factura no existe.", "Factura no encontrada");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            facturaBindingSource.Position = facturaBindingSource.Find("IdFactura", toolStripTextBoxBuscar.Text);
                        }
                    }

                }
                RefrescarToolstripLabelFactura();

                EstadoControlesBuscar();
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (facturaBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (facturaBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (facturaBindingSource.Position + 1 == facturaBindingSource.Count && facturaBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (facturaBindingSource.Position + 1 == facturaBindingSource.Count && facturaBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (facturaBindingSource.Count > 2 && facturaBindingSource.Position + 1 != facturaBindingSource.Count && facturaBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (facturaBindingSource.Position + 1 == 1 && facturaBindingSource.Count > 1)
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
                facturaBindingSource.EndEdit();
                EstadoControlesAceptar();
                datosGuardados = false;
            }

            //MAESTRO DETALLE 
            buttonAniadirLinea.Enabled = true;
            buttonBorrarLinea.Enabled = true;
            buttonEditarLinea.Enabled = true;
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
                facturaBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
                datosGuardados = false;
            }

            RefrescarToolstripLabelFactura();
        }

        private void EstadoControlesCancelar()
        {
            HabilitarControlesComunes();
        }

        //MÉTODOS
        private void RefrescarToolstripLabelFactura()
        {
            this.toolstripLabelContadorFacturas.Text = $"Factura {facturaBindingSource.Position + 1} de {facturaBindingSource.Count}";
        }

        private void HabilitarControlesComunes()
        {
            // Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarFacturas.Enabled = true;
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
            bool tieneRegistros = facturaBindingSource.Count > 0;
            bool esElPrimero = facturaBindingSource.Position == 0;
            bool esElUltimo = facturaBindingSource.Position == facturaBindingSource.Count - 1;

            toolStripButtonInicio.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonAnterior.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonSiguiente.Enabled = !esElUltimo && tieneRegistros;
            toolStripButtonFinal.Enabled = !esElUltimo && tieneRegistros;
        }

        private void OcultarCampos()
        {
            idFacturaLabel1.Enabled = false;
            obraComboBox.Enabled = false;
            clienteComboBox.Enabled = false;
            empleadoComboBox.Enabled = false;
            totalFacturaTextBox.Enabled = false;

            fechaEmisionDateTimePicker.Enabled = false;
            estadoPagoComboBox.Enabled = false;
            metodoPagoComboBox.Enabled = false;
            impuestosTextBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idFacturaLabel1.Enabled = true;
            obraComboBox.Enabled = true;
            clienteComboBox.Enabled = true;
            empleadoComboBox.Enabled = true;
            totalFacturaTextBox.Enabled = true;

            fechaEmisionDateTimePicker.Enabled = true;
            estadoPagoComboBox.Enabled = true;
            metodoPagoComboBox.Enabled = true;
            impuestosTextBox.Enabled = true;
        }

        private void CargarResponsableEmpleados()
        {
            EmpleadoTableAdapter empleadoTableAdapter = new EmpleadoTableAdapter();
            RecoDueroDataSet.EmpleadoDataTable empleadosData = empleadoTableAdapter.GetData();

            empleadosData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");

            // Configurar el ComboBox
            empleadoComboBox.DataSource = empleadosData;
            empleadoComboBox.DisplayMember = "NombreCompleto";

            if (empleadoComboBox.Items.Count > 0)
            {
                empleadoComboBox.SelectedIndex = 0;
            }
            else
            {
                empleadoComboBox.Text = "No hay empleados";
            }
        }

        private void CargarClientes()
        {
            ClienteTableAdapter clienteTableAdapter = new ClienteTableAdapter();
            ClienteDataTable clientesData = clienteTableAdapter.GetData();

            clientesData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");

            // Configurar el ComboBox
            clienteComboBox.DataSource = clientesData;
            clienteComboBox.DisplayMember = "NombreCompleto";

            if (clienteComboBox.Items.Count > 0)
            {
                clienteComboBox.SelectedIndex = 0;
            }
            else
            {
                clienteComboBox.Text = "No hay clientes";
            }
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

        //COMPROBAR DATOS
        private bool ComprobarDatosIntroducidos()
        {
            //si todo es valido
            return true;
        }

        /////////////////////    MAESTRO DETALLE

        private void estadoControlesInicioDetalle()
        {
            //Campos
            //idDetallePresupuestoLabel1.Enabled = false;
            //idPresupuestoComboBox.Enabled = false;
            //obraComboBox.Enabled = false;
            //costeNumericUpDownDetalle.Enabled = false;

            //Botones
            buttonAceptarDetalleFactura.Visible = false;
            buttonCancelarDetalleFactura.Visible = false;
        }

        private void buttonAniadirLinea_Click(object sender, EventArgs e)
        {
            //detalleFacturaBindingSource.AddNew();

            //Campos
            //idDetallePresupuestoLabel1.Enabled = true;
            //idPresupuestoComboBox.Enabled = true;
            //obraComboBox.Enabled = true;
            //costeNumericUpDownDetalle.Enabled = true;

            //Botones
            buttonAceptarDetalleFactura.Visible = true;
            buttonCancelarDetalleFactura.Visible = true;
        }

        private void buttonBorrarLinea_Click(object sender, EventArgs e)
        {
            //if (detalleFacturaBindingSource.Count <= 0)
            //{
            //    MessageBox.Show("No se puede eliminar la línea porque no hay ninguna ", "Error en la eliminación de un presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    detalleFacturaBindingSource.RemoveCurrent();
            //    this.facturaTableAdapter.Update(this.recoDueroDataSet);
            //}
        }

        private void buttonEditarLinea_Click(object sender, EventArgs e)
        {
            //Campos
            //idDetallePresupuestoLabel1.Enabled = true;
            //idPresupuestoComboBox.Enabled = true;
            //obraComboBox.Enabled = true;
            //costeNumericUpDownDetalle.Enabled = true;

            //Botones
            buttonAceptarDetalleFactura.Visible = true;
            buttonCancelarDetalleFactura.Visible = true;
        }

        private void buttonAceptarDetalleFactura_Click(object sender, EventArgs e)
        {
            //if (ComprobarDatosIntroducidosDetalle())
            //{
            //    this.detalleFacturaBindingSource.EndEdit();
            //    this.detalleFacturaTableAdapter.Update(this.recoDueroDataSet);
            //    this.facturaTableAdapter.Update(this.recoDueroDataSet);
            //    //precioTotalLabel1.Text = (Convert.ToInt32(precioTotalLabel1.Text) + Convert.ToInt32(precioTextBox.Text)).ToString();

            //    //Campos
            //    //idDetallePresupuestoLabel1.Enabled = false;
            //    //idPresupuestoComboBox.Enabled = false;
            //    //obraComboBox.Enabled = false;
            //    //costeNumericUpDownDetalle.Enabled = false;

            //    //Botones
            //    buttonAceptarDetalleFactura.Visible = false;
            //    buttonCancelarDetalleFactura.Visible = false;
            //}
        }

        private void buttonCancelarDetalleFactura_Click(object sender, EventArgs e)
        {
            //this.detalleFacturaBindingSource.CancelEdit();

            //Campos
            //idDetallePresupuestoLabel1.Enabled = false;
            //idPresupuestoComboBox.Enabled = false;
            //obraComboBox.Enabled = false;
            //costeNumericUpDownDetalle.Enabled = false;

            //Botones
            buttonAceptarDetalleFactura.Visible = false;
            buttonCancelarDetalleFactura.Visible = false;
        }

        private bool ComprobarDatosIntroducidosDetalle()
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

        private void Factura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.facturaBindingSource.EndEdit();
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
