using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
using System;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class frmRegistrarse : Form
    {
        public frmRegistrarse()
        {
            InitializeComponent();
            txtClave.UseSystemPasswordChar = true;
            btnRegistrarse.Enabled = false;
            btnRegistrarse.BackColor = System.Drawing.Color.LightGray;
            pnlDatosPer.Visible = true;
            this.FormClosed += (s, e) => btnLogin_Click(s, e);
        }
        private readonly N_Paciente negocio = new N_Paciente();

        private E_Paciente Leer()
        {
            return new E_Paciente
            {
                Id = 0,
                Username = txtUsuario.Text.Trim(),
                Clave = txtClave.Text,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = true;
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
            txtNombre.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                negocio.Registrar(Leer());
                Ui.Info("Paciente registrado correctamente. Inicie sesión para continuar.");
                Limpiar();
                btnLogin_Click(sender, e);
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pnlUsuario.Show();
            pnlDatosPer.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlUsuario.Hide();
            pnlDatosPer.Show();
        }

        private void cbMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !cbMostrarContra.Checked;
        }
    }
}
