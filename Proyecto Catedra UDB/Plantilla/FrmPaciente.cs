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
            FrmInicioPaciente frmInicioPaciente = new FrmInicioPaciente();
            frmInicioPaciente.Show();
            this.Hide();
        }

        private void btnDisponibilidad_Click(object sender, EventArgs e)
        {
            FrmDisponibilidad frmDisponibilidad = new FrmDisponibilidad();
            frmDisponibilidad.Show();
            this.Hide();
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            FrmAgendarCita frmAgendarCita = new FrmAgendarCita();
            frmAgendarCita.Show();
            this.Hide();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FrmCitasPaciente frmCitasPaciente = new FrmCitasPaciente();
            frmCitasPaciente.Show();
            this.Hide();
        }
    }
}
