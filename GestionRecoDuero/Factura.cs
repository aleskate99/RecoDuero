﻿using GestionRecoDuero.RecoDueroDataSetTableAdapters;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static GestionRecoDuero.RecoDueroDataSet;
using System.Drawing;
using System.Data;
using System.Linq;

namespace GestionRecoDuero
{
    public partial class Factura : Form
    {
        //GUARDAR
        private bool datosGuardados = true;
        private bool datosDetalleGuardados = true;

        //INSERTAR
        private bool insertando = false;

        //EDITAR
        private float costeAdicional = 0;
        private float costeTotalFinal = 0;
        private int idDetalleFactura = 0;
        private int idFacturaInicialEditado = 0;
        private float costeInicialEditado = 0;
        private int idFacturaFinalEditado = 0;
        private float costeFinalEditado = 0;
        private float costeTotalInicialEditado = 0;
        private float costeTotalFinalEditado = 0;
        private bool editando = false;
        private bool editandoIdFactura = false;
        private bool editandoIdFInicial = false;
        private bool editandoIdFFinal = false;
        private bool editandoCoste = false;

        //BORRAR
        private bool borrando = false;
        private float costeBorrado = 0;
        private int idFactura = 0;
        private float costeTotal = 0;

        public Factura()
        {
            InitializeComponent();
            KeyPreview = true;

            //Redondear controles
            Bordes.BordesRedondosBoton(buttonAceptar);
            Bordes.BordesRedondosBoton(buttonCancelar);
            Bordes.BordesRedondosBoton(buttonAceptarDetalleFactura);
            Bordes.BordesRedondosBoton(buttonCancelarDetalleFactura);
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            this.facturaTableAdapter.Fill(this.recoDueroDataSet.Factura);
            this.detalleFacturaTableAdapter.Fill(this.recoDueroDataSet.DetalleFactura);
            toolStripStatusLabel1.Text = "Inicio";

            AjustarImagenes();

            EstadoControlesInicioApp();
            ControlarBotonesDetalle();

            RefrescarToolstripLabelFactura();

            CargarPresupuestos();
            CargarClientes(); //Para cargar la info de los clientes
            CargarResponsableEmpleados(); //Para cargar el responsable

            CargarObras(); //Para cargar la ubicación de las obras
            CargarFacturas(); // Para cargar los ids de las facturas
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

            // Actualiza la fuente de datos con el valor predeterminado antes de guardar
            if (idPresupuestoComboBox.Items.Count > 0)
            {
                CargarPresupuestos();
                int idPresupuesto;

                if (int.TryParse(idPresupuestoComboBox.SelectedValue.ToString(), out idPresupuesto))
                {
                    ((DataRowView)facturaBindingSource.Current)["IdPresupuesto"] = idPresupuesto;
                }

            }

            CargarClientes();
            ((DataRowView)facturaBindingSource.Current)["Cliente"] = clienteLabel2.Text;

            CargarResponsableEmpleados();
            ((DataRowView)facturaBindingSource.Current)["Empleado"] = empleadoLabel2.Text;
 
            ((DataRowView)facturaBindingSource.Current)["FechaEmision"] = fechaEmisionDateTimePicker.Value;
            ((DataRowView)facturaBindingSource.Current)["EstadoPago"] = estadoPagoComboBox.SelectedItem.ToString();
            ((DataRowView)facturaBindingSource.Current)["MetodoPago"] = metodoPagoComboBox.SelectedItem.ToString();
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
            totalFacturaLabel2.Text = "0";
            fechaEmisionDateTimePicker.Value = DateTime.Today;
            estadoPagoComboBox.SelectedIndex = 0;
            metodoPagoComboBox.SelectedIndex = 0;
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

            //MAESTRO DETALLE 
            buttonAniadirLinea.Enabled = false;
            buttonBorrarLinea.Enabled = false;
            buttonEditarLinea.Enabled = false;
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

            //MAESTRO DETALLE 
            buttonAniadirLinea.Enabled = false;
            buttonBorrarLinea.Enabled = false;
            buttonEditarLinea.Enabled = false;

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
                EstadoControlesGuardar();
                RefrescarToolstripLabelFactura();

                facturaBindingSource.EndEdit();
                this.facturaTableAdapter.Update(this.recoDueroDataSet);
                this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);

