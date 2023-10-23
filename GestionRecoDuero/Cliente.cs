using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.clienteTableAdapter.Fill(this.recoDueroDataSet.Cliente);
            EstadoControlesInicioApp();
            AjustarImagenes();
            RefrescarToolstripLabelCliente();
            toolStripStatusLabel1.Text = "Inicio";
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar clientes", MessageBoxButtons.OKCancel);
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

            //Control estado flechas
            if (clienteBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarClientes.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;

                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }
            else if (clienteBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;

                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarClientes.Enabled = true;
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
                toolStripComboBoxBuscarClientes.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            // Comprobar si no hay registros en el origen de datos
            if (clienteBindingSource.Count <= 0)
                return;

            // Mover el cursor del origen de datos al registro especificado por 'index'
            clienteBindingSource.Position = indice;

            // Determinar si el registro actual es el primer o el último
            bool enPrimerRegistro = clienteBindingSource.Position == 0;
            bool enUltimoRegistro = clienteBindingSource.Position == clienteBindingSource.Count - 1;

            // Habilitar o deshabilitar los botones de navegación según la posición del registro
            toolStripButtonInicio.Enabled = !enPrimerRegistro;
            toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            toolStripButtonFinal.Enabled = !enUltimoRegistro;

            RefrescarToolstripLabelCliente();
        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            NavegarRegistro(clienteBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            NavegarRegistro(clienteBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            NavegarRegistro(clienteBindingSource.Count - 1); // Ir al último registro
        }

        //BOTONES
        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir cliente";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            clienteBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();

            RefrescarToolstripLabelCliente();
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
        }

        //Deshabilita todos los botones en Añadir salvo aceptar cancelar y guardar
        private void DeshabilitarBotonesEnAnadir()
        {
            toolStripButtonAnadir.Enabled = false;
            toolStripButtonAnterior.Enabled = false;
            toolStripButtonInicio.Enabled = false;
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;
            toolStripButtonEditar.Enabled = false;
            toolStripButtonEliminar.Enabled = false;
            toolStripButtonBuscar.Enabled = false;
            toolStripComboBoxBuscarClientes.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar cliente";

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Confirmación eliminar cliente", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (clienteBindingSource.Count <= 0)
                {
                    Comun.MostrarMensajeDeError("No se puede eliminar el cliente porque no existe en la base de datos.", "Error en la eliminación de un cliente");
                }
                else
                {
                    clienteBindingSource.RemoveCurrent();
                    clienteBindingSource.EndEdit();
                    this.clienteTableAdapter.Update(this.recoDueroDataSet);
                }

                if (clienteBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (clienteBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (clienteBindingSource.Position + 1 == clienteBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }

            RefrescarToolstripLabelCliente();
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar cliente";
            EstadoControlesEditar();
            ComprobarDatosIntroducidos();
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
            toolStripComboBoxBuscarClientes.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();

                clienteBindingSource.EndEdit();
                this.clienteTableAdapter.Update(this.recoDueroDataSet);

                EstadoControlesGuardar();
                RefrescarToolstripLabelCliente();

                Comun.MostrarMensajeDeError("Guardado con éxito.", "Guardado con éxito");
            }
        }

        private void EstadoControlesGuardar()
        {
            toolStripButtonAnadir.Enabled = true;
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;
            toolStripButtonGuardar.Enabled = false;
            toolStripButtonBuscar.Enabled = true;

            //Controla estado flechas
            if (clienteBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;

            }

            if (clienteBindingSource.Position + 1 == clienteBindingSource.Count && clienteBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Position + 1 == clienteBindingSource.Count && clienteBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Count > 2 && clienteBindingSource.Position + 1 != clienteBindingSource.Count && clienteBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (clienteBindingSource.Position + 1 == 1 && clienteBindingSource.Count > 1)
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
            toolStripComboBoxBuscarClientes.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;

            //Campos
            OcultarCampos();
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar cliente";
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBoxBuscar.Text))
                {
                    Comun.MostrarMensajeDeError("Introduzca un campo a buscar en el cuadro de texto.", "Introduzca un campo");
                }
                else
                {
                    //ID
                    if (toolStripComboBoxBuscarClientes.Text.Equals("Id"))
                    {
                        if (!Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un número, no letras.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (clienteBindingSource.Find("IdCliente", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El cliente no existe.", "Cliente no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            clienteBindingSource.Position = clienteBindingSource.Find("IdCliente", toolStripTextBoxBuscar.Text);
                        }
                    }

                    //Nombre
                    if (toolStripComboBoxBuscarClientes.Text.Equals("Nombre"))
                    {
                        if (Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un nombre, no un número.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (clienteBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El cliente no existe.", "Cliente no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            clienteBindingSource.Position = clienteBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text);
                        }
                    }

                }
                RefrescarToolstripLabelCliente();

                EstadoControlesBuscar();
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (clienteBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (clienteBindingSource.Position + 1 == clienteBindingSource.Count && clienteBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Position + 1 == clienteBindingSource.Count && clienteBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Count > 2 && clienteBindingSource.Position + 1 != clienteBindingSource.Count && clienteBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (clienteBindingSource.Position + 1 == 1 && clienteBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();
                clienteBindingSource.EndEdit(); //Lo guarda en memoria
                EstadoControlesAceptar();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Quiere cancelar la operación?", "Confirmación botón cancelar", MessageBoxButtons.OKCancel);
            if (resultado == DialogResult.OK)
            {
                clienteBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
            }

            RefrescarToolstripLabelCliente();
        }

        private void EstadoControlesAceptar()
        {
            HabilitarControlesComunes();
            toolStripButtonGuardar.Enabled = true;
        }

        private void EstadoControlesCancelar()
        {
            HabilitarControlesComunes();
        }

        private void HabilitarControlesComunes()
        {
            // Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarClientes.Enabled = true;
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
            bool tieneRegistros = clienteBindingSource.Count > 0;
            bool esElPrimero = clienteBindingSource.Position == 0;
            bool esElUltimo = clienteBindingSource.Position == clienteBindingSource.Count - 1;

            toolStripButtonInicio.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonAnterior.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonSiguiente.Enabled = !esElUltimo && tieneRegistros;
            toolStripButtonFinal.Enabled = !esElUltimo && tieneRegistros;
        }

        //TODO: REVISAR
        private void contratoPictureBox_Click(object sender, EventArgs e)
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

                contratoPictureBox.ImageLocation = imagenPath;
                contratoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // PictureBoxSizeMode.Zoom;

                // Mostrar información adicional sobre la imagen
                FileInfo fileInfo = new FileInfo(imagenPath);
                long fileSize = fileInfo.Length;
                DateTime lastModified = fileInfo.LastWriteTime;

                string info = $"Tamaño: {fileSize / 1024} KB\nÚltima modificación: {lastModified}";
                MessageBox.Show(info, "Información de la imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                contratoPictureBox.Image = null;
            }
        }

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

                    //TODO: ARREGLAR CAMPOS
                    PrintLine("Id: ", idClienteLabel1.Text);
                    PrintLine("Nombre: ", nombreTextBox.Text);
                    PrintLine("Apellidos: ", apellidosTextBox.Text);
                    PrintLine("Dirección: ", direccionTextBox.Text);
                    PrintLine("Teléfono: ", telefonoTextBox.Text);
                    PrintLine("Email: ", emailTextBox.Text);
                    PrintLine("Tipo: ", tipoComboBox.Text);
                    PrintLine("Observaciones: ", observacionesTextBox.Text);
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

        private void toolStripButtonInforme_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "Informe Clientes";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformeClientes))
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
                InformeClientes informeClientes = new InformeClientes();
                informeClientes.ShowDialog();
            }

        }

        //TODO: NO FUNCIONA COMO DEBERIA
        private void Cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (recoDueroDataSet.HasChanges())
            //{
            //    DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
            //        this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            //    if (result == DialogResult.Yes)
            //    {
            //        this.Validate();
            //        this.clienteBindingSource.EndEdit();
            //        this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);
            //    }
            //}
        }

        private void RefrescarToolstripLabelCliente()
        {
            this.toolstripLabelContadorClientes.Text = $"Cliente {clienteBindingSource.Position + 1} de {clienteBindingSource.Count}";
        }

        private void OcultarCampos() 
        {
            idClienteLabel1.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidosTextBox.Enabled = false;
            direccionTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
            emailTextBox.Enabled = false;

            tipoComboBox.Enabled = false;
            observacionesTextBox.Enabled = false;
            contratoPictureBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idClienteLabel1.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidosTextBox.Enabled = true;
            direccionTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
            emailTextBox.Enabled = true;

            tipoComboBox.Enabled = true;
            observacionesTextBox.Enabled = true;
            contratoPictureBox.Enabled = true;
        }

        private bool ComprobarDatosIntroducidos()
        {
            //Nombre 
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                errorProvider1.SetError(nombreTextBox, " Nombre obligatorio");
                nombreTextBox.Clear();
                return false;
            }
            else if (nombreTextBox.TextLength > 30)
            {
                errorProvider1.SetError(nombreTextBox, "No debe superar los 30 dígitos introducidos");
                nombreTextBox.Clear();
                return false;
            }
            else if (!Comun.ContieneSoloLetras(nombreTextBox.Text))
            {
                errorProvider1.SetError(nombreTextBox, "Solo puede introducir letras en el campo nombre");
                nombreTextBox.Clear();
                return false;
            }

            //Apellidos
            if (string.IsNullOrWhiteSpace(apellidosTextBox.Text))
            {
                errorProvider1.SetError(apellidosTextBox, " Apellidos obligatorios");
                apellidosTextBox.Clear();
                return false;
            }
            else if (apellidosTextBox.TextLength > 50)
            {
                errorProvider1.SetError(apellidosTextBox, "No debe superar los 50 dígitos introducidos ");
                apellidosTextBox.Clear();
                return false;
            }
            else if (!Comun.ContieneSoloLetras(apellidosTextBox.Text))
            {
                errorProvider1.SetError(apellidosTextBox, "Solo puede introducir letras en el campo apellidos ");
                apellidosTextBox.Clear();
                return false;
            }

            //Dirección
            if (string.IsNullOrWhiteSpace(direccionTextBox.Text))
            {
                errorProvider1.SetError(direccionTextBox, " Dirección obligatoria");
                direccionTextBox.Clear();
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
            if (!(Comun.EsDireccionCorreoValida(emailTextBox.Text)) && emailTextBox.Text.Length != 0)
            {
                errorProvider1.SetError(emailTextBox, "Formato de email no válido");
                emailTextBox.Clear();
                return false;
            }

            //si todo es valido
            return true;
        }

        private void nombreTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nombreTextBox.TextLength > 30)
            {
                errorProvider1.SetError(nombreTextBox, "No debe superar los 30 dígitos introducidos");
                nombreTextBox.Clear();
            }
            else if (!Comun.ContieneSoloLetras(nombreTextBox.Text))
            {
                errorProvider1.SetError(nombreTextBox, "Solo puede introducir letras en el campo nombre");
                nombreTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void apellidosTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (apellidosTextBox.TextLength > 50)
            {
                errorProvider1.SetError(apellidosTextBox, "No debe superar los 50 dígitos introducidos ");
                apellidosTextBox.Clear();
            }
            else if (!Comun.ContieneSoloLetras(apellidosTextBox.Text))
            {
                errorProvider1.SetError(apellidosTextBox, "Solo puede introducir letras en el campo apellidos ");
                apellidosTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void telefonoTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Comun.ContieneNumeros(telefonoTextBox.Text) == false)
            {
                errorProvider1.SetError(telefonoTextBox, "Solo puede introducir números ");
                telefonoTextBox.Clear();
            }
            else if ((telefonoTextBox.Text.Length != 9) && (telefonoTextBox.Text.Length != 0))
            {
                errorProvider1.SetError(telefonoTextBox, "Debe tener 9 dígitos");
                telefonoTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        //Atajos de teclado
        private void Cliente_KeyDown(object sender, KeyEventArgs e)
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
        }
    }
}
