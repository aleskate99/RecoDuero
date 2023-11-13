using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using GestionRecoDuero.RecoDueroDataSetTableAdapters;
using static GestionRecoDuero.RecoDueroDataSet;

namespace GestionRecoDuero
{
    public partial class Presupuesto : Form
    {
        private bool datosGuardados = true;
        private static int fila = 0;

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
            this.detallePresupuestoTableAdapter.Fill(this.recoDueroDataSet.DetallePresupuesto);
            this.presupuestoTableAdapter.Fill(this.recoDueroDataSet.Presupuesto);
            AjustarImagenes();
            EstadoControlesInicioApp();
            RefrescarToolstripLabelPresupuesto();
            toolStripStatusLabel1.Text = "Inicio";
            estadoControlesInicioDetalle();
            CargarResponsableEmpleados(); //Para sacar el responsable
            CargarClientes(); //Para cargar la info de los clientes
            CargarPresupuestos(); //Para cargar los presupuestos
            CargarObras(); //Para cargar la ubicación de las obras
            Test();
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
            estadoComboBox.SelectedIndex = 0;
            metodoComboBox.SelectedIndex = 0;

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
            toolStripComboBoxBuscarPresupuestos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
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
                    presupuestoBindingSource.RemoveCurrent();
                    presupuestoBindingSource.EndEdit();
                    this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
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

        //EDITAR
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar presupuesto";
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
            toolStripComboBoxBuscarPresupuestos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //GUARDAR
        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();

                presupuestoBindingSource.EndEdit();
                this.presupuestoTableAdapter.Update(this.recoDueroDataSet);

                EstadoControlesGuardar();
                RefrescarToolstripLabelPresupuesto();

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
                    PrintLine("Coste: ", costeNumericUpDown.Text);
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
                catch (Exception ex)
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
                presupuestoBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
                datosGuardados = false;
            }

            RefrescarToolstripLabelPresupuesto();
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
            costeNumericUpDown.Enabled = false;

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
            costeNumericUpDown.Enabled = true;

            fechaEmisionDateTimePicker.Enabled = true;
            estadoComboBox.Enabled = true;
            metodoComboBox.Enabled = true;
            comentariosTextBox.Enabled = true;
        }

        private void CargarResponsableEmpleados()
        {
            EmpleadoTableAdapter empleadoTableAdapter = new EmpleadoTableAdapter();
            RecoDueroDataSet.EmpleadoDataTable empleadosData = empleadoTableAdapter.GetData();

            empleadosData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");

            // Configurar el ComboBox
            responsableComboBox.DataSource = empleadosData;
            responsableComboBox.DisplayMember = "NombreCompleto";

            if (responsableComboBox.Items.Count > 0)
            {
                responsableComboBox.SelectedIndex = 0;
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

            if (clienteComboBox.Items.Count > 0)
            {
                clienteComboBox.SelectedIndex = 0;
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

        private void Test()
        {
            //PRESUPUESTO
            string idPresupuesto = idPresupuestoComboBox.SelectedValue.ToString();
            detallePresupuestoDataGridView.Rows[fila].Cells[3].Value = idPresupuesto;

            //OBRA
            string obra = obraComboBox.SelectedValue.ToString();
            detallePresupuestoDataGridView.Rows[fila].Cells[1].Value = obra;
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
            idDetallePresupuestoLabel1.Enabled = false;
            idPresupuestoComboBox.Enabled = false;
            obraComboBox.Enabled = false;
            costeNumericUpDownDetalle.Enabled = false;

            //Botones
            buttonAceptarDetallePresupuesto.Visible = false;
            buttonCancelarDetallePresupuesto.Visible = false;
        }

        private void buttonAniadirLinea_Click(object sender, EventArgs e)
        {
            detallePresupuestoBindingSource.AddNew();

            //Campos
            idDetallePresupuestoLabel1.Enabled = true;
            idPresupuestoComboBox.Enabled = true;
            obraComboBox.Enabled = true;
            costeNumericUpDownDetalle.Enabled = true;

            //Botones
            buttonAceptarDetallePresupuesto.Visible = true;
            buttonCancelarDetallePresupuesto.Visible = true;
        }

        private void buttonBorrarLinea_Click(object sender, EventArgs e)
        {
            if (detallePresupuestoBindingSource.Count <= 0)
            {
                MessageBox.Show("No se puede eliminar la línea porque no hay ninguna ", "Error en la eliminación de un presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                detallePresupuestoBindingSource.RemoveCurrent();
                this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
            }
        }

        private void buttonEditarLinea_Click(object sender, EventArgs e)
        {
            //Campos
            idDetallePresupuestoLabel1.Enabled = true;
            idPresupuestoComboBox.Enabled = true;
            obraComboBox.Enabled = true;
            costeNumericUpDownDetalle.Enabled = true;

            //Botones
            buttonAceptarDetallePresupuesto.Visible = true;
            buttonCancelarDetallePresupuesto.Visible = true;
        }

        //TODO: Revisar el coste total
        private void buttonAceptarDetallePresupuesto_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidosDetalle())
            {
                this.detallePresupuestoBindingSource.EndEdit();
                this.detallePresupuestoTableAdapter.Update(this.recoDueroDataSet);
                this.presupuestoTableAdapter.Update(this.recoDueroDataSet);
                //precioTotalLabel1.Text = (Convert.ToInt32(precioTotalLabel1.Text) + Convert.ToInt32(precioTextBox.Text)).ToString();

                //Campos
                idDetallePresupuestoLabel1.Enabled = false;
                idPresupuestoComboBox.Enabled = false;
                obraComboBox.Enabled = false;
                costeNumericUpDownDetalle.Enabled = false;

                //Botones
                buttonAceptarDetallePresupuesto.Visible = false;
                buttonCancelarDetallePresupuesto.Visible = false;
            }
        }

        private void buttonCancelarDetallePresupuesto_Click(object sender, EventArgs e)
        {
            this.detallePresupuestoBindingSource.CancelEdit();

            //Campos
            idDetallePresupuestoLabel1.Enabled = false;
            idPresupuestoComboBox.Enabled = false;
            obraComboBox.Enabled = false;
            costeNumericUpDownDetalle.Enabled = false;

            //Botones
            buttonAceptarDetallePresupuesto.Visible = false;
            buttonCancelarDetallePresupuesto.Visible = false;
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

        private void Presupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.presupuestoBindingSource.EndEdit();
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
