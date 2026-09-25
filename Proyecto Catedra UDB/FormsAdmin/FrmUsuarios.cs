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
    public partial class FrmUsuarios : FrmAdministrador
    {
        public FrmUsuarios()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnUsuarios.BackColor = Color.SteelBlue;
            btnUsuarios.ForeColor = Color.White;
        }
    }
}
