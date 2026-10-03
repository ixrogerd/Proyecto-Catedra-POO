using Proyecto_Catedra_UDB.FormsAdmin;
using Proyecto_Catedra_UDB.FormsMedico;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            FrmInicioAdmin frmInicioAdmin = new FrmInicioAdmin();
            frmInicioAdmin.Show();
            FrmInicioMedico frmInicioMedico = new FrmInicioMedico();
            //frmInicioMedico.Show();
            FrmInicioPaciente frmInicioPaciente = new FrmInicioPaciente();
            //frmInicioPaciente.Show();

            if (txtUsuario.Text == "admin")
            {
                frmInicioAdmin.Show();
            }
            else if (txtUsuario.Text == "medico")
            {
                frmInicioMedico.Show();
            }
            else if (txtUsuario.Text == "paciente")
            {
                frmInicioPaciente.Show();
            }
            this.Hide();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
