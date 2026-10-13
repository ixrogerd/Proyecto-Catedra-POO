using Proyecto_Catedra_UDB.Business;
using Proyecto_Catedra_UDB.FormsAdmin;
using Proyecto_Catedra_UDB.FormsMedico;
using Proyecto_Catedra_UDB.FormsPaciente;
using Proyecto_Catedra_UDB.Models;
using System;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            AcceptButton = btnIniciarSesion;          // Enter = iniciar sesion
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtContraseña.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Capa de negocio: valida, hashea, consulta y abre la sesion
                Usuario usuario = UsuarioBLL.Login(username, password);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Clear();
                    txtUsuario.Focus();
                    return;
                }

                Form menu = CrearMenuPorRol(usuario.ID_Rol);
                if (menu == null)
                {
                    Sesion.Cerrar();
                    MessageBox.Show("El rol de este usuario no tiene un menú asignado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Al cerrar el menú con la X o con "Cerrar sesión" se vuelve al login.
                // Application.Exit() ("Cerrar aplicación") sí termina el programa.
                menu.FormClosed += (s, args) =>
                {
                    if (args.CloseReason == CloseReason.UserClosing || args.CloseReason == CloseReason.None)
                    {
                        Sesion.Cerrar();
                        txtUsuario.Clear();
                        txtContraseña.Clear();
                        Show();
                        txtUsuario.Focus();
                    }
                };

                Hide();
                menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Form CrearMenuPorRol(int idRol)
        {
            switch (idRol)
            {
                case Roles.Paciente: return new FrmInicioPaciente();
                case Roles.Medico: return new FrmInicioMedico();
                case Roles.Administrador: return new FrmInicioAdmin();
                default: return null;
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}