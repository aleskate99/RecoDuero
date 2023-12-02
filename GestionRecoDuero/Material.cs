﻿using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Material : Form
    {
        private bool datosGuardados = true;

        public Material()
        {
            InitializeComponent();
            KeyPreview = true;

            //Redondear controles
            Bordes.BordesRedondosBoton(buttonAceptar);
            Bordes.BordesRedondosBoton(buttonCancelar);
        }

        private void Material_Load(object sender, EventArgs e)
        {
            this.materialTableAdapter.Fill(this.recoDueroDataSet.Material);
            AjustarImagenes();
            EstadoControlesInicioApp();
            RefrescarToolstripLabelMaterial();
            toolStripStatusLabel1.Text = "Inicio";
        }

        private void buttonVolverInicio_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar materiales", MessageBoxButtons.OKCancel);
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

            if (materialBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarMateriales.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }
            else if (materialBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarMateriales.Enabled = true;
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
                toolStripComboBoxBuscarMateriales.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }
        }

        //FLECHAS
        private void NavegarRegistro(int indice)
        {
            // Comprobar si no hay registros en el origen de datos
            if (materialBindingSource.Count <= 0)
                return;

            // Mover el cursor del origen de datos al registro especificado por 'index'
            materialBindingSource.Position = indice;

            // Determinar si el registro actual es el primer o el último
            bool enPrimerRegistro = materialBindingSource.Position == 0;
            bool enUltimoRegistro = materialBindingSource.Position == materialBindingSource.Count - 1;

            // Habilitar o deshabilitar los botones de navegación según la posición del registro
            toolStripButtonInicio.Enabled = !enPrimerRegistro;
            toolStripButtonAnterior.Enabled = !enPrimerRegistro;
            toolStripButtonSiguiente.Enabled = !enUltimoRegistro;
            toolStripButtonFinal.Enabled = !enUltimoRegistro;

            RefrescarToolstripLabelMaterial();
        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            NavegarRegistro(0); // Ir al primer registro (con índice 0)
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            NavegarRegistro(materialBindingSource.Position - 1); // Ir al registro anterior (índice actual menos 1)
        }

        private void toolStripButtonSiguiente_Click(object sender, EventArgs e)
        {
            NavegarRegistro(materialBindingSource.Position + 1); // Ir al registro siguiente (índice actual más 1)
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            NavegarRegistro(materialBindingSource.Count - 1); // Ir al último registro
        }

        //AÑADIR
        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir material";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            materialBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();

            RefrescarToolstripLabelMaterial();
            datosGuardados = false;

            // Actualiza la fuente de datos con el valor predeterminado antes de guardar
            ((DataRowView)materialBindingSource.Current)["Cantidad"] = (int)cantidadNumericUpDown.Value;
            ((DataRowView)materialBindingSource.Current)["Coste"] = (int)costeNumericUpDown.Value;
            ((DataRowView)materialBindingSource.Current)["Estado"] = estadoComboBox.SelectedItem.ToString();

            ((DataRowView)materialBindingSource.Current)["FechaAdquisicion"] = fechaAdquisicionDateTimePicker.Value;
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
            estadoComboBox.SelectedIndex = 0;
            cantidadNumericUpDown.Value = 0;
            costeNumericUpDown.Value = 0;
            fechaAdquisicionDateTimePicker.Value = DateTime.Today;
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
            toolStripComboBoxBuscarMateriales.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //ELIMINAR
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar material";

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el material?", "Confirmación eliminar material", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (materialBindingSource.Count <= 0)
                {
                    Comun.MostrarMensajeDeError("No se puede eliminar el material porque no existe en la base de datos.", "Error en la eliminación de un material");
                }
                else
                {
                    materialBindingSource.RemoveCurrent();
                    materialBindingSource.EndEdit();
                    this.materialTableAdapter.Update(this.recoDueroDataSet);
                }

                if (materialBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (materialBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (materialBindingSource.Position + 1 == materialBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }

            RefrescarToolstripLabelMaterial();
        }

        //EDITAR
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editar material";
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
            toolStripComboBoxBuscarMateriales.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        //GUARDAR
        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                errorProvider1.Clear();

                materialBindingSource.EndEdit();
                this.materialTableAdapter.Update(this.recoDueroDataSet);

                EstadoControlesGuardar();
                RefrescarToolstripLabelMaterial();

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

            if (materialBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (materialBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (materialBindingSource.Position + 1 == materialBindingSource.Count && materialBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (materialBindingSource.Position + 1 == materialBindingSource.Count && materialBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (materialBindingSource.Count > 2 && materialBindingSource.Position + 1 != materialBindingSource.Count && materialBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (materialBindingSource.Position + 1 == 1 && materialBindingSource.Count > 1)
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
            toolStripComboBoxBuscarMateriales.Enabled = true;
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
                        e1.Graphics.DrawString(label + value, font, Brushes.Black, new RectangleF(25, y, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                        y += 25;
                    }

                    PrintLine("Id: ", idMaterialLabel1.Text);
                    PrintLine("Nombre: ", nombreTextBox.Text);
                    PrintLine("Cantidad: ", cantidadNumericUpDown.Text);
                    PrintLine("Coste: ", costeNumericUpDown.Text);
                    PrintLine("Distribuidor: ", distribuidorTextBox.Text);
                    PrintLine("Estado: ", estadoComboBox.Text);
                    PrintLine("Garantía: ", garantiaCheckBox.Text);
                    PrintLine("Fecha de adquisición: ", fechaAdquisicionDateTimePicker.Text);
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
            toolStripStatusLabel1.Text = "Informe Materiales";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformeMateriales))
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
                InformeMateriales informeMateriales = new InformeMateriales();
                informeMateriales.ShowDialog();
            }
        }

        //BUSCAR
        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar material";
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBoxBuscar.Text))
                {
                    Comun.MostrarMensajeDeError("Introduzca un campo a buscar en el cuadro de texto.", "Introduzca un campo");
                }
                else
                {
                    //ID
                    if (toolStripComboBoxBuscarMateriales.Text.Equals("Id"))
                    {
                        if (!Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un número, no letras.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (materialBindingSource.Find("IdMaterial", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El material no existe.", "Material no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            materialBindingSource.Position = materialBindingSource.Find("IdMaterial", toolStripTextBoxBuscar.Text);
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                    }

                    //Nombre
                    if (toolStripComboBoxBuscarMateriales.Text.Equals("Nombre"))
                    {
                        if (Comun.ContieneNumeros(toolStripTextBoxBuscar.Text))
                        {
                            MessageBox.Show("El formato no es válido. Debe ingresar un nombre, no un número.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripTextBoxBuscar.Text = String.Empty;
                            return;
                        }

                        if (materialBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El material no existe.", "Material no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            materialBindingSource.Position = materialBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text);
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                    }

                    //Distribuidor
                    if (toolStripComboBoxBuscarMateriales.Text.Equals("Distribuidor"))
                    {
                        if (materialBindingSource.Find("Distribuidor", toolStripTextBoxBuscar.Text) == -1)
                        {
                            Comun.MostrarMensajeDeError("El material no existe.", "Material no encontrado");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            materialBindingSource.Position = materialBindingSource.Find("Distribuidor", toolStripTextBoxBuscar.Text);
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                    }

                }
                RefrescarToolstripLabelMaterial();

                EstadoControlesBuscar();
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (materialBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (materialBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            if (materialBindingSource.Position + 1 == materialBindingSource.Count && materialBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (materialBindingSource.Position + 1 == materialBindingSource.Count && materialBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (materialBindingSource.Count > 2 && materialBindingSource.Position + 1 != materialBindingSource.Count && materialBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (materialBindingSource.Position + 1 == 1 && materialBindingSource.Count > 1)
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
                materialBindingSource.EndEdit();
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
                materialBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
                datosGuardados = false;
            }

            RefrescarToolstripLabelMaterial();
        }
        
        private void EstadoControlesCancelar()
        {
            HabilitarControlesComunes();
        }

        //MÉTODOS
        private void RefrescarToolstripLabelMaterial()
        {
            this.toolstripLabelContadorMateriales.Text = $"Material {materialBindingSource.Position + 1} de {materialBindingSource.Count}";
        }

        private void HabilitarControlesComunes()
        {
            // Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarMateriales.Enabled = true;
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
            bool tieneRegistros = materialBindingSource.Count > 0;
            bool esElPrimero = materialBindingSource.Position == 0;
            bool esElUltimo = materialBindingSource.Position == materialBindingSource.Count - 1;

            toolStripButtonInicio.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonAnterior.Enabled = !esElPrimero && tieneRegistros;
            toolStripButtonSiguiente.Enabled = !esElUltimo && tieneRegistros;
            toolStripButtonFinal.Enabled = !esElUltimo && tieneRegistros;
        }

        private void OcultarCampos()
        {
            idMaterialLabel1.Enabled = false;
            nombreTextBox.Enabled = false;
            cantidadNumericUpDown.Enabled = false;
            costeNumericUpDown.Enabled = false;
            distribuidorTextBox.Enabled = false;
            estadoComboBox.Enabled = false;

            garantiaCheckBox.Enabled = false;
            fechaAdquisicionDateTimePicker.Enabled = false;
            descripcionTextBox.Enabled = false;
        }

        private void MostrarCampos()
        {
            idMaterialLabel1.Enabled = true;
            nombreTextBox.Enabled = true;
            cantidadNumericUpDown.Enabled = true;
            costeNumericUpDown.Enabled = true;
            distribuidorTextBox.Enabled = true;
            estadoComboBox.Enabled = true;

            garantiaCheckBox.Enabled = true;
            fechaAdquisicionDateTimePicker.Enabled = true;
            descripcionTextBox.Enabled = true;
        }

        //COMPROBAR DATOS
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

            //Distribuidor
            if (string.IsNullOrWhiteSpace(distribuidorTextBox.Text))
            {
                errorProvider1.SetError(distribuidorTextBox, " Distribuidor obligatorio");
                distribuidorTextBox.Clear();
                return false;
            }
            else if (distribuidorTextBox.TextLength > 30)
            {
                errorProvider1.SetError(distribuidorTextBox, "No debe superar los 30 dígitos introducidos");
                distribuidorTextBox.Clear();
                return false;
            }

            //si todo es valido
            return true;
        }

        //Atajos de teclado
        private void Material_KeyDown(object sender, KeyEventArgs e)
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

        private void estadoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estadoComboBox.SelectedIndex >= 0)
            {
                string seleccion = estadoComboBox.SelectedItem.ToString();

                if (seleccion.Equals("Agotado"))
                {
                    cantidadNumericUpDown.Text = "0";
                }
            }
        }

        private void Material_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosGuardados == false)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos",
                    "Tiene cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        this.materialBindingSource.EndEdit();
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
