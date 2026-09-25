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
            this.Hide();
            FrmInicioMedico frmInicioMedico = new FrmInicioMedico();
            frmInicioMedico.Show();
        }
        private void btnCitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCitasMedico frmCitasMedico = new FrmCitasMedico();
            frmCitasMedico.Show();
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAtenderCita frmAtenderCita = new FrmAtenderCita();
            frmAtenderCita.Show();
        }

        private void btnReceta_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmReceta frmReceta = new FrmReceta();
            frmReceta.Show();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHorarios frmHorarios = new FrmHorarios();
            frmHorarios.Show();
        }
    }
}
