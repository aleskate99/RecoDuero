using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using GestionRecoDuero.RecoDueroDataSetTableAdapters;
using static GestionRecoDuero.RecoDueroDataSet;
using System.Data;
using System.Linq;

namespace GestionRecoDuero
{
    public partial class Presupuesto : Form
    {
        //GUARDAR
        private bool datosGuardados = true;
        private bool datosDetalleGuardados = true;

        //INSERTAR
        private bool insertando = false;

        //EDITAR
        private float costeAdicional = 0;
        private float costeTotalFinal = 0;
        private int idDetallePresupuesto = 0;
        private int idPresupuestoInicialEditado = 0;
        private float costeInicialEditado = 0;
        private int idPresupuestoFinalEditado = 0;
        private float costeFinalEditado = 0;
        private float costeTotalInicialEditado = 0;
        private float costeTotalFinalEditado = 0;
        private bool editando = false;
        private bool editandoIdPresupuesto = false;
        private bool editandoIdPInicial = false;
        private bool editandoIdPFinal = false;
        private bool editandoCoste = false;

        //BORRAR
        private bool borrando = false;
        private float costeBorrado = 0;
        private int idPresupuesto = 0;
        private float costeTotal = 0;

        public Presupuesto()
        {
            InitializeComponent();
            KeyPreview = true;

            //Redondear controles
            Bordes.BordesRedondosBoton(buttonAceptar);
            Bordes.BordesRedondosBoton(buttonCancelar);
            Bordes.BordesRedondosBoton(buttonAceptarDetallePresupuesto);
            Bordes.BordesRedondosBoton(buttonCancelarDetallePresupuesto);
        }

        private void Presupuesto_Load(object sender, EventArgs e)
        {
            this.presupuestoTableAdapter.Fill(this.recoDueroDataSet.Presupuesto);
            this.detallePresupuestoTableAdapter.Fill(this.recoDueroDataSet.DetallePresupuesto);
            toolStripStatusLabel1.Text = "Inicio";

            AjustarImagenes();

            EstadoControlesInicioApp();
            ControlarBotonesDetalle();

            CargarResponsableEmpleados();
            CargarClientes();
            CargarPresupuestos(); //Para cargar los presupuestos
            CargarObras(); //Para cargar la ubicación de las obras

            presupuestoBindingSource.EndEdit();
            detallePresupuestoBindingSource.EndEdit();
            this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
            this.detallePresupuestoTableAdapter.Update(this.recoDueroDataSet);          
            this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);

            RefrescarToolstripLabelPresupuesto();
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
            //Botones
            toolStripButtonInicio.Enabled = false;
            toolStripButtonAnterior.Enabled = false;

            //Campos
            OcultarCampos();

