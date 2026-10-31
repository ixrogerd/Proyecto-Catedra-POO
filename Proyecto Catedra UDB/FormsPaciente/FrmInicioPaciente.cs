using System.Drawing;
using Proyecto_Catedra_UDB.Plantilla;

namespace Proyecto_Catedra_UDB.FormsPaciente
{
    public partial class FrmInicioPaciente : FrmPaciente
    {
        public FrmInicioPaciente()
        {
            InitializeComponent();

            btnInicio.BackColor = Color.SteelBlue;
            btnInicio.ForeColor = Color.White;
        }
    }
}