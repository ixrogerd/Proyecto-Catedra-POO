using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
using System;
using System.Security.Cryptography;
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
                Telefono = mtxTelefono.MaskFull ? mtxTelefono.Text : "",
                Correo = txtCorreo.Text.Trim()
            };
        }

        private string GenerarUsuario()
        {
            string usuario = txtNombre.Text.Trim().ToLower().Split(' ')[0] + "." + txtApellido.Text.Trim().ToLower().Split(' ')[0] + "_" + new Random().Next(100, 999);
            int contador = 1;
            while (negocio.UsuarioExiste(usuario + contador))
                contador++;
            return usuario + contador;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            mtxTelefono.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = true;
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
            txtNombre.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && mtxTelefono.MaskFull)
            {
                txtUsuario.Text = GenerarUsuario();
                pnlUsuario.Show();
                pnlDatosPer.Hide();
                txtUsuario.Focus();
            }
            else
                Ui.Aviso("Complete los campos de nombre, apellido y teléfono antes de continuar.");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlUsuario.Hide();
            pnlDatosPer.Show();
        }

        //Mostrar u ocultar contraseña 
        private void cbMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !cbMostrarClave.Checked;
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            errContraseña.SetError(lblClave,txtClave.Text.Length <6 ? "La contraseña debe tener al menos 6 caracteres." : "");
            if (txtClave.Text.Length >= 6)
            {
                btnRegistrarse.Enabled = true;
                btnRegistrarse.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnRegistrarse.Enabled = false;
                btnRegistrarse.BackColor = System.Drawing.Color.LightGray;
            }
        }

    }
}
