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
    public partial class FrmCapacitaciones : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;


        public FrmCapacitaciones()
        {
            InitializeComponent();
            //Contenido del ComboBox
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.Items.Add("Grado");
            cmbNivel.Items.Add("Post Grado");
            cmbNivel.Items.Add("Maestria");
            cmbNivel.Items.Add("Doctorado");
            cmbNivel.Items.Add("Tecnico");
            cmbNivel.Items.Add("Gestion");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese el nombre de la capacitacion tomada");
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
            this.txtDescripcion.Text = string.Empty;
            this.txtInstitucion.Text = string.Empty;
            this.txtIdCapacitaciones.Text = string.Empty;
            this.cmbNivel.ValueMember = string.Empty;
            
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdCapacitaciones.ReadOnly = !valor;
            this.txtInstitucion.ReadOnly = !valor;
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
        }

        //Metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCapacitaciones.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCapacitaciones.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmCapacitaciones_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
            this.txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDescripcion.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtDescripcion, "Ingrese un nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCapacitaciones.Insertar(this.txtDescripcion.Text.Trim().ToUpper(), this.cmbNivel.Text.Trim(), this.dtpFechaInicio.Value.Date, this.dtpFechaFin.Value.Date, this.txtInstitucion.Text.Trim().ToUpper());
                    }
                    else
                    {
                        rpta = NCapacitaciones.Editar(Convert.ToInt32(this.txtIdCapacitaciones.Text), this.txtDescripcion.Text.Trim().ToUpper(), this.cmbNivel.Text.Trim(), this.dtpFechaInicio.Value.Date, this.dtpFechaFin.Value.Date, this.txtInstitucion.Text.Trim().ToUpper());
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdCapacitaciones.Text.Equals(""))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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
                            Rpta = NCapacitaciones.Eliminar(Convert.ToInt32(Codigo));

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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCapacitaciones.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_capacitaciones"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.cmbNivel.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nivel"].Value);
            this.txtInstitucion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Institucion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
