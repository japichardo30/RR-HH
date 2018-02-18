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
    public partial class FrmCandidatos : MetroFramework.Forms.MetroForm
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmCandidatos _Instancia;
        
        public static FrmCandidatos GetInstancia()
        {
            if(_Instancia == null)
            {
                _Instancia = new FrmCandidatos();
            }
            return _Instancia;
        }

        public void setIdiomas(string ididioma, string nombre)
        {
            this.txtIdIdioma.Text = ididioma;
            this.txtIdioma.Text = nombre;
        }

        public void setCompetencias(string idcompetencias, string descripcion)
        {
            this.txtIdCompetencias.Text = idcompetencias;
            this.txtCompetencias.Text = descripcion;
        }

        public void setCapacitaciones(string idcapacitaciones, string descripcion)
        {
            this.txtIdCapacitaciones.Text = idcapacitaciones;
            this.txtCapacitaciones.Text = descripcion;
        }

        public void setExperiencia(string idExperiencia, string puesto)
        {
            this.txtIdExperiencia.Text = idExperiencia;
            this.txtExperiencia.Text = puesto;
        }

        public FrmCandidatos()
        {
            InitializeComponent();

            //Mensajes guiatorios del formulario
            this.ttMensaje.SetToolTip(this.txtCedula, "Ingrese su numero de cedula unica");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese sus nombres");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese sus apellidos");
            this.ttMensaje.SetToolTip(this.txtSalario, "Ingrese el salario que quiera devengar");
            this.ttMensaje.SetToolTip(this.txtRecomendado, "Ingrese el nombre de la persona que lo recomienda, de no tener dejar en blanco");
            this.ttMensaje.SetToolTip(this.pbImagen, "Seleccione la imagen del candidato");
            this.ttMensaje.SetToolTip(this.cmbPuestos, "Seleccione el puesto por el cual quiere optar");
            this.ttMensaje.SetToolTip(this.txtIdioma, "Ingrese un segundo idioma hablado");
            this.ttMensaje.SetToolTip(this.txtCompetencias, "Elija las competencias manejadas");
            this.ttMensaje.SetToolTip(this.txtCapacitaciones, "Ingrese el nombre de la capacitacion tomada");

            //Manejo de campos que llaman a otra tabla de la base de datos
            this.txtIdIdioma.Visible = false;
            this.txtIdCompetencias.Visible = false;
            this.txtIdCapacitaciones.Visible = false;
            this.txtIdExperiencia.Visible = false;
            this.txtIdCandidatos.Visible = false;
            this.btnEliminar.Visible = false;

            this.txtIdioma.ReadOnly = true;
            this.txtCapacitaciones.ReadOnly = true;
            this.txtCompetencias.ReadOnly = true;
            this.txtExperiencia.ReadOnly = true;

            //Llenar combo box
            this.LlenarComboPuestos();
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
            this.txtRecomendado.Text = string.Empty;
            this.txtIdioma.Text = string.Empty;
            this.txtCapacitaciones.Text = string.Empty;
            this.txtCompetencias.Text = string.Empty;
            this.txtExperiencia.Text = string.Empty;
            this.pbImagen.Image = global::CapaPresentacion.Properties.Resources.file;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdCandidatos.ReadOnly = !valor;
            this.txtCedula.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtSalario.ReadOnly = !valor;
            this.txtRecomendado.ReadOnly = !valor;
            this.txtIdioma.ReadOnly = !valor;
            this.btnBuscarIdioma.Enabled = valor;
            this.txtCompetencias.ReadOnly = !valor;
            this.btnBuscarCompetencias.Enabled = valor;
            this.txtCapacitaciones.ReadOnly = !valor;
            this.btnBuscarCapacitaciones.Enabled = valor;
            this.txtExperiencia.ReadOnly = !valor;
            this.btnBuscarExperiencia.Enabled = valor;
            this.cmbPuestos.Enabled = valor;
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
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            this.dataListado.Columns[16].Visible = false;
        }

        //Metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCandidatos.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCandidatos.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarComboPuestos()
        {
            cmbPuestos.DataSource = NPuestos.Mostrar();
            cmbPuestos.ValueMember = "id_puestos";
            cmbPuestos.DisplayMember = "Nombre";
        }

        private void FrmCandidatos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBRRHHDataSet.Experiencia' table. You can move, or remove it, as needed.
            this.experienciaTableAdapter.Fill(this.dBRRHHDataSet.Experiencia);
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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
                    this.pbImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);

                    byte[] image = ms.GetBuffer();
                    if (this.IsNuevo)
                    {
                        rpta = NCandidatos.Insertar(this.txtCedula.Text.Trim(), this.txtNombre.Text.Trim().ToUpper(), 
                            this.txtApellido.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtSalario.Text), image, 
                            this.txtRecomendado.Text.Trim().ToUpper(), Convert.ToInt32(this.txtIdIdioma.Text), 
                            Convert.ToInt32(this.txtIdCompetencias.Text), Convert.ToInt32(this.txtIdExperiencia.Text), 
                            Convert.ToInt32(this.cmbPuestos.SelectedValue), Convert.ToInt32(this.txtIdCapacitaciones.Text));
                    }
                    else
                    {
                        rpta = NCandidatos.Editar(Convert.ToInt32(this.txtIdCandidatos.Text), this.txtCedula.Text.Trim(), 
                            this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), 
                            Convert.ToDecimal(this.txtSalario.Text), image, this.txtRecomendado.Text.Trim().ToUpper(), 
                            Convert.ToInt32(this.txtIdIdioma.Text), Convert.ToInt32(this.txtCompetencias.Text),
                            Convert.ToInt32(this.txtExperiencia.Text), Convert.ToInt32(this.cmbPuestos.SelectedValue),
                            Convert.ToInt32(this.txtCapacitaciones.Text));
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
            if (!this.txtIdCandidatos.Text.Equals(""))
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
            this.txtIdCandidatos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_candidato"].Value);
            this.txtCedula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.txtSalario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Salario_aspira"].Value);
            this.txtRecomendado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Recomendado"].Value);

            //La imagen es un arreglo por lo que primero debemos de convertirla
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["Imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pbImagen.Image = Image.FromStream(ms);
            this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdExperiencia.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_experiencia"].Value);
            this.txtExperiencia.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Experiencia"].Value);
            this.txtIdIdioma.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_idiomas"].Value);
            this.txtIdioma.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Idiomas"].Value);
            this.txtIdCompetencias.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_competencias"].Value);
            this.txtCompetencias.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Competencias"].Value);
            this.txtIdCapacitaciones.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_capacitaciones"].Value);
            this.txtIdCapacitaciones.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Capacitaciones"].Value);
            this.cmbPuestos.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_puesto"].Value);



            this.tabControl1.SelectedIndex = 1;
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
                            Rpta = NCandidatos.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnBuscarIdioma_Click(object sender, EventArgs e)
        {
            FrmListadoIdiomas form = new FrmListadoIdiomas();
            form.ShowDialog();
        }

        private void btnBuscarCompetencias_Click(object sender, EventArgs e)
        {
            FrmListadoCompetencias form = new FrmListadoCompetencias();
            form.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarCapacitaciones_Click(object sender, EventArgs e)
        {
            FrmListadoCapacitaciones form = new FrmListadoCapacitaciones();
            form.ShowDialog();
        }

        private void btnBuscarExperiencia_Click(object sender, EventArgs e)
        {
            FrmListadoExperiencia form = new FrmListadoExperiencia();
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteCandidatos frm = new FrmReporteCandidatos();
            frm.IdCandidato = Convert.ToInt32(this.dataListado.CurrentRow.Cells["id_candidato"].Value);
            frm.ShowDialog();
        }
    }
}