            //Aceptar y cancelar invisibles hasta que se realice una operación
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            if (presupuestoBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarPresupuestos.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            else if (presupuestoBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarPresupuestos.Enabled = true;
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
                toolStripComboBoxBuscarPresupuestos.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            // Comprobar si no hay registros en el origen de datos
            if (presupuestoBindingSource.Count <= 0)
                return;

            // Mover el cursor del origen de datos al registro especificado por 'index'
            presupuestoBindingSource.Position = indice;

            // Determinar si el registro actual es el primer o el último
            bool enPrimerRegistro = presupuestoBindingSource.Position == 0;
            bool enUltimoRegistro = presupuestoBindingSource.Position == presupuestoBindingSource.Count - 1;

            // Habilitar o deshabilitar los botones de navegación según la posición del registro
            toolStripButtonInicio.Enabled = !enPrimerRegistro;
            toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            toolStripButtonFinal.Enabled = !enUltimoRegistro;

            RefrescarToolstripLabelPresupuesto();
        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            NavegarRegistro(presupuestoBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            NavegarRegistro(presupuestoBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            NavegarRegistro(presupuestoBindingSource.Count - 1); // Ir al último registro
        }

        //AÑADIR
        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir presupuesto";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            presupuestoBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();

            RefrescarToolstripLabelPresupuesto();
            datosGuardados = false;

            // Actualiza la fuente de datos con el valor predeterminado antes de guardar
            if (responsableComboBox.Items.Count > 0)
            {
                CargarResponsableEmpleados();
                ((DataRowView)presupuestoBindingSource.Current)["Responsable"] = responsableComboBox.SelectedItem.ToString();
            }

            if (clienteComboBox.Items.Count > 0)
            {
                CargarClientes();
                ((DataRowView)presupuestoBindingSource.Current)["Cliente"] = clienteComboBox.SelectedItem.ToString();
            }

            ((DataRowView)presupuestoBindingSource.Current)["Estado"] = estadoComboBox.SelectedItem.ToString();
            ((DataRowView)presupuestoBindingSource.Current)["Metodo"] = metodoComboBox.SelectedItem.ToString();
            ((DataRowView)presupuestoBindingSource.Current)["FechaEmision"] = fechaEmisionDateTimePicker.Value;
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
            costeLabel3.Text = "0";
            fechaEmisionDateTimePicker.Value = DateTime.Today;
            estadoComboBox.SelectedIndex = 0;
            metodoComboBox.SelectedIndex = 0;
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
            toolStripComboBoxBuscarPresupuestos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;

            //MAESTRO DETALLE 
            buttonAniadirLinea.Enabled = false;
            buttonBorrarLinea.Enabled = false;
            buttonEditarLinea.Enabled = false;
        }

        //ELIMINAR
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar presupuesto";

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el presupuesto?", "Confirmación eliminar presupuesto", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (presupuestoBindingSource.Count <= 0)
                {
                    Comun.MostrarMensajeDeError("No se puede eliminar el presupuesto porque no existe en la base de datos.", "Error en la eliminación de un presupuesto");
                }
                else
                {
                    int idPresupuesto = Convert.ToInt32(idPresupuestoLabel1.Text);

                    presupuestoBindingSource.RemoveCurrent();
                    presupuestoBindingSource.EndEdit();
                    this.presupuestoTableAdapter.Update(this.recoDueroDataSet);

                    EliminarLineasPresupuestoBorrado(idPresupuesto);
                }

                if (presupuestoBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (presupuestoBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (presupuestoBindingSource.Position + 1 == presupuestoBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }
            RefrescarToolstripLabelPresupuesto();
        }

        private void EliminarLineasPresupuestoBorrado(int idPresupuesto)
        {
            DetallePresupuestoTableAdapter detallePresupuestoTableAdapter = new DetallePresupuestoTableAdapter();
            DetallePresupuestoDataTable detallePresupuestosData = detallePresupuestoTableAdapter.GetData();

            int[] ids = detallePresupuestosData.Select(p => p.IdPresupuesto).ToArray();

            foreach (int id in ids)
            {
                if (id == idPresupuesto)
                {
                    detallePresupuestoBindingSource.RemoveCurrent();
                    detallePresupuestoBindingSource.EndEdit();
                    this.detallePresupuestoTableAdapter.Update(this.recoDueroDataSet);
                }
            }
            this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
        }

        //EDITAR
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar presupuesto";
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
            toolStripComboBoxBuscarPresupuestos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //GUARDAR
        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();
                EstadoControlesGuardar();
                RefrescarToolstripLabelPresupuesto();

                presupuestoBindingSource.EndEdit();
                this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
                this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);

                CargarPresupuestos();

                if (detallePresupuestoBindingSource.Count <= 0)
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

            if (presupuestoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (presupuestoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (presupuestoBindingSource.Position + 1 == presupuestoBindingSource.Count && presupuestoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (presupuestoBindingSource.Position + 1 == presupuestoBindingSource.Count && presupuestoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (presupuestoBindingSource.Count > 2 && presupuestoBindingSource.Position + 1 != presupuestoBindingSource.Count && presupuestoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (presupuestoBindingSource.Position + 1 == 1 && presupuestoBindingSource.Count > 1)
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
            toolStripComboBoxBuscarPresupuestos.Enabled = true;
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

                    PrintLine("Id: ", idPresupuestoLabel1.Text);
                    PrintLine("Responsable: ", responsableComboBox.Text);
                    PrintLine("Cliente: ", clienteComboBox.Text);
                    PrintLine("Coste: ", costeLabel3.Text);
                    PrintLine("Fecha de emisión: ", fechaEmisionDateTimePicker.Text);
                    PrintLine("Estado: ", estadoComboBox.Text);
                    PrintLine("Método: ", metodoComboBox.Text);
                    PrintLine("Comentarios: ", comentariosTextBox.Text);
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
            toolStripStatusLabel1.Text = "Informe Presupuestos";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformePresupuestos))
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
                InformePresupuestos informePresupuestos = new InformePresupuestos();
                informePresupuestos.ShowDialog();
            }
        }

        //BUSCAR
        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar presupuesto";
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBoxBuscar.Text))
                {
                    Comun.MostrarMensajeDeError("Introduzca un campo a buscar en el cuadro de texto.", "Introduzca un campo");
                }
                else
                {
                    //ID
                    if (toolStripComboBoxBuscarPresupuestos.Text.Equals("Id"))
                    {
                        if (!Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un número, no letras.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (presupuestoBindingSource.Find("IdPresupuesto", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El presupuesto no existe.", "Presupuesto no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            presupuestoBindingSource.Position = presupuestoBindingSource.Find("IdPresupuesto", toolStripTextBoxBuscar.Text);
                        }
                    }

                }
                RefrescarToolstripLabelPresupuesto();

                EstadoControlesBuscar();
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (presupuestoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (presupuestoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (presupuestoBindingSource.Position + 1 == presupuestoBindingSource.Count && presupuestoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (presupuestoBindingSource.Position + 1 == presupuestoBindingSource.Count && presupuestoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (presupuestoBindingSource.Count > 2 && presupuestoBindingSource.Position + 1 != presupuestoBindingSource.Count && presupuestoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (presupuestoBindingSource.Position + 1 == 1 && presupuestoBindingSource.Count > 1)
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
                presupuestoBindingSource.EndEdit();
                EstadoControlesAceptar();
                datosGuardados = false;
                CargarPresupuestos();
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

                if (presupuestoBindingSource.Count > 0)
                {
                    if (detallePresupuestoBindingSource.Count <= 0)
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

                presupuestoBindingSource.CancelEdit();
                EstadoControlesCancelar();

                errorProvider1.Clear();
                datosGuardados = true;
                RefrescarToolstripLabelPresupuesto();
            }

        }

        private void EstadoControlesCancelar()
        {
            HabilitarControlesComunes();
        }

        //MÉTODOS
        private void RefrescarToolstripLabelPresupuesto()
        {
            this.toolstripLabelContadorPresupuestos.Text = $"Presupuesto {presupuestoBindingSource.Position + 1} de {presupuestoBindingSource.Count}";
        }

        private void HabilitarControlesComunes()
        {
            // Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarPresupuestos.Enabled = true;
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
            bool tieneRegistros = presupuestoBindingSource.Count > 0;
            bool esElPrimero = presupuestoBindingSource.Position == 0;
            bool esElUltimo = presupuestoBindingSource.Position == presupuestoBindingSource.Count - 1;

            toolStripButtonInicio.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonAnterior.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonSiguiente.Enabled = !esElUltimo && tieneRegistros;
            toolStripButtonFinal.Enabled = !esElUltimo && tieneRegistros;
        }

        private void OcultarCampos()
        {
            idPresupuestoLabel1.Enabled = false;
            responsableComboBox.Enabled = false;
            clienteComboBox.Enabled = false;
            costeLabel3.Enabled = false;

            fechaEmisionDateTimePicker.Enabled = false;
            estadoComboBox.Enabled = false;
            metodoComboBox.Enabled = false;
            comentariosTextBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idPresupuestoLabel1.Enabled = true;
            responsableComboBox.Enabled = true;
            clienteComboBox.Enabled = true;
            costeLabel3.Enabled = true;

            fechaEmisionDateTimePicker.Enabled = true;
            estadoComboBox.Enabled = true;
            metodoComboBox.Enabled = true;
            comentariosTextBox.Enabled = true;
        }

        private void CargarResponsableEmpleados()
        {
            EmpleadoTableAdapter empleadoTableAdapter = new EmpleadoTableAdapter();
            EmpleadoDataTable empleadosData = empleadoTableAdapter.GetData();

            empleadosData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");

            // Configurar el ComboBox
            responsableComboBox.DataSource = empleadosData;
            responsableComboBox.DisplayMember = "NombreCompleto";

            // Obtener el índice del empleado seleccionado
            int indiceEmpleadoSeleccionado = responsableComboBox.SelectedIndex;

            // Si hay un empleado seleccionado, cargarlo en el ComboBox
            if (indiceEmpleadoSeleccionado >= 0)
            {
                // Obtener el valor del nombre y apellidos del empleado
                string nombreApellidosEmpleadoSeleccionado = empleadosData.Rows[indiceEmpleadoSeleccionado]["NombreCompleto"].ToString();

                // Establecer el valor del ComboBox
                responsableComboBox.Text = nombreApellidosEmpleadoSeleccionado;
            }
            else
            {
                responsableComboBox.Text = "No hay empleados";
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

            // Obtener el índice del cliente seleccionado
            int indiceClienteSeleccionado = clienteComboBox.SelectedIndex;

            // Si hay un cliente seleccionado, cargarlo en el ComboBox
            if (indiceClienteSeleccionado >= 0)
            {
                // Obtener el valor del nombre y apellidos del cliente
                string nombreApellidosClienteSeleccionado = clientesData.Rows[indiceClienteSeleccionado]["NombreCompleto"].ToString();

                // Establecer el valor del ComboBox
                clienteComboBox.Text = nombreApellidosClienteSeleccionado;
            }
            else
            {
                clienteComboBox.Text = "No hay clientes";
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
            //if (costeNumericUpDown.Value <= 0)
            //{
            //    errorProvider1.SetError(costeNumericUpDown, "El coste del presupuesto no puede ser 0");
            //    costeNumericUpDown.Value = 1;
            //    return false;
            //}

            //si todo es valido
            return true;
        }

        /////////////////////    MAESTRO DETALLE
        private void ControlarBotonesDetalle()
        {
            if (presupuestoBindingSource.Count <= 0)
            {
                buttonAniadirLinea.Enabled = false;
                buttonBorrarLinea.Enabled = false;
                buttonEditarLinea.Enabled = false;

                OcultarControlesDetalle();
            }

            if (presupuestoBindingSource.Count > 0)
            {
                if (detallePresupuestoBindingSource.Count <= 0)
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
                //CargarPresupuestos();
            }
        }

        private void buttonAniadirLinea_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir detalle presupuesto";
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
                detallePresupuestoDataGridView.ReadOnly = false;
                //detallePresupuestoDataGridView.AllowUserToAddRows = true;

                detallePresupuestoBindingSource.AddNew();
                HabilitarControlesEnAnadirLinea();

                // Actualiza la fuente de datos con el valor predeterminado antes de guardar
                if (idPresupuestoComboBox.Items.Count > 0)
                {
                    CargarPresupuestos();
                    int idPresupuesto;

                    if (int.TryParse(idPresupuestoComboBox.SelectedValue.ToString(), out idPresupuesto))
                    {
                        ((DataRowView)detallePresupuestoBindingSource.Current)["IdPresupuesto"] = idPresupuesto;
                    }
                }

                if (obraComboBox.Items.Count > 0)
                {
                    CargarObras();
                    ((DataRowView)detallePresupuestoBindingSource.Current)["Obra"] = obraComboBox.SelectedItem.ToString();
                }

                ((DataRowView)detallePresupuestoBindingSource.Current)["Coste"] = (float)costeNumericUpDownDetalle.Value;

                detallePresupuestoDataGridView.ReadOnly = true;

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
            toolStripStatusLabel1.Text = "Borrar detalle presupuesto";

            if (detallePresupuestoBindingSource.Count <= 0)
            {
                MessageBox.Show("No se puede eliminar la línea porque no hay ninguna ", "Error en la eliminación de un presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var resultado = MessageBox.Show("¿Está seguro que desea eliminar el detalle del presupuesto?", "Confirmación eliminar detalle del presupuesto", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    borrando = true;

                    DetallePresupuestoTableAdapter detallePresupuestoTableAdapter = new DetallePresupuestoTableAdapter();
                    DetallePresupuestoDataTable detallePresupuestoData = detallePresupuestoTableAdapter.GetData();

                    double[] costesDetallePresupuesto = detallePresupuestoData.Select(p => p.Coste).ToArray();
                    costeBorrado = (float)costesDetallePresupuesto[detallePresupuestoDataGridView.CurrentRow.Index];

                    int[] idsPresupuestoDP = detallePresupuestoData.Select(p => p.IdPresupuesto).ToArray();
                    idPresupuesto = idsPresupuestoDP[detallePresupuestoDataGridView.CurrentRow.Index];

                    PresupuestoTableAdapter presupuestoTableAdapter = new PresupuestoTableAdapter();
                    PresupuestoDataTable presupuestoData = presupuestoTableAdapter.GetData();

                    int[] idsPresupuestoP = presupuestoData.Select(p => p.IdPresupuesto).ToArray();
                    double[] costesTotales = presupuestoData.Select(p => p.Coste).ToArray();

                    int indiceBorrado = 0;
                    for (int i = 0; i < idsPresupuestoP.Length; i++)
                    {
                        if (idsPresupuestoP[i] == idPresupuesto)
                        {
                            indiceBorrado = i;
                            break;
                        }
                    }
                    costeTotal = (float)costesTotales[indiceBorrado];

                    CalcularCosteTotal();

                    detallePresupuestoBindingSource.RemoveCurrent();
                    detallePresupuestoBindingSource.EndEdit();
                    this.detallePresupuestoTableAdapter.Update(this.recoDueroDataSet);

                    presupuestoBindingSource.EndEdit();
                    this.presupuestoTableAdapter.Update(this.recoDueroDataSet);

                    ControlarBotonesDetalle();
                }
            }
        }

        private void buttonEditarLinea_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar detalle presupuesto";
            editando = true;

            if (detallePresupuestoBindingSource.Count > 0)
            {
                //MAESTRO DETALLE 
                buttonAniadirLinea.Enabled = true;
                buttonBorrarLinea.Enabled = true;
                buttonEditarLinea.Enabled = true;

                detallePresupuestoDataGridView.ReadOnly = false;
                //detallePresupuestoDataGridView.AllowUserToAddRows = true;

                MostarControlesDetalle();

                detallePresupuestoDataGridView.ReadOnly = true;

                datosDetalleGuardados = false;

                costeInicialEditado = (float)costeNumericUpDownDetalle.Value;
                idPresupuestoInicialEditado = int.Parse(idPresupuestoComboBox.Text.ToString());
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

        private void buttonAceptarDetallePresupuesto_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidosDetalle())
            {
                CalcularCosteTotal();

                this.detallePresupuestoBindingSource.EndEdit();
                this.detallePresupuestoTableAdapter.Update(this.recoDueroDataSet);

                this.presupuestoBindingSource.EndEdit();
                this.presupuestoTableAdapter.Update(this.recoDueroDataSet);

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

        private void buttonCancelarDetallePresupuesto_Click(object sender, EventArgs e)
        {
            this.detallePresupuestoBindingSource.CancelEdit();
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

        private void CalcularCosteTotal()
        {
            DetallePresupuestoTableAdapter detallePresupuestoTableAdapter = new DetallePresupuestoTableAdapter();
            DetallePresupuestoDataTable detallePresupuestoData = detallePresupuestoTableAdapter.GetData();

            PresupuestoTableAdapter presupuestoTableAdapter = new PresupuestoTableAdapter();
            PresupuestoDataTable presupuestosData = presupuestoTableAdapter.GetData();

            int[] idsDetallePresupuesto = detallePresupuestoData.Select(p => p.IdDetallePresupuesto).ToArray();
            double[] costesDetallePresupuesto = detallePresupuestoData.Select(p => p.Coste).ToArray();
            int[] idsPresupuestoDP = detallePresupuestoData.Select(p => p.IdPresupuesto).ToArray();

            int[] idsPresupuestoP = presupuestosData.Select(p => p.IdPresupuesto).ToArray();
            double[] costesTotales = presupuestosData.Select(p => p.Coste).ToArray();

            if (insertando == true)
            {
                int[] ids = presupuestosData.Select(p => p.IdPresupuesto).ToArray();

                foreach (int id in ids)
                {
                    if (id == ids[idPresupuestoComboBox.SelectedIndex])
                    {
                        costeLabel3.Text = (Convert.ToDouble(costeLabel3.Text) + Convert.ToDouble(costeNumericUpDownDetalle.Text)).ToString();
                        this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
                    }
                }
                insertando = false;
            }
            else if (editando == true)
            {
                costeFinalEditado = (float)costeNumericUpDownDetalle.Value;
                idPresupuestoFinalEditado = int.Parse(idPresupuestoComboBox.Text.ToString());

                if (costeInicialEditado != costeFinalEditado)
                {
                    editandoCoste = true;
                }

                if (idPresupuestoInicialEditado != idPresupuestoFinalEditado)
                {
                    editandoIdPresupuesto = true;
                }

                if (editandoCoste == true)
                {
                    costeAdicional = costeFinalEditado - costeInicialEditado;

                    string costeTotalInicial = costeLabel3.Text;
                    if (float.TryParse(costeTotalInicial, out float resultado))
                    {
                        costeTotalFinal = resultado + costeAdicional;
                        costeLabel3.Text = costeTotalFinal.ToString();
                    }
                }

                if (editandoIdPresupuesto == true)
                {
                    idDetallePresupuesto = idsDetallePresupuesto[detallePresupuestoDataGridView.CurrentRow.Index];
                    float costeParcial = (float)costesDetallePresupuesto[detallePresupuestoDataGridView.CurrentRow.Index];
                    float costeTotalInicial = 0, costeTotalFinal = 0;
                    int indiceInicial = 0, indiceFinal = 0;
                    int i = 0, j = 0;
                    foreach (int idP in idsPresupuestoP)
                    {
                        foreach (int idDP in idsDetallePresupuesto)
                        {
                            if (idP == idPresupuestoInicialEditado && idDP == idDetallePresupuesto)
                            {
                                costeTotalInicial = (float)costesTotales[i];
                                indiceInicial = i;
                                editandoIdPInicial = true;
                            }

                            if (idP == idPresupuestoFinalEditado && idDP == idDetallePresupuesto)
                            {
                                costeTotalFinal = (float)costesTotales[i];
                                indiceFinal = i;
                                editandoIdPFinal = true;
                            }

                            j++;
                        }
                        i++;
                    }
                    costeTotalInicialEditado = costeTotalInicial - costeParcial;

                    NavegarRegistro(indiceInicial);

                    if (editandoIdPInicial == true)
                    {
                        costeLabel3.Text = costeTotalInicialEditado.ToString();
                        editandoIdPInicial = false;
                    }

                    costeTotalFinalEditado = costeTotalFinal + costeParcial;

                    NavegarRegistro(indiceFinal);

                    if (editandoIdPFinal == true)
                    {
                        costeLabel3.Text = costeTotalFinalEditado.ToString();
                        editandoIdPFinal = false;
                    }
                }

                editando = false;
            }
            else if (borrando == true)
            {
                costeTotal = costeTotal - costeBorrado;
                costeLabel3.Text = costeTotal.ToString();

                this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
                borrando = false;
            }
        }

        private void OcultarControlesDetalle()
        {
            //Campos
            idDetallePresupuestoLabel1.Enabled = false;
            idPresupuestoComboBox.Enabled = false;
            obraComboBox.Enabled = false;
            costeNumericUpDownDetalle.Enabled = false;
            descripcionTextBox.Enabled = false;

            //Botones
            buttonAceptarDetallePresupuesto.Visible = false;
            buttonCancelarDetallePresupuesto.Visible = false;
        }

        private void MostarControlesDetalle()
        {
            //Campos
            idDetallePresupuestoLabel1.Enabled = true;
            idPresupuestoComboBox.Enabled = true;
            obraComboBox.Enabled = true;
            costeNumericUpDownDetalle.Enabled = true;
            descripcionTextBox.Enabled = true;

            //Botones
            buttonAceptarDetallePresupuesto.Visible = true;
            buttonCancelarDetallePresupuesto.Visible = true;
        }

        private bool ComprobarDatosIntroducidosDetalle()
        {
            if (costeNumericUpDownDetalle.Value <= 0)
            {
                errorProvider1.SetError(costeNumericUpDownDetalle, "El coste del detalle de presupuesto no puede ser 0");
                costeNumericUpDownDetalle.Value = 1;
                return false;
            }

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                errorProvider1.SetError(descripcionTextBox, " Descripción obligatoria");
                descripcionTextBox.Clear();
                return false;
            }
            else if (descripcionTextBox.Text.Length>25)
            {
                errorProvider1.SetError(descripcionTextBox, " No puede sobrepasar los 25 caracteres");
                descripcionTextBox.Clear();
                return false;
            }

            //si todo es valido
            errorProvider1.Clear();
            return true;
        }

        private void idPresupuestoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idPresupuestoComboBox.Text))
            {
                if (int.TryParse(idPresupuestoComboBox.Text, out int resultado))
                {
                    NavegarRegistro(resultado - 1);
                }
            }
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

        private void Presupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false || datosDetalleGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.presupuestoBindingSource.EndEdit();
                        this.detallePresupuestoBindingSource.EndEdit();
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

        private void responsableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void clienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

