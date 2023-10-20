using System;
using System.Drawing;
using System.Drawing.Printing;
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

        private void AjustarImagenes()
        {
            //Ajustar imágen botón añadir
            this.toolStripButtonAnadir.AutoSize = false;
            this.toolStripButtonAnadir.Width = 50;
            this.toolStripButtonAnadir.Height = 50;
            this.toolStripButtonAnadir.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón eliminar
            this.toolStripButtonEliminar.AutoSize = false;
            this.toolStripButtonEliminar.Width = 50;
            this.toolStripButtonEliminar.Height = 50;
            this.toolStripButtonEliminar.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón editar
            this.toolStripButtonEditar.AutoSize = false;
            this.toolStripButtonEditar.Width = 50;
            this.toolStripButtonEditar.Height = 50;
            this.toolStripButtonEditar.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón guardar
            this.toolStripButtonGuardar.AutoSize = false;
            this.toolStripButtonGuardar.Width = 50;
            this.toolStripButtonGuardar.Height = 50;
            this.toolStripButtonGuardar.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón buscar
            this.toolStripButtonBuscar.AutoSize = false;
            this.toolStripButtonBuscar.Width = 50;
            this.toolStripButtonBuscar.Height = 50;
            this.toolStripButtonBuscar.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón imprimir
            this.toolStripButtonImprimir.AutoSize = false;
            this.toolStripButtonImprimir.Width = 50;
            this.toolStripButtonImprimir.Height = 50;
            this.toolStripButtonImprimir.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón formulario
            this.toolStripButtonInforme.AutoSize = false;
            this.toolStripButtonInforme.Width = 50;
            this.toolStripButtonInforme.Height = 50;
            this.toolStripButtonInforme.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón anterior
            this.toolStripButtonAnterior.AutoSize = false;
            this.toolStripButtonAnterior.Width = 50;
            this.toolStripButtonAnterior.Height = 50;
            this.toolStripButtonAnterior.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón principio
            this.toolStripButtonInicio.AutoSize = false;
            this.toolStripButtonInicio.Width = 50;
            this.toolStripButtonInicio.Height = 50;
            this.toolStripButtonInicio.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón siguiente
            this.toolStripButtonSiguiente.AutoSize = false;
            this.toolStripButtonSiguiente.Width = 50;
            this.toolStripButtonSiguiente.Height = 50;
            this.toolStripButtonSiguiente.ImageScaling = ToolStripItemImageScaling.None;

            //Ajustar imágen botón final
            this.toolStripButtonFinal.AutoSize = false;
            this.toolStripButtonFinal.Width = 50;
            this.toolStripButtonFinal.Height = 50;
            this.toolStripButtonFinal.ImageScaling = ToolStripItemImageScaling.None;
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
        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            clienteBindingSource.MoveFirst();
            toolStripButtonInicio.Enabled = false;
            toolStripButtonAnterior.Enabled = false;

            if (clienteBindingSource.Count > 1)
            {
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            RefrescarToolstripLabelCliente();
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            clienteBindingSource.MovePrevious();
            if (clienteBindingSource.Position <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
            }

            if (clienteBindingSource.Count > 1)
            {
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            RefrescarToolstripLabelCliente();
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            clienteBindingSource.MoveNext();

            if (clienteBindingSource.Count <= 0 || clienteBindingSource.Position + 1 == clienteBindingSource.Count)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (clienteBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            RefrescarToolstripLabelCliente();
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            clienteBindingSource.MoveLast();
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            if (clienteBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            RefrescarToolstripLabelCliente();
        }

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

        //BOTONES
        private void HabilitarControlesEnAnadir()
        {
            //Botones
            buttonAceptar.Visible = true;
            buttonCancelar.Visible = true;
            toolStripButtonGuardar.Enabled = false;

            //Campos
            MostrarCampos();

            //ComboBox por defecto a una opción
            // tipoComboBox.SelectAll();
            // tipoComboBox.SelectedText = "M";
            //tipoComboBox.Text = "M";
            //tipoComboBox.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
            //tipoComboBox.SelectedItem = 0;
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
                    MessageBox.Show("No se puede eliminar el cliente porque no existe en la base de datos ", "Error en la eliminación de un cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    clienteBindingSource.RemoveCurrent();
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
            ComprobarDatosIntroducidos();

            this.clienteTableAdapter.Update(this.recoDueroDataSet); //Guarda en la base de datos

            EstadoControlesGuardar();
            RefrescarToolstripLabelCliente();

            MessageBox.Show("Guardado con éxito", " Guardado con exito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (toolStripButtonBuscar.Equals(""))
                {
                    MessageBox.Show("Introduzca un campo a buscar en el cuadro de texto", " no existe ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Busca por Nombre
                    if (toolStripComboBoxBuscarClientes.Text.Equals("Nombre"))
                    {
                        if (clienteBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text) == -1)
                        {
                            MessageBox.Show("El cliente no existe");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            clienteBindingSource.Position = clienteBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text);
                        }
                    }

                    //Busca por Id
                    if (toolStripComboBoxBuscarClientes.Text.Equals("Id"))
                    {
                        if (clienteBindingSource.Find("Id", toolStripTextBoxBuscar.Text) == -1)
                        {
                            MessageBox.Show("El cliente no existe");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            clienteBindingSource.Position = clienteBindingSource.Find("Id", toolStripTextBoxBuscar.Text);
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

        //Controla el estado de las flechas en Buscar
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

        private void EstadoControlesAceptar()
        {
            //Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarClientes.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;
            toolStripButtonGuardar.Enabled = true;

            //Campos
            OcultarCampos();

            //Botones
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            //Flechas
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

        private void EstadoControlesCancelar()
        {
            //Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarClientes.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;

            //Campos
            OcultarCampos();

            //Botones
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            //Flechas
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

        private void contratoPictureBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos gráficos|*.bmp;*.gif;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagen = openFileDialog1.FileName;
                contratoPictureBox.Image = Image.FromFile(imagen);
                contratoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                contratoPictureBox.Image = null;
            }
        }

        private void toolStripButtonImprimir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Imprimiendo...";

            string id = idClienteLabel1.Text;
            string nombre = nombreTextBox.Text;
            string apellidos = apellidosTextBox.Text;
            string direccion = direccionTextBox.Text;
      
            string telefono = telefonoTextBox.Text;
            string email = emailTextBox.Text;
            string tipo = tipoComboBox.Text;
            Image contrato = contratoPictureBox.Image;
            string observaciones = observacionesTextBox.Text;


            PrintDialog printDialog1 = new PrintDialog();

            printDialog1.AllowPrintToFile = false;
            printDialog1.AllowSelection = false;
            printDialog1.AllowSomePages = false;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                PrintDocument printDocument1 = new PrintDocument();
                printDocument1.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                {
                    e1.Graphics.DrawString("Id: " + id, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 100, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Nombre: " + nombre, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 125, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Apellidos: " + apellidos, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 150, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Dirección: " + direccion, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 175, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Teléfono: " + telefono, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 200, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Email: " + email, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 225, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Tipo: " + tipo, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 250, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Observaciones: " + observaciones, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 275, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    Point loc = new Point(100, 500);
                    e1.Graphics.DrawImage(contrato, loc);

                };
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
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

        //TODO: FALTA
        private void toolStripButtonInforme_Click(object sender, EventArgs e)
        {
            /*
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
            */
        }

        private void RefrescarToolstripLabelCliente()
        {
            this.toolstripLabelContadorClientes.Text = $"Cliente {clienteBindingSource.Position + 1} de {clienteBindingSource.Count}";
        }

        private void OcultarCampos() 
        {
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
            //Guardar
            if (e.Control && e.KeyCode == Keys.S)
            {
                toolStripButtonGuardar_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }

            //Añadir
            if (e.Control && e.KeyCode == Keys.A)
            {
                toolStripButtonAnadir_Click(this, EventArgs.Empty);
                e.Handled = true; // Evita que el evento de teclado se propague.
            }
        }
    }
}
