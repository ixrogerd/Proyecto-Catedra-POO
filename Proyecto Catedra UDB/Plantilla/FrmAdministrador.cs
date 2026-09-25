using Proyecto_Catedra_UDB.FormsAdmin;
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
    public partial class FrmAdministrador : FrmBase
    {
        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInicioAdmin frmInicioAdmin = new FrmInicioAdmin();
            frmInicioAdmin.Show();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegistrarPaciente frmRegistrarPaciente = new FrmRegistrarPaciente();
            frmRegistrarPaciente.Show();

        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegistrarMedico frmRegistrarMedico = new FrmRegistrarMedico();
            frmRegistrarMedico.Show();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmEspecialidades frmEspecialidades = new FrmEspecialidades();
            frmEspecialidades.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.Show();
        }


    }
}