                CargarFacturas();

                if (detalleFacturaBindingSource.Count <= 0)
                {
                    //MAESTRO DETALLE 
                    buttonAniadirLinea.Enabled = true;
                    buttonBorrarLinea.Enabled = false;
                    buttonEditarLinea.Enabled = false;
                }
                else
                {
                    //MAESTRO DETALLE 
                    buttonAniadirLinea.Enabled = true;
                    buttonBorrarLinea.Enabled = true;
                    buttonEditarLinea.Enabled = true;
                }

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
                    PrintLine("Id Presupuesto: ", idPresupuestoComboBox.Text);
                    PrintLine("Cliente: ", clienteLabel2.Text);
                    PrintLine("Responsable: ", empleadoLabel2.Text);
                    PrintLine("Total factura: ", totalFacturaLabel2.Text);

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
                catch (Exception)
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
                CargarFacturas();
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
                if (facturaBindingSource.Count > 0)
                {
                    if (detalleFacturaBindingSource.Count <= 0)
                    {
                        //MAESTRO DETALLE 
                        buttonAniadirLinea.Enabled = true;
                        buttonBorrarLinea.Enabled = false;
                        buttonEditarLinea.Enabled = false;
                    }
                    else
                    {
                        //MAESTRO DETALLE 
                        buttonAniadirLinea.Enabled = true;
                        buttonBorrarLinea.Enabled = true;
                        buttonEditarLinea.Enabled = true;
                    }
                }
                else
                {
                    //MAESTRO DETALLE 
                    buttonAniadirLinea.Enabled = false;
                    buttonBorrarLinea.Enabled = false;
                    buttonEditarLinea.Enabled = false;
                }

                facturaBindingSource.CancelEdit();
                EstadoControlesCancelar();

                errorProvider1.Clear();
                datosGuardados = true;
                RefrescarToolstripLabelFactura();
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
            idPresupuestoComboBox.Enabled = false;
            empleadoLabel2.Enabled = false;
            clienteLabel2.Enabled = false;
            totalFacturaLabel2.Enabled = false;

            fechaEmisionDateTimePicker.Enabled = false;
            estadoPagoComboBox.Enabled = false;
            metodoPagoComboBox.Enabled = false;
            impuestosTextBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idFacturaLabel1.Enabled = true;
            idPresupuestoComboBox.Enabled = true;
            empleadoLabel2.Enabled = true;
            clienteLabel2.Enabled = true;
            totalFacturaLabel2.Enabled = true;

            fechaEmisionDateTimePicker.Enabled = true;
            estadoPagoComboBox.Enabled = true;
            metodoPagoComboBox.Enabled = true;
            impuestosTextBox.Enabled = true;
        }

        private void CargarResponsableEmpleados()
        {
            EmpleadoTableAdapter empleadoTableAdapter = new EmpleadoTableAdapter();
            EmpleadoDataTable empleadosData = empleadoTableAdapter.GetData();

            PresupuestoTableAdapter presupuestoTableAdapter = new PresupuestoTableAdapter();
            PresupuestoDataTable presupuestosData = presupuestoTableAdapter.GetData();

            empleadosData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");

            if (empleadosData.Rows.Count > 0)
            {
                int indiceIdPresupuesto = 0;
                for (int i = 0; i < presupuestosData.Count; i++)
                {
                    if (i == idPresupuestoComboBox.SelectedIndex)
                    {
                        indiceIdPresupuesto = i;
                    }
                    
                }
                // Obtener el nombre completo del primer cliente
                string nombreCompleto = empleadosData.Rows[indiceIdPresupuesto]["NombreCompleto"].ToString();

                // Asignar el nombre completo al Label
                empleadoLabel2.Text = nombreCompleto;
            }
            else
            {
                empleadoLabel2.Text = "No hay empleados";
            }
        }

