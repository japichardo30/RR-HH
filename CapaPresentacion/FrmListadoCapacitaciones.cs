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
    public partial class FrmListadoCapacitaciones : MetroFramework.Forms.MetroForm
    {
        public FrmListadoCapacitaciones()
        {
            InitializeComponent();
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
            //this.txtIdCapacitaciones.Text = string.Empty;
            this.cmbNivel.ValueMember = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtDescripcion.ReadOnly = !valor;
            this.txtInstitucion.ReadOnly = !valor;
            this.btnGuardar.Enabled = valor;
            this.btnCancelar.Enabled = valor;
            this.dtpFechaFin.Enabled = valor;
            this.dtpFechaInicio.Enabled = valor;
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

        private void FrmListadoCapacitaciones_Load(object sender, EventArgs e)
        {
            this.Mostrar();
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
                    rpta = NCapacitaciones.Insertar(this.txtDescripcion.Text.Trim().ToUpper(), this.cmbNivel.Text.Trim(), this.dtpFechaInicio.Value.Date, this.dtpFechaFin.Value.Date, this.txtInstitucion.Text.Trim().ToUpper());

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    //this.IsNuevo = false;
                    //this.IsEditar = false;
                    //this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           //this.IsNuevo = false;
            //this.IsEditar = false;
            //this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmCandidatos form = FrmCandidatos.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id_capacitaciones"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            form.setCapacitaciones(par1, par2);
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
