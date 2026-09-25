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
    public partial class FrmAgendarCita : FrmPaciente
    {
        public FrmAgendarCita()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnAgendarCita.BackColor = Color.SteelBlue;
            btnAgendarCita.ForeColor = Color.White;
        }
    }
}
