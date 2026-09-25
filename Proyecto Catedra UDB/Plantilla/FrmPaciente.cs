using Proyecto_Catedra_UDB.FormsPaciente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmPaciente : FrmBase
    {
        public FrmPaciente()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInicioPaciente frmInicioPaciente = new FrmInicioPaciente();
            frmInicioPaciente.Show();
        }

        private void btnDisponibilidad_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDisponibilidad frmDisponibilidad = new FrmDisponibilidad();
            frmDisponibilidad.Show();
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAgendarCita frmAgendarCita = new FrmAgendarCita();
            frmAgendarCita.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCitasPaciente frmCitasPaciente = new FrmCitasPaciente();
            frmCitasPaciente.Show();
        }
    }
}