        private void CargarClientes()
        {
            ClienteTableAdapter clienteTableAdapter = new ClienteTableAdapter();
            ClienteDataTable clientesData = clienteTableAdapter.GetData();

            PresupuestoTableAdapter presupuestoTableAdapter = new PresupuestoTableAdapter();
            PresupuestoDataTable presupuestosData = presupuestoTableAdapter.GetData();

            clientesData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");

            //if (clientesData.Rows.Count > 0)
            //{
            int indiceIdPresupuesto = -1;
                for (int i = 0; i < presupuestosData.Count; i++)
                {
                    if (i == idPresupuestoComboBox.SelectedIndex)
                    {
                        indiceIdPresupuesto = i;
                        break;
                    }

                }

                if (clientesData.Rows.Count > 0 && indiceIdPresupuesto >= 0 && indiceIdPresupuesto < clientesData.Rows.Count)
                {
                    // Obtener el nombre completo del primer cliente
                    string nombreCompleto = clientesData.Rows[indiceIdPresupuesto]["NombreCompleto"].ToString();

                    // Asignar el nombre completo al Label
                    clienteLabel2.Text = nombreCompleto;

                }
                else
                {
                    clienteLabel2.Text = "No hay clientes";
                }
            //}
            
        }

        private void CargarFacturas()
        {
            FacturaTableAdapter facturaTableAdapter = new FacturaTableAdapter();
            FacturaDataTable facturasData = facturaTableAdapter.GetData();

            // Configurar el ComboBox
            idFacturaComboBox.DataSource = facturasData;
            idFacturaComboBox.DisplayMember = "IdFactura";

            if (idFacturaComboBox.Items.Count > 0)
            {
                idFacturaComboBox.SelectedIndex = 0;
            }
            else
            {
                idFacturaComboBox.Text = "No hay presupuestos";
            }
        }

        private void CargarObras()
        {
            ObraTableAdapter obraTableAdapter = new ObraTableAdapter();
            ObraDataTable obrasData = obraTableAdapter.GetData();

            // Configurar el ComboBox
            obraDetalleComboBox.DataSource = obrasData;
            obraDetalleComboBox.DisplayMember = "Ubicacion";

            if (obraDetalleComboBox.Items.Count > 0)
            {
                obraDetalleComboBox.SelectedIndex = 0;
            }
            else
            {
                obraDetalleComboBox.Text = "No hay obras";
            }
        }

        private void CargarPresupuestos()
        {
            PresupuestoTableAdapter presupuestoTableAdapter = new PresupuestoTableAdapter();
            PresupuestoDataTable presupuestosData = presupuestoTableAdapter.GetData();

            // Configurar el ComboBox
            idPresupuestoComboBox.DataSource = presupuestosData;
            idPresupuestoComboBox.DisplayMember = "IdPresupuesto";

            if (idPresupuestoComboBox.Items.Count > 0)
            {
                idPresupuestoComboBox.SelectedIndex = 0;
            }
            else
            {
                idPresupuestoComboBox.Text = "No hay presupuestos";
            }
        }

