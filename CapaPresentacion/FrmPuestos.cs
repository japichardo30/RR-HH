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
using MetroFramework;

namespace CapaPresentacion
{
    public partial class FrmPuestos : MetroFramework.Forms.MetroForm
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmPuestos()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del  puesto  el  cual  quiere agregar");
            this.ttMensaje.SetToolTip(this.txtSalarioMin, "Ingrese cual es su expectativa  minima salarial");
            this.ttMensaje.SetToolTip(this.txtSalarioMax, "Ingrese cual es su expectativa  maxima salarial");
            this.txtIdPuestos.Visible = false;

            //Contenido del ComboBox
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.Items.Add ("Seleccione una opcion");
            cmbNivel.Items.Add("Alto");
            cmbNivel.Items.Add("Medio");
            cmbNivel.Items.Add("Bajo");
            cmbNivel.SelectedIndex = 0;
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
            this.txtNombre.Text = string.Empty;
            this.txtSalarioMin.Text = string.Empty;
            this.txtSalarioMax.Text = string.Empty;
            this.txtIdPuestos.Text = string.Empty;
            cmbNivel.SelectedText = "";
            
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtSalarioMin.ReadOnly = !valor;
            this.txtSalarioMax.ReadOnly = !valor;
            this.txtIdPuestos.ReadOnly = !valor;
            this.cmbNivel.Enabled = true;
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
            this.dataListado.DataSource = NPuestos.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NPuestos.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmPuestos_Load(object sender, EventArgs e)
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
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtNombre, "Ingrese un nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NPuestos.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.cmbNivel.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtSalarioMin.Text), Convert.ToDecimal(this.txtSalarioMax.Text), this.chkEstado.Text.Trim());
                    }
                    else
                    {
                        rpta = NPuestos.Editar(Convert.ToInt32(this.txtIdPuestos.Text), this.txtNombre.Text.Trim().ToUpper(), this.cmbNivel.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtSalarioMin.Text), Convert.ToDecimal(this.txtSalarioMax.Text), this.chkEstado.Text.Trim());
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
            if (!this.txtIdPuestos.Text.Equals(""))
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

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstado.Checked)
            {
                chkEstado.ThreeState = true;
                chkEstado.CheckAlign = ContentAlignment.MiddleRight;
                chkEstado.Text = "True";
            }
            else if (!chkEstado.Checked)
            {
                chkEstado.ThreeState = false;
                chkEstado.CheckAlign = ContentAlignment.MiddleLeft;
                chkEstado.Text = "False";
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
                            Rpta = NPuestos.Eliminar(Convert.ToInt32(Codigo));

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
            this.txtIdPuestos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_puestos"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtSalarioMin.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Salario_min"].Value);
            this.txtSalarioMax.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Salario_max"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
