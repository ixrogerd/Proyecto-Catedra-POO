using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MostrarUsuario();
        }

        // Pone el nombre del usuario logueado arriba a la derecha
        private void MostrarUsuario()
        {
            if (string.IsNullOrEmpty(Sesion.NombreCompleto)) return;

            lblUser.Text = Sesion.NombreCompleto;
            lblUser.Left = ClientSize.Width - lblUser.Width - 20;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void FrmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
