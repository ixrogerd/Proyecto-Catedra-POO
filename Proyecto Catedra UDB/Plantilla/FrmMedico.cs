using Proyecto_Catedra_UDB.FormsAdmin;
using Proyecto_Catedra_UDB.FormsMedico;
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
    public partial class FrmMedico : FrmBase
    {
        public FrmMedico()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmInicioMedico frmInicioMedico = new FrmInicioMedico();
            frmInicioMedico.Show();
            this.Hide();
        }
        private void btnCitas_Click(object sender, EventArgs e)
        {
            FrmCitasMedico frmCitasMedico = new FrmCitasMedico();
            frmCitasMedico.Show();
            this.Hide();
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            FrmAtenderCita frmAtenderCita = new FrmAtenderCita();
            frmAtenderCita.Show();
            this.Hide();
        }

        private void btnReceta_Click(object sender, EventArgs e)
        {
            FrmReceta frmReceta = new FrmReceta();
            frmReceta.Show();
            this.Hide();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            FrmHorarios frmHorarios = new FrmHorarios();
            frmHorarios.Show();
            this.Hide();
        }
    }
}
