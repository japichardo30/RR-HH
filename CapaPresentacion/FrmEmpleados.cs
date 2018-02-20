using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmEmpleados : MetroFramework.Forms.MetroForm
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;


        public FrmEmpleados()
        {
            InitializeComponent();
            //Mensajes guiatorios del formulario
            this.ttMensaje.SetToolTip(this.txtCedula, "Ingrese su numero de cedula unica");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese sus nombres");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese sus apellidos");
            this.ttMensaje.SetToolTip(this.txtSalario, "Ingrese el salario que quiera devengar");
            this.ttMensaje.SetToolTip(this.pbImagen, "Seleccione la imagen del candidato");
            this.ttMensaje.SetToolTip(this.cmbPuestos, "Seleccione el puesto por el cual quiere optar");
            this.ttMensaje.SetToolTip(this.cmbDepartamentos, "Seleccione el departamento al que correspondera");

            this.txtIdEmpleados.Visible = false;

            //Llenar combo box
            this.LlenarComboPuestos();
            this.LlenarComboDepartamentos();
        }

        //Mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema RRHH", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema RRHH", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCedula.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtSalario.Text = string.Empty;
            this.pbImagen.Image = global::CapaPresentacion.Properties.Resources.file;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //this.txtIdCandidatos.ReadOnly = !valor;
            this.txtCedula.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtSalario.ReadOnly = !valor;
            this.cmbPuestos.Enabled = valor;
            this.cmbDepartamentos.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Metodo para Ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NEmpleados.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NEmpleados.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarComboPuestos()
        {
            cmbPuestos.DataSource = NPuestos.Mostrar();
            cmbPuestos.ValueMember = "id_puestos";
            cmbPuestos.DisplayMember = "Nombre";
        }

        private void LlenarComboDepartamentos()
        {
            cmbDepartamentos.DataSource = NDepartamentos.Mostrar();
            cmbDepartamentos.ValueMember = "id_departamento";
            cmbDepartamentos.DisplayMember = "Nombre";
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCedula.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtCedula.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtCedula, "Ingrese un valor");
                    erroricono.SetError(txtNombre, "Ingrese un valor");
                    erroricono.SetError(txtApellido, "Ingrese un valor");
                    erroricono.SetError(txtSalario, "Ingrese un valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] image = ms.GetBuffer();
                    if (this.IsNuevo)
                    {
                        rpta = NEmpleados.Insertar(this.txtCedula.Text.Trim(), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellido.Text.Trim().ToUpper(), this.dtpFechaIngreso.Value.Date, 
                            Convert.ToInt32(this.cmbPuestos.SelectedValue), Convert.ToInt32(this.cmbDepartamentos.SelectedValue),
                             image, Convert.ToDecimal(this.txtSalario.Text), this.chkEstado.Text.Trim());
                    }
                    else
                    {
                        rpta = NEmpleados.Editar(Convert.ToInt32(this.txtIdEmpleados.Text), 
                           this.txtCedula.Text.Trim(), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellido.Text.Trim().ToUpper(), this.dtpFechaIngreso.Value.Date,
                            Convert.ToInt32(this.cmbPuestos.SelectedValue), Convert.ToInt32(this.cmbDepartamentos.SelectedValue),
                             image, Convert.ToDecimal(this.txtSalario.Text), this.chkEstado.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstado.Checked)
            {
                chkEstado.ThreeState = true;
                chkEstado.CheckAlign = ContentAlignment.MiddleRight;
                chkEstado.Text = "True";
            }
            else
            {
                chkEstado.ThreeState = false;
                chkEstado.CheckAlign = ContentAlignment.MiddleLeft;
                chkEstado.Text = "False";
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdEmpleados.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pbImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente quieres eliminar los registros", "Sistema RRHH", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NEmpleados.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdEmpleados.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_empleado"].Value);
            this.txtCedula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            //this.dtpFechaIngreso.Value = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha_ingeso"].Value);
            

            //La imagen es un arreglo por lo que primero debemos de convertirla
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["Imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pbImagen.Image = Image.FromStream(ms);
            this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtSalario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Salario"].Value);
            this.cmbPuestos.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_puesto"].Value);
            this.cmbDepartamentos.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_departamento"].Value);


            this.tabControl1.SelectedIndex = 1;
        }
    }
}