        private void idPresupuestoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarClientes();
            CargarResponsableEmpleados();
        }

        //COMPROBAR DATOS
        private bool ComprobarDatosIntroducidos()
        {
            //si todo es valido
            return true;
        }

        private void fechaEmisionDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = fechaEmisionDateTimePicker.Value;

            if (fechaSeleccionada > DateTime.Today)
            {
                Comun.MostrarMensajeDeError("No puede seleccionar una fecha futura al día de hoy.", "Error al seleccionar fecha");
                fechaEmisionDateTimePicker.Value = DateTime.Today;
            }
        }

        /////////////////////    MAESTRO DETALLE

        private void ControlarBotonesDetalle()
        {
            if (facturaBindingSource.Count <= 0)
            {
                buttonAniadirLinea.Enabled = false;
                buttonBorrarLinea.Enabled = false;
                buttonEditarLinea.Enabled = false;

                OcultarControlesDetalle();
            }

            if (facturaBindingSource.Count > 0)
            {
                if (detalleFacturaBindingSource.Count <= 0)
                {
                    //MAESTRO DETALLE 
                    buttonAniadirLinea.Enabled = true;
                    buttonBorrarLinea.Enabled = false;
                    buttonEditarLinea.Enabled = false;
                }
                else
                {
                    //MAESTRO DETALLE 
                    buttonAniadirLinea.Enabled = true;
                    buttonBorrarLinea.Enabled = true;
                    buttonEditarLinea.Enabled = true;
                }
                OcultarControlesDetalle();
                CargarFacturas();
            }
        }

        private void buttonAniadirLinea_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir detalle factura";
            insertando = true;

            //MAESTRO DETALLE 
            buttonAniadirLinea.Enabled = false;
            buttonBorrarLinea.Enabled = false;
            buttonEditarLinea.Enabled = false;

            //BOTONES PRINCIPALES
            toolStripButtonAnadir.Enabled = false;
            toolStripButtonEliminar.Enabled = false;
            toolStripButtonEditar.Enabled = false;

            if (datosGuardados == true)
            {
                detalleFacturaDataGridView.ReadOnly = false;
                //detalleFacturaDataGridView.AllowUserToAddRows = true;

                detalleFacturaBindingSource.AddNew();
                HabilitarControlesEnAnadirLinea();

                // Actualiza la fuente de datos con el valor predeterminado antes de guardar
                if (idFacturaComboBox.Items.Count > 0)
                {
                    CargarFacturas();
                    int idFactura;

                    if (int.TryParse(idFacturaComboBox.SelectedValue.ToString(), out idFactura))
                    {
                        ((DataRowView)detalleFacturaBindingSource.Current)["IdFactura"] = idFactura;
                    }
                }

                if (obraDetalleComboBox.Items.Count > 0)
                {
                    CargarObras();
                    ((DataRowView)detalleFacturaBindingSource.Current)["Obra"] = obraDetalleComboBox.SelectedItem.ToString();
                }              

                ((DataRowView)detalleFacturaBindingSource.Current)["Coste"] = (float)costeNumericUpDownDetalle.Value;

                detalleFacturaDataGridView.ReadOnly = true;

                datosDetalleGuardados = false;
            }
        }

        private void HabilitarControlesEnAnadirLinea()
        {
            MostarControlesDetalle();
            costeNumericUpDownDetalle.Value = 1;
        }

        private void buttonBorrarLinea_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Borrar detalle factura";

            if (detalleFacturaBindingSource.Count <= 0)
            {
                MessageBox.Show("No se puede eliminar la línea porque no hay ninguna ", "Error en la eliminación de un presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var resultado = MessageBox.Show("¿Está seguro que desea eliminar el detalle de la factura?", "Confirmación eliminar detalle de la factura", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    borrando = true;

                    DetalleFacturaTableAdapter detalleFacturaTableAdapter = new DetalleFacturaTableAdapter();
                    DetalleFacturaDataTable detalleFacturaData = detalleFacturaTableAdapter.GetData();

                    double[] costesDetalleFactura = detalleFacturaData.Select(p => p.Coste).ToArray();
                    costeBorrado = (float)costesDetalleFactura[detalleFacturaDataGridView.CurrentRow.Index];

                    int[] idsFacturaDF = detalleFacturaData.Select(p => p.IdFactura).ToArray();
                    idFactura = idsFacturaDF[detalleFacturaDataGridView.CurrentRow.Index];

                    FacturaTableAdapter facturaTableAdapter = new FacturaTableAdapter();
                    FacturaDataTable facturaData = facturaTableAdapter.GetData();

                    int[] idsFacturaF = facturaData.Select(p => p.IdFactura).ToArray();
                    double[] costesTotales = facturaData.Select(p => p.TotalFactura).ToArray();

                    int indiceBorrado = 0;
                    for (int i = 0; i < idsFacturaF.Length; i++)
                    {
                        if (idsFacturaF[i] == idFactura)
                        {
                            indiceBorrado = i;
                            break;
                        }
                    }
                    costeTotal = (float)costesTotales[indiceBorrado];

                    CalcularCosteTotal();

                    detalleFacturaBindingSource.RemoveCurrent();
                    detalleFacturaBindingSource.EndEdit();
                    this.detalleFacturaTableAdapter.Update(this.recoDueroDataSet);

                    facturaBindingSource.EndEdit();
                    this.facturaTableAdapter.Update(this.recoDueroDataSet);

                    ControlarBotonesDetalle();
                }
            }
        }

        private void buttonEditarLinea_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar detalle factura";
            editando = true;

            if (detalleFacturaBindingSource.Count > 0)
            {
                //MAESTRO DETALLE 
                buttonAniadirLinea.Enabled = true;
                buttonBorrarLinea.Enabled = true;
                buttonEditarLinea.Enabled = true;

                detalleFacturaDataGridView.ReadOnly = false;
                //detalleFacturaDataGridView.AllowUserToAddRows = true;

                MostarControlesDetalle();

                detalleFacturaDataGridView.ReadOnly = true;

                datosDetalleGuardados = false;

                costeInicialEditado = (float)costeNumericUpDownDetalle.Value;
                idFacturaInicialEditado = int.Parse(idPresupuestoComboBox.Text.ToString());
            }
            else
            {
                //MAESTRO DETALLE 
                buttonAniadirLinea.Enabled = true;
                buttonBorrarLinea.Enabled = false;
                buttonEditarLinea.Enabled = false;
            }

            //BOTONES PRINCIPALES
            toolStripButtonAnadir.Enabled = false;
            toolStripButtonEliminar.Enabled = false;
            toolStripButtonEditar.Enabled = false;
        }

        private void buttonAceptarDetalleFactura_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidosDetalle())
            {
                CalcularCosteTotal();

                this.detalleFacturaBindingSource.EndEdit();
                this.detalleFacturaTableAdapter.Update(this.recoDueroDataSet);

                this.facturaBindingSource.EndEdit();
                this.facturaTableAdapter.Update(this.recoDueroDataSet);

                OcultarControlesDetalle();

                //MAESTRO DETALLE 
                buttonAniadirLinea.Enabled = true;
                buttonBorrarLinea.Enabled = true;
                buttonEditarLinea.Enabled = true;

                //BOTONES PRINCIPALES
                toolStripButtonAnadir.Enabled = true;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;

                datosDetalleGuardados = true;
            }
        }

        private void buttonCancelarDetalleFactura_Click(object sender, EventArgs e)
        {
            this.detalleFacturaBindingSource.CancelEdit();
            OcultarControlesDetalle();

            //MAESTRO DETALLE 
            buttonAniadirLinea.Enabled = true;
            buttonBorrarLinea.Enabled = true;
            buttonEditarLinea.Enabled = true;

            //BOTONES PRINCIPALES
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonEditar.Enabled = true;

            errorProvider1.Clear();
        }

        //TODO: ENTENDER COMO FUNCIONA
        private void CalcularCosteTotal()
        {
            DetalleFacturaTableAdapter detalleFacturaTableAdapter = new DetalleFacturaTableAdapter();
            DetalleFacturaDataTable detalleFacturaData = detalleFacturaTableAdapter.GetData();

            FacturaTableAdapter facturaTableAdapter = new FacturaTableAdapter();
            FacturaDataTable facturasData = facturaTableAdapter.GetData();

            int[] idsDetalleFactura = detalleFacturaData.Select(p => p.IdDetalleFactura).ToArray();
            double[] costesDetalleFactura = detalleFacturaData.Select(p => p.Coste).ToArray();
            int[] idsFacturaDF = detalleFacturaData.Select(p => p.IdFactura).ToArray();

            int[] idsFacturaF = facturasData.Select(p => p.IdFactura).ToArray();
            double[] costesTotales = facturasData.Select(p => p.TotalFactura).ToArray();

            if (insertando == true)
            {
                int[] ids = facturasData.Select(p => p.IdPresupuesto).ToArray();

                foreach (int id in ids)
                {
                    if (id == ids[idFacturaComboBox.SelectedIndex])
                    {
                        totalFacturaLabel2.Text = (Convert.ToDouble(totalFacturaLabel2.Text) + Convert.ToDouble(costeNumericUpDownDetalle.Text)).ToString();
                        this.facturaTableAdapter.Update(this.recoDueroDataSet);
                    }
                }
                insertando = false;
            }
            else if (editando == true)
            {
                costeFinalEditado = (float)costeNumericUpDownDetalle.Value;
                idFacturaFinalEditado = int.Parse(idPresupuestoComboBox.Text.ToString());

                if (costeInicialEditado != costeFinalEditado)
                {
                    editandoCoste = true;
                }

                if (idFacturaInicialEditado != idFacturaFinalEditado)
                {
                    editandoIdFactura = true;
                }

                if (editandoCoste == true)
                {
                    costeAdicional = costeFinalEditado - costeInicialEditado;

                    string costeTotalInicial = totalFacturaLabel2.Text;
                    if (float.TryParse(costeTotalInicial, out float resultado))
                    {
                        costeTotalFinal = resultado + costeAdicional;
                        totalFacturaLabel2.Text = costeTotalFinal.ToString();
                    }
                }

                if (editandoIdFactura == true)
                {
                    idDetalleFactura = idsDetalleFactura[detalleFacturaDataGridView.CurrentRow.Index];
                    float costeParcial = (float)costesDetalleFactura[detalleFacturaDataGridView.CurrentRow.Index];
                    float costeTotalInicial = 0, costeTotalFinal = 0;
                    int indiceInicial = 0, indiceFinal = 0;
                    int i = 0, j = 0;
                    foreach (int idP in idsFacturaF)
                    {
                        foreach (int idDP in idsDetalleFactura)
                        {
                            if (idP == idFacturaInicialEditado && idDP == idDetalleFactura)
                            {
                                costeTotalInicial = (float)costesTotales[i];
                                indiceInicial = i;
                                editandoIdFInicial = true;
                            }

                            if (idP == idFacturaFinalEditado && idDP == idDetalleFactura)
                            {
                                costeTotalFinal = (float)costesTotales[i];
                                indiceFinal = i;
                                editandoIdFFinal = true;
                            }

                            j++;
                        }
                        i++;
                    }
                    costeTotalInicialEditado = costeTotalInicial - costeParcial;

                    NavegarRegistro(indiceInicial);

                    if (editandoIdFInicial == true)
                    {
                        totalFacturaLabel2.Text = costeTotalInicialEditado.ToString();
                        editandoIdFInicial = false;
                    }

                    costeTotalFinalEditado = costeTotalFinal + costeParcial;

                    NavegarRegistro(indiceFinal);

                    if (editandoIdFFinal == true)
                    {
                        totalFacturaLabel2.Text = costeTotalFinalEditado.ToString();
                        editandoIdFFinal = false;
                    }
                }

                editando = false;
            }
            else if (borrando == true)
            {
                costeTotal = costeTotal - costeBorrado;
                totalFacturaLabel2.Text = costeTotal.ToString();

                this.facturaTableAdapter.Update(this.recoDueroDataSet);
                borrando = false;
            }
        }

        private bool ComprobarDatosIntroducidosDetalle()
        {
            if (costeNumericUpDownDetalle.Value <= 0)
            {
                errorProvider1.SetError(costeNumericUpDownDetalle, "El coste del detalle de la factura no puede ser 0");
                costeNumericUpDownDetalle.Value = 1;
                return false;
            }

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider1.SetError(descripcionTextBox, " Descripción obligatoria");
                descripcionTextBox.Clear();
                return false;
            }
            else if (descripcionTextBox.Text.Length > 20)
            {
                errorProvider1.SetError(descripcionTextBox, " No puede sobrepasar los 20 caracteres");
                descripcionTextBox.Clear();
                return false;
            }

            //si todo es valido
            errorProvider1.Clear();
            return true;
        }

        private void OcultarControlesDetalle()
        {
            //Campos
            idDetalleFacturaLabel1.Enabled = false;
            idFacturaComboBox.Enabled = false;
            obraDetalleComboBox.Enabled = false;
            costeNumericUpDownDetalle.Enabled = false;
            descripcionTextBox.Enabled = false;

            //Botones
            buttonAceptarDetalleFactura.Visible = false;
            buttonCancelarDetalleFactura.Visible = false;
        }

        private void MostarControlesDetalle()
        {
            //Campos
            idDetalleFacturaLabel1.Enabled = true;
            idFacturaComboBox.Enabled = true;
            obraDetalleComboBox.Enabled = true;
            costeNumericUpDownDetalle.Enabled = true;
            descripcionTextBox.Enabled = true;

            //Botones
            buttonAceptarDetalleFactura.Visible = true;
            buttonCancelarDetalleFactura.Visible = true;
        }

        private void Factura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false  || datosDetalleGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.facturaBindingSource.EndEdit();
                        this.detalleFacturaBindingSource.EndEdit();
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
