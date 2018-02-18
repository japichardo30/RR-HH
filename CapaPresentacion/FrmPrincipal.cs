using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : MetroFramework.Forms.MetroForm
    {
        private int childFormNumber = 0;

        //Declaramos las siguientes variables para obtener la informacion de usuario que accede al sistema
        public string IdUsers = "";
        public string Users = "";
        public string Password = "";
        public string Accesos = "";

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void candidatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCandidatos frm = FrmCandidatos.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIdiomas frm = new FrmIdiomas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void capacitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCapacitaciones frm = new FrmCapacitaciones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void competenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompetencias frm = new FrmCompetencias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void experenciaLaboralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExperencia frm = new FrmExperencia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void candidatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCandidatos frm = FrmCandidatos.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuestos frm = new FrmPuestos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartamentos frm = new FrmDepartamentos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GestionUsuario()
        {
            //Controloes de los accesos
            if (Accesos == "Administrador")
            {
                this.mnuSistema.Enabled = true;
                this.mnuReclutamiento.Enabled = true;
                this.mnuMantenimientos.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.mnuConsultas.Enabled = true;
                this.mnuVer.Enabled = true;
                this.mnuVentanas.Enabled = true;
                this.helpMenu.Enabled = true;
                this.tsMantenimientos.Enabled = true;
                this.tsReclutamientos.Enabled = true;
            }

            else if (Accesos == "Candidatos")
            {
                this.mnuSistema.Enabled = true;
                this.mnuReclutamiento.Enabled = true;
                this.mnuMantenimientos.Enabled = false;
                this.mnuHerramientas.Enabled = true;
                this.mnuConsultas.Enabled = false;
                this.mnuVer.Enabled = true;
                this.mnuVentanas.Enabled = true;
                this.helpMenu.Enabled = true;
                this.tsMantenimientos.Enabled = false;
                this.tsReclutamientos.Enabled = true;
            }

            else
            {
                this.mnuSistema.Enabled = false;
                this.mnuReclutamiento.Enabled = false;
                this.mnuMantenimientos.Enabled = false;
                this.mnuHerramientas.Enabled = false;
                this.mnuConsultas.Enabled = false;
                this.mnuVer.Enabled = false;
                this.mnuVentanas.Enabled = false;
                this.helpMenu.Enabled = false;
                this.tsMantenimientos.Enabled = false;
                this.tsReclutamientos.Enabled = false;
            }
        }

        private void candidatosPostuladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPosCandidatos frm = new FrmPosCandidatos();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
