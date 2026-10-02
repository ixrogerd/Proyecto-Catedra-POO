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
            FrmInicioAdmin frmInicioAdmin = new FrmInicioAdmin();
            frmInicioAdmin.Show();
            this.Hide();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmRegistrarPaciente frmRegistrarPaciente = new FrmRegistrarPaciente();
            frmRegistrarPaciente.Show();

            this.Hide();

        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            FrmRegistrarMedico frmRegistrarMedico = new FrmRegistrarMedico();
            frmRegistrarMedico.Show();
            this.Hide();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            FrmEspecialidades frmEspecialidades = new FrmEspecialidades();
            frmEspecialidades.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.Show();
            this.Hide();
        }


    }
}
