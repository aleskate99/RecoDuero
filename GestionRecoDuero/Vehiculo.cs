using GestionRecoDuero.RecoDueroDataSetTableAdapters;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Vehiculo : Form
    {
        private bool datosGuardados = true;

        public Vehiculo()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Vehiculo_Load(object sender, EventArgs e)
        {
            this.vehiculoTableAdapter.Fill(this.recoDueroDataSet.Vehiculo);
            AjustarImagenes();
            EstadoControlesInicioApp();
            RefrescarToolstripLabelVehiculo();
            toolStripStatusLabel1.Text = "Inicio";
            CargarEmpleados();
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar vehículos", MessageBoxButtons.OKCancel);
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

            if (vehiculoBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarVehiculos.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            else if (vehiculoBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarVehiculos.Enabled = true;
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
                toolStripComboBoxBuscarVehiculos.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            // Comprobar si no hay registros en el origen de datos
            if (vehiculoBindingSource.Count <= 0)
                return;

            // Mover el cursor del origen de datos al registro especificado por 'index'
            vehiculoBindingSource.Position = indice;

            // Determinar si el registro actual es el primer o el último
            bool enPrimerRegistro = vehiculoBindingSource.Position == 0;
            bool enUltimoRegistro = vehiculoBindingSource.Position == vehiculoBindingSource.Count - 1;

            // Habilitar o deshabilitar los botones de navegación según la posición del registro
            toolStripButtonInicio.Enabled = !enPrimerRegistro;
            toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            toolStripButtonFinal.Enabled = !enUltimoRegistro;

            RefrescarToolstripLabelVehiculo();
        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            NavegarRegistro(vehiculoBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            NavegarRegistro(vehiculoBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            NavegarRegistro(vehiculoBindingSource.Count - 1); // Ir al último registro
        }

        //AÑADIR
        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir vehículo";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            vehiculoBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();

            RefrescarToolstripLabelVehiculo();
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
            tipoComboBox.SelectedIndex = 0;
            estadoComboBox.SelectedIndex = 0;
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
            toolStripComboBoxBuscarVehiculos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //ELIMINAR
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar vehículo";

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el vehículo?", "Confirmación eliminar vehículo", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (vehiculoBindingSource.Count <= 0)
                {
                    Comun.MostrarMensajeDeError("No se puede eliminar el vehículo porque no existe en la base de datos.", "Error en la eliminación de un vehículo");
                }
                else
                {
                    vehiculoBindingSource.RemoveCurrent();
                    vehiculoBindingSource.EndEdit();
                    this.vehiculoTableAdapter.Update(this.recoDueroDataSet);
                }

                if (vehiculoBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (vehiculoBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (vehiculoBindingSource.Position + 1 == vehiculoBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }

            RefrescarToolstripLabelVehiculo();
        }

        //EDITAR
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar vehículo";
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
            toolStripComboBoxBuscarVehiculos.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //GUARDAR
        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();

                vehiculoBindingSource.EndEdit();
                this.vehiculoTableAdapter.Update(this.recoDueroDataSet);

                EstadoControlesGuardar();
                RefrescarToolstripLabelVehiculo();

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

            if (vehiculoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (vehiculoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (vehiculoBindingSource.Position + 1 == vehiculoBindingSource.Count && vehiculoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (vehiculoBindingSource.Position + 1 == vehiculoBindingSource.Count && vehiculoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (vehiculoBindingSource.Count > 2 && vehiculoBindingSource.Position + 1 != vehiculoBindingSource.Count && vehiculoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (vehiculoBindingSource.Position + 1 == 1 && vehiculoBindingSource.Count > 1)
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
            toolStripComboBoxBuscarVehiculos.Enabled = true;
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

                    PrintLine("Id: ", idVehiculoLabel1.Text);
                    PrintLine("Marca: ", marcaTextBox.Text);
                    PrintLine("Modelo: ", modeloTextBox.Text);
                    PrintLine("Matrícula: ", matrículaTextBox.Text);
                    PrintLine("Tipo: ", tipoComboBox.Text);
                    PrintLine("Estado: ", estadoComboBox.Text);
                    PrintLine("Coste de adquisición: ", costeAdquisicionNumericUpDown.Text);

                    PrintLine("Conductor: ", conductorComboBox.Text);
                    PrintLine("Seguro: ", seguroTextBox.Text);
                    PrintLine("Fecha ITV: ", fechaItvDateTimePicker.Text);
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
            toolStripStatusLabel1.Text = "Informe Vehículos";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformeVehiculos))
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
                InformeVehiculos informeVehiculos = new InformeVehiculos();
                informeVehiculos.ShowDialog();
            }
        }

        //BUSCAR
        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar vehículo";
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBoxBuscar.Text))
                {
                    Comun.MostrarMensajeDeError("Introduzca un campo a buscar en el cuadro de texto.", "Introduzca un campo");
                }
                else
                {
                    //ID
                    if (toolStripComboBoxBuscarVehiculos.Text.Equals("IdVehiculo"))
                    {
                        if (!Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un número, no letras.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (vehiculoBindingSource.Find("IdVehiculo", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El vehículo no existe.", "Vehículo no encontrada");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            vehiculoBindingSource.Position = vehiculoBindingSource.Find("IdVehiculo", toolStripTextBoxBuscar.Text);
                        }
                    }

                }
                RefrescarToolstripLabelVehiculo();

                EstadoControlesBuscar();
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (vehiculoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (vehiculoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (vehiculoBindingSource.Position + 1 == vehiculoBindingSource.Count && vehiculoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (vehiculoBindingSource.Position + 1 == vehiculoBindingSource.Count && vehiculoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (vehiculoBindingSource.Count > 2 && vehiculoBindingSource.Position + 1 != vehiculoBindingSource.Count && vehiculoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (vehiculoBindingSource.Position + 1 == 1 && vehiculoBindingSource.Count > 1)
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
                vehiculoBindingSource.EndEdit();
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
                vehiculoBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
                datosGuardados = false;
            }

            RefrescarToolstripLabelVehiculo();
        }
        
        private void EstadoControlesCancelar()
        {
            HabilitarControlesComunes();
        }

        //IMÁGEN
        private void fotoPictureBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos gráficos|*.bmp;*.gif;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagenPath = openFileDialog1.FileName;

                // Verificar el tamaño de la imagen
                using (var img = Image.FromFile(imagenPath))
                {
                    if (img.Width > 800 || img.Height > 600)
                    {
                        MessageBox.Show("La imagen es demasiado grande. Seleccione una imagen más pequeña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                fotoPictureBox.ImageLocation = imagenPath;
                fotoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // PictureBoxSizeMode.Zoom;

                // Mostrar información adicional sobre la imagen
                FileInfo fileInfo = new FileInfo(imagenPath);
                long fileSize = fileInfo.Length;
                DateTime lastModified = fileInfo.LastWriteTime;

                string info = $"Tamaño: {fileSize / 1024} KB\nÚltima modificación: {lastModified}";
                MessageBox.Show(info, "Información de la imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fotoPictureBox.Image = null;
            }
        }

        //MÉTODOS
        private void RefrescarToolstripLabelVehiculo()
        {
            this.toolstripLabelContadorVehiculos.Text = $"Vehículo {vehiculoBindingSource.Position + 1} de {vehiculoBindingSource.Count}";
        }

        private void HabilitarControlesComunes()
        {
            // Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarVehiculos.Enabled = true;
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
            bool tieneRegistros = vehiculoBindingSource.Count > 0;
            bool esElPrimero = vehiculoBindingSource.Position == 0;
            bool esElUltimo = vehiculoBindingSource.Position == vehiculoBindingSource.Count - 1;

            toolStripButtonInicio.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonAnterior.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonSiguiente.Enabled = !esElUltimo && tieneRegistros;
            toolStripButtonFinal.Enabled = !esElUltimo && tieneRegistros;
        }
        
        private void OcultarCampos()
        {
            idVehiculoLabel1.Enabled = false;
            marcaTextBox.Enabled = false;
            modeloTextBox.Enabled = false;
            matrículaTextBox.Enabled = false;
            tipoComboBox.Enabled = false;
            estadoComboBox.Enabled = false;
            costeAdquisicionNumericUpDown.Enabled = false;

            conductorComboBox.Enabled = false;
            seguroTextBox.Enabled = false;
            fechaItvDateTimePicker.Enabled = false;
            fotoPictureBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idVehiculoLabel1.Enabled = true;
            marcaTextBox.Enabled = true;
            modeloTextBox.Enabled = true;
            matrículaTextBox.Enabled = true;
            tipoComboBox.Enabled = true;
            estadoComboBox.Enabled = true;
            costeAdquisicionNumericUpDown.Enabled = true;

            conductorComboBox.Enabled = true;
            seguroTextBox.Enabled = true;
            fechaItvDateTimePicker.Enabled = true;
            fotoPictureBox.Enabled = true;
        }

        private void CargarEmpleados()
        {
            EmpleadoTableAdapter empleadoTableAdapter = new EmpleadoTableAdapter();
            RecoDueroDataSet.EmpleadoDataTable empleadosData = empleadoTableAdapter.GetData();

            empleadosData.Columns.Add("NombreCompleto", typeof(string), "Nombre + ' ' + Apellidos");
            //conductorComboBox.DataSource = empleadosData;
            //conductorComboBox.DisplayMember = "Nombre";
           

            // Configurar el ComboBox
            conductorComboBox.DataSource = empleadosData;
            conductorComboBox.DisplayMember = "NombreCompleto";

            if (conductorComboBox.Items.Count > 0)
            {
                conductorComboBox.SelectedIndex = 0;
            }
            else
            {
                conductorComboBox.Text = "No hay empleados";
            }

        }

        //COMPROBAR DATOS
        private bool ComprobarDatosIntroducidos()
        {
            //Marca
            if (string.IsNullOrWhiteSpace(marcaTextBox.Text))
            {
                errorProvider1.SetError(marcaTextBox, "Marca obligatoria");
                marcaTextBox.Clear();
                return false;
            }

            //Modelo
            if (string.IsNullOrWhiteSpace(modeloTextBox.Text))
            {
                errorProvider1.SetError(modeloTextBox, "Modelo obligatorio");
                modeloTextBox.Clear();
                return false;
            }

            //Matrícula
            if (string.IsNullOrWhiteSpace(matrículaTextBox.Text))
            {
                errorProvider1.SetError(matrículaTextBox, "Matrícula obligatoria");
                matrículaTextBox.Clear();
                return false;
            }
            else if (!Comun.ComprobarMatricula(matrículaTextBox.Text))
            {
                errorProvider1.SetError(matrículaTextBox, "Formato de matrícula erróneo, debe tener 4 números y 3 letras mayúsculas");
                matrículaTextBox.Clear();
                return false;
            }

            //si todo es valido
            return true;
        }

        //TODO: VALIDATINGS

        //Atajos de teclado
        private void Vehiculo_KeyDown(object sender, KeyEventArgs e)
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

        private void Vehiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.vehiculoBindingSource.EndEdit();
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
