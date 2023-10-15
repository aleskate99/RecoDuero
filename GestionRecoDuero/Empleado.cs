using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionRecoDuero
{
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            this.empleadoTableAdapter.Fill(this.recoDueroDataSet.Empleado);
            AjustarImagenes();
            EstadoControlesInicioApp();
            toolStripStatusLabel1.Text = "Inicio";
            RefrescarToolstripLabelEmpleado();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            var volver = MessageBox.Show("¿Quiere volver a la ventana principal?", "Cerrar empleados", MessageBoxButtons.OKCancel);
            if (volver == DialogResult.OK)
            {
                this.Close();
            }
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

            //Ajustar imágen botón formulario
            this.toolStripButtonInforme.AutoSize = false;
            this.toolStripButtonInforme.Width = 50;
            this.toolStripButtonInforme.Height = 50;
            this.toolStripButtonInforme.ImageScaling = ToolStripItemImageScaling.None;

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
            idEmpleadoLabel1.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidosTextBox.Enabled = false;
            dNITextBox.Enabled = false; 
            fechaNacimientoDateTimePicker.Enabled = false;
            telefonoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            generoComboBox.Enabled = false;

            puestoComboBox.Enabled = false;
            situacionLaboralComboBox.Enabled = false;
            salarioTextBox.Enabled = false;
            imagenPictureBox.Enabled = false;

            //Aceptar y cancelar invisibles hasta que se realice una operación
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;

            if (empleadoBindingSource.Count < 1)
            {
                toolStripButtonEliminar.Enabled = false;
                toolStripButtonEditar.Enabled = false;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarEmpleados.Enabled = false;
                toolStripTextBoxBuscar.Enabled = false;
                toolStripButtonBuscar.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            else if (empleadoBindingSource.Count == 1)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonEliminar.Enabled = true;
                toolStripButtonEditar.Enabled = true;
                toolStripButtonGuardar.Enabled = false;
                toolStripComboBoxBuscarEmpleados.Enabled = true;
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
                toolStripComboBoxBuscarEmpleados.Enabled = true;
                toolStripTextBoxBuscar.Enabled = true;
                toolStripButtonBuscar.Enabled = true;
            }


        }

        private void toolStripButtonInicio_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.MoveFirst();
            toolStripButtonInicio.Enabled = false;
            toolStripButtonAnterior.Enabled = false;

            if (empleadoBindingSource.Count > 1)
            {
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            RefrescarToolstripLabelEmpleado();
        }

        private void toolStripButtonAnterior_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.MovePrevious();
            if (empleadoBindingSource.Position <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;

            }

            if (empleadoBindingSource.Count > 1)
            {
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            RefrescarToolstripLabelEmpleado();
        }

        private void toolStripButtonSiguiente_Click_1(object sender, EventArgs e)
        {
            empleadoBindingSource.MoveNext();
            if (empleadoBindingSource.Count <= 0 || empleadoBindingSource.Position + 1 == empleadoBindingSource.Count)
            {
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;

            }

            if (empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            RefrescarToolstripLabelEmpleado();
        }

        private void toolStripButtonFinal_Click(object sender, EventArgs e)
        {
            empleadoBindingSource.MoveLast();
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            if (empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
            }

            RefrescarToolstripLabelEmpleado();
        }

        private void toolStripButtonAnadir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Añadir empleado";
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;

            empleadoBindingSource.AddNew();

            DeshabilitarBotonesEnAnadir();
            HabilitarControlesEnAnadir();
            RefrescarToolstripLabelEmpleado();
        }

        private void HabilitarControlesEnAnadir()
        {
            //Botones
            buttonAceptar.Visible = true;
            buttonCancelar.Visible = true;
            toolStripButtonGuardar.Enabled = false;

            //Campos
            idEmpleadoLabel1.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidosTextBox.Enabled = true;
            dNITextBox.Enabled = true;
            fechaNacimientoDateTimePicker.Enabled = true;
            telefonoTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            generoComboBox.Enabled = true;

            puestoComboBox.Enabled = true;
            situacionLaboralComboBox.Enabled = true;
            salarioTextBox.Enabled = true;
            imagenPictureBox.Enabled = true;

            //ComboBox por defecto a una opción
            generoComboBox.SelectedIndex = 0;
            puestoComboBox.SelectedIndex = 0;
            situacionLaboralComboBox.SelectedIndex = 0;

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
            toolStripComboBoxBuscarEmpleados.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;

        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Eliminar empleado";

            var resultado = MessageBox.Show("¿Está seguro que desea elimina el empleado?", "Confirmación eliminar empleado", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                if (empleadoBindingSource.Count <= 0)
                {
                    MessageBox.Show("No se puede eliminar el empleado porque no existe en la base de datos ", "Error en la eliminación de un empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    empleadoBindingSource.RemoveCurrent();
                }

                if (empleadoBindingSource.Count == 1)
                {
                    toolStripButtonAnterior.Enabled = false;
                    toolStripButtonInicio.Enabled = false;
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }

                if (empleadoBindingSource.Count == 0)
                {
                    EstadoControlesInicioApp();
                }

                if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count)
                {
                    toolStripButtonSiguiente.Enabled = false;
                    toolStripButtonFinal.Enabled = false;
                }
            }

            RefrescarToolstripLabelEmpleado();
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
            toolStripButtonGuardar.Enabled = false;


            //Campos
            idEmpleadoLabel1.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidosTextBox.Enabled = true;
            dNITextBox.Enabled = true;
            fechaNacimientoDateTimePicker.Enabled = true;
            telefonoTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            generoComboBox.Enabled = true;

            puestoComboBox.Enabled = true;
            situacionLaboralComboBox.Enabled = true;
            salarioTextBox.Enabled = true;
            imagenPictureBox.Enabled = true;

            //Botones barra
            toolStripButtonAnadir.Enabled = false;
            toolStripButtonAnterior.Enabled = false;
            toolStripButtonInicio.Enabled = false;
            toolStripButtonSiguiente.Enabled = false;
            toolStripButtonFinal.Enabled = false;
            toolStripButtonEditar.Enabled = false;
            toolStripButtonEliminar.Enabled = false;
            toolStripButtonBuscar.Enabled = false;
            toolStripComboBoxBuscarEmpleados.Enabled = false;
            toolStripTextBoxBuscar.Enabled = false;
        }

        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            ComprobarDatosIntroducidos();

            this.empleadoTableAdapter.Update(this.recoDueroDataSet); //Guarda en la base de datos

            EstadoControlesGuardar();
            RefrescarToolstripLabelEmpleado();

            MessageBox.Show("Guardado con éxito", " Guardado con exito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EstadoControlesGuardar()
        {
            toolStripButtonAnadir.Enabled = true;
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;
            toolStripButtonGuardar.Enabled = false;
            toolStripButtonBuscar.Enabled = true;


            if (empleadoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;

            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Count > 2 && empleadoBindingSource.Position + 1 != empleadoBindingSource.Count && empleadoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (empleadoBindingSource.Position + 1 == 1 && empleadoBindingSource.Count > 1)
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
            toolStripComboBoxBuscarEmpleados.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;

            //Campos
            idEmpleadoLabel1.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidosTextBox.Enabled = false;
            dNITextBox.Enabled = false;
            fechaNacimientoDateTimePicker.Enabled = false;
            telefonoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            generoComboBox.Enabled = false;

            puestoComboBox.Enabled = false;
            situacionLaboralComboBox.Enabled = false;
            salarioTextBox.Enabled = false;
            imagenPictureBox.Enabled = false;
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Buscar empleado";
            try
            {
                if (toolStripButtonBuscar.Equals(""))
                {
                    MessageBox.Show("Introduzca un campo a buscar en el cuadro de texto", " no existe ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (toolStripComboBoxBuscarEmpleados.Text.Equals("DNI"))
                    {
                        if (empleadoBindingSource.Find("DNI", toolStripTextBoxBuscar.Text) == -1)
                        {
                            MessageBox.Show("El empleado no existe");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            empleadoBindingSource.Position = empleadoBindingSource.Find("DNI", toolStripTextBoxBuscar.Text);
                        }
                    }

                    if (toolStripComboBoxBuscarEmpleados.Text.Equals("Id"))
                    {
                        if (empleadoBindingSource.Find("IdEmpleado", toolStripTextBoxBuscar.Text) == -1)
                        {
                            MessageBox.Show("El empleado no existe");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            empleadoBindingSource.Position = empleadoBindingSource.Find("IdEmpleado", toolStripTextBoxBuscar.Text);
                        }
                    }


                    if (toolStripComboBoxBuscarEmpleados.Text.Equals("Nombre"))
                    {
                        if (empleadoBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text) == -1)
                        {
                            MessageBox.Show("El empleado no existe");
                            toolStripTextBoxBuscar.Text = String.Empty;
                        }
                        else
                        {
                            empleadoBindingSource.Position = empleadoBindingSource.Find("Nombre", toolStripTextBoxBuscar.Text);
                        }
                    }

                }
                RefrescarToolstripLabelEmpleado();

                EstadoControlesBuscar();

            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del valor introducido no es correcto ", " Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoControlesBuscar()
        {
            if (empleadoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;

            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Count > 2 && empleadoBindingSource.Position + 1 != empleadoBindingSource.Count && empleadoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (empleadoBindingSource.Position + 1 == 1 && empleadoBindingSource.Count > 1)
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
               empleadoBindingSource.EndEdit(); //Lo guarda en memoria
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
            toolStripComboBoxBuscarEmpleados.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;
            toolStripButtonGuardar.Enabled = true;


            //Campos
            idEmpleadoLabel1.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidosTextBox.Enabled = false;
            dNITextBox.Enabled = false;
            fechaNacimientoDateTimePicker.Enabled = false;
            telefonoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            generoComboBox.Enabled = false;

            puestoComboBox.Enabled = false;
            situacionLaboralComboBox.Enabled = false;
            salarioTextBox.Enabled = false;
            imagenPictureBox.Enabled = false;

            //Botones
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;


            //Flechas
            if (empleadoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;

            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Count > 2 && empleadoBindingSource.Position + 1 != empleadoBindingSource.Count && empleadoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (empleadoBindingSource.Position + 1 == 1 && empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

        }
        
        private bool ComprobarDatosIntroducidos()
        {
            //DNI
            if (dNITextBox.Text.Length == 0)
            {
                errorProvider1.SetError(dNITextBox, " DNI obligatorio");
                dNITextBox.Clear();
                return false;
            }

            else if (!ComprobarDni(dNITextBox.Text))
            {
                errorProvider1.SetError(dNITextBox, "Debe tener 8 números y 1 Letra");
                dNITextBox.Clear();
                return false;
            }

            //Nombre
            if (nombreTextBox.Text.Length == 0)
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
            else if (!ContieneSoloLetras(nombreTextBox.Text))
            {
                errorProvider1.SetError(nombreTextBox, "Solo puede introducir letras en el campo nombre");
                nombreTextBox.Clear();
                return false;
            }

            //Apellidos
            if (apellidosTextBox.Text.Length == 0)
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
            else if (!ContieneSoloLetras(apellidosTextBox.Text))
            {
                errorProvider1.SetError(apellidosTextBox, "Solo puede introducir letras en el campo apellidos ");
                apellidosTextBox.Clear();
                return false;
            }

            //Telefono
            if (ContieneNumeros(telefonoTextBox.Text) == false)
            {
                errorProvider1.SetError(telefonoTextBox, "Solo puede introducir números");
                telefonoTextBox.Clear();
                return false;
            }

            else if ((telefonoTextBox.Text.Length != 9) && (telefonoTextBox.Text.Length != 0))
            {
                errorProvider1.SetError(telefonoTextBox, "Debe tener 9 dígitos");
                telefonoTextBox.Clear();
                return false;
            }

            //si todo es valido
            return true;
        }

        private void dNITextBox_Validating(object sender, CancelEventArgs e)
        {

            if (ComprobarDni(dNITextBox.Text) == false && (dNITextBox.Text.Length != 0))
            {
                errorProvider1.SetError(dNITextBox, "El DNI debe tener 8 números y 1 letra");
                dNITextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void nombreTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (nombreTextBox.TextLength > 30)
            {
                errorProvider1.SetError(nombreTextBox, "No debe superar los 30 dígitos introducidos");
                nombreTextBox.Clear();
            }

            else if (!ContieneSoloLetras(nombreTextBox.Text))
            {
                errorProvider1.SetError(nombreTextBox, "Solo puede introducir letras en el campo nombre");
                nombreTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void apellidosTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (apellidosTextBox.TextLength > 50)
            {
                errorProvider1.SetError(apellidosTextBox, "No debe superar los 50 dígitos introducidos ");
                apellidosTextBox.Clear();
            }
            else if (!ContieneSoloLetras(apellidosTextBox.Text))
            {
                errorProvider1.SetError(apellidosTextBox, "Solo puede introducir letras en el campo apellidos ");
                apellidosTextBox.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void telefonoTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (ContieneNumeros(telefonoTextBox.Text) == false)
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

        private bool ContieneNumeros(String campo)
        {
            bool devolver = true;

            foreach (char num in campo)
            {
                if (num >= 48 && num <= 57)
                {
                    devolver = true;
                }
                else
                {
                    devolver = false;
                }

            }
            return devolver;
        }


        private bool ComprobarDni(String campo)
        {
            int contaLetras = 0;
            int contaNumeros = 0;

            foreach (char letra in campo)
            {
                if ((letra >= 65 && letra <= 90) || (letra >= 97 && letra <= 122))
                {
                    contaLetras++;
                }

                if (letra >= 48 && letra <= 57)
                {
                    contaNumeros++;
                }

            }

            if (contaNumeros == 8 && contaLetras == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Controla mayusculas,minusculas,Ñ,ñ y vocales acentuadas
        private bool ContieneSoloLetras(String campo)
        {
            bool devolver = true;

            foreach (char letra in campo)
            {
                if ((letra >= 65 && letra <= 90) || (letra >= 97 && letra <= 122) || (letra >= 160 && letra <= 165) || (letra == 130)
                    || (letra == 181) || (letra == 144) || (letra == 214) || (letra == 224) || (letra == 233))
                {
                    devolver = true;
                }
                else
                {
                    devolver = false;
                }

            }
            return devolver;
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Quiere cancelar la operación?", "Confirmación botón cancelar", MessageBoxButtons.OKCancel);
            if (resultado == DialogResult.OK)
            {
                empleadoBindingSource.CancelEdit();
                EstadoControlesCancelar();
                errorProvider1.Clear();
            }

            RefrescarToolstripLabelEmpleado();
        }

        private void EstadoControlesCancelar()
        {
            //Botones
            toolStripButtonAnadir.Enabled = true;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonEliminar.Enabled = true;
            toolStripButtonBuscar.Enabled = true;
            toolStripComboBoxBuscarEmpleados.Enabled = true;
            toolStripTextBoxBuscar.Enabled = true;


            //Campos
            idEmpleadoLabel1.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidosTextBox.Enabled = false;
            dNITextBox.Enabled = false;
            fechaNacimientoDateTimePicker.Enabled = false;
            telefonoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            generoComboBox.Enabled = false;

            puestoComboBox.Enabled = false;
            situacionLaboralComboBox.Enabled = false;
            salarioTextBox.Enabled = false;
            imagenPictureBox.Enabled = false;

            //Botones
            buttonAceptar.Visible = false;
            buttonCancelar.Visible = false;


            if (empleadoBindingSource.Count <= 0)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;

            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Position + 1 == empleadoBindingSource.Count && empleadoBindingSource.Count == 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = false;
                toolStripButtonFinal.Enabled = false;
            }

            if (empleadoBindingSource.Count > 2 && empleadoBindingSource.Position + 1 != empleadoBindingSource.Count && empleadoBindingSource.Position + 1 != 1)
            {
                toolStripButtonAnterior.Enabled = true;
                toolStripButtonInicio.Enabled = true;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }

            if (empleadoBindingSource.Position + 1 == 1 && empleadoBindingSource.Count > 1)
            {
                toolStripButtonAnterior.Enabled = false;
                toolStripButtonInicio.Enabled = false;
                toolStripButtonSiguiente.Enabled = true;
                toolStripButtonFinal.Enabled = true;
            }
        }

        private void imagenPictureBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos gráficos|*.bmp;*.gif;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagen = openFileDialog1.FileName;
                imagenPictureBox.Image = Image.FromFile(imagen);
                imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                imagenPictureBox.Image = null;
            }
        }

        private void RefrescarToolstripLabelEmpleado()
        {
            this.toolstripLabelContadorEmpleados.Text = $"Empleado {empleadoBindingSource.Position + 1} de {empleadoBindingSource.Count}";
        }

        private void toolStripButtonImprimir_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Imprimiendo...";

            string id = idEmpleadoLabel1.Text;
            string nombre = nombreTextBox.Text;
            string apellidos = apellidosTextBox.Text;
            string dni = dNITextBox.Text;
            string fechaNacimiento = fechaNacimientoDateTimePicker.Text;
            string telefono = telefonoTextBox.Text;
            string email = emailTextBox.Text;
            string genero = generoComboBox.Text;

            string puesto = puestoComboBox.Text;
            string situacionLaboral = situacionLaboralComboBox.Text;
            string salario = salarioTextBox.Text;
            Image imagen = imagenPictureBox.Image;


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
                    e1.Graphics.DrawString("DNI: " + dni, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 175, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Fecha de nacimiento: " + fechaNacimiento, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 200, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Teléfono: " + telefono, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 225, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));

                    e1.Graphics.DrawString("Email: " + email, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 250, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Género: " + genero, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 275, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Puesto: " + puesto, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 300, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Situación laboral: " + situacionLaboral, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 325, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString("Salario: " + salario, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(50, 350, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height));

                    Point loc = new Point(100, 500);
                    e1.Graphics.DrawImage(imagen, loc);

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

        private void Empleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(recoDueroDataSet.GetChanges() is null))
            {
                if (MessageBox.Show("¿Desea guardar antes de salir?\nSi no lo hace perderá los datos", this.Text, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.empleadoBindingSource.CancelEdit();
                    this.tableAdapterManager.UpdateAll(this.recoDueroDataSet);
                }
            }
        }

        private void toolStripButtonInforme_Click(object sender, EventArgs e)
        {
            /*
            toolStripStatusLabel1.Text = "Informe Empleados";
            Boolean abierto = false;

            //comprobamos que no esta abierto el formulario;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(InformeEmpleados))
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
                InformeEmpleados informeEmpleados = new InformeEmpleados();
                informeEmpleados.ShowDialog();
            }
            */
        }

       
    }
}
