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
            //frmInicioAdmin.Show();
            FrmInicioMedico frmInicioMedico = new FrmInicioMedico();
            frmInicioMedico.Show();
            FrmInicioPaciente frmInicioPaciente = new FrmInicioPaciente();
            //frmInicioPaciente.Show();
            this.Hide();
        }
    }
}
