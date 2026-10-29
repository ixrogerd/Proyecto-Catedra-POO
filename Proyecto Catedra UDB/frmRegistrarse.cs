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

        private void txtConfirmarClave_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(lblConfirmarClave, txtClave.Text != txtConfirmarClave.Text ? "Las contraseñas no coinciden." : "");

            if (txtClave.Text == txtConfirmarClave.Text && !string.IsNullOrEmpty(txtClave.Text))
            {
                btnRegistrarse.Enabled = true;
                btnRegistrarse.BackColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                btnRegistrarse.Enabled = false;
                btnRegistrarse.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtConfirmarClave.Text))
                txtConfirmarClave_TextChanged(sender, e);
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
    }
}
