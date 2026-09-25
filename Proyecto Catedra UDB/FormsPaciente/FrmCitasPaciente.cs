using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB.FormsPaciente
{
    public partial class FrmCitasPaciente : FrmPaciente
    {
        public FrmCitasPaciente()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnCitas.BackColor = Color.SteelBlue;
            btnCitas.ForeColor = Color.White;
        }
    }
}
