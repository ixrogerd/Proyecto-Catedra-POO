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
    public partial class FrmRegistrarMedico : FrmAdministrador
    {
        public FrmRegistrarMedico()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnMedicos.BackColor = Color.SteelBlue;
            btnMedicos.ForeColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
