using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmListadoExperiencia : MetroFramework.Forms.MetroForm
    {
        public int idExperiencia = 0;
        public bool btnOk = false;

        public FrmListadoExperiencia()
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
            this.txtEmpresa.Text = string.Empty;
            this.txtPuesto.Text = string.Empty;
            this.txtIdExperencia.Text = string.Empty;
            this.txtSalario.Text = string.Empty;
            this.btnCancelar.Enabled = false;
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
            this.dataListado.DataSource = NExperencia.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmListadoExperiencia_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnOk = true;
            try
            {
                string rpta = "";
                if (this.txtEmpresa.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtEmpresa, "Ingrese un nombre");
                }
                else
                {
                    rpta = NExperencia.Insertar(this.txtEmpresa.Text.Trim().ToUpper(), this.txtPuesto.Text.Trim().ToUpper(), this.dtpFechaInicio.Value.Date, this.dtpFechaFin.Value.Date, Convert.ToDecimal(this.txtSalario.Text));
                    FrmCandidatos form = FrmCandidatos.GetInstancia();
                    string par1, par2;
                    par1 = Convert.ToString(idExperiencia);
                    par2 = Convert.ToString(this.txtPuesto.Text);
                    form.setExperiencia(par1, par2);
                    this.Hide();
                }

                if (rpta.Equals("OK"))
                {
                    this.MensajeOk("Se inserto de forma correcta el registro");
                }
                else
                {
                    this.MensajeError(rpta);
                }

                this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

            Close();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
