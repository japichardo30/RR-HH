using Microsoft.Reporting.WinForms;
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
    public partial class FrmReporteCandidatos : MetroFramework.Forms.MetroForm
    {
        private int _IdCandidato;
        public int IdCandidato
        {
            get { return _IdCandidato; }
            set { _IdCandidato = value; }
        }
        public FrmReporteCandidatos()
        {
            InitializeComponent();
        }

        private void FrmReporteCandidatos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPrincipal.spreporte_candidatos' table. You can move, or remove it, as needed.
            this.spreporte_candidatosTableAdapter.Fill(this.dsPrincipal.spreporte_candidatos,IdCandidato);


            this.reportViewer2.RefreshReport();
        }
    }
}
