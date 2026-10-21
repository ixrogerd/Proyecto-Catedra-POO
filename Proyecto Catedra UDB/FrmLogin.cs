using System;
using System.Data;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.FormsAdmin;
using Proyecto_Catedra_UDB.FormsMedico;
using Proyecto_Catedra_UDB.FormsPaciente;
namespace Proyecto_Catedra_UDB
{
    public partial class FrmLogin : Form
    {
        private readonly N_Usuario negocio = new N_Usuario();

        public FrmLogin()
        {
            InitializeComponent();
            AcceptButton = btnIniciarSesion;          // Enter = iniciar sesión
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
                E_Usuario obj = new E_Usuario { usuario = username, clave = password };
                DataTable dt = negocio.Login(obj);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Clear();
                    txtUsuario.Focus();
                    return;
                }

                // Guardar la sesión
                DataRow fila = dt.Rows[0];
                Sesion.IdUsuario = Convert.ToInt32(fila["ID_Usuario"]);
                Sesion.Username = fila["Username"].ToString();
                Sesion.IdRol = Convert.ToInt32(fila["ID_Rol"]);
                Sesion.Rol = fila["Rol"].ToString();
                Sesion.NombreCompleto = fila["NombreCompleto"].ToString();

                // Redirigir según el rol
                Form menu = CrearMenuPorRol(Sesion.IdRol);
                if (menu == null)
                {
                    Sesion.Limpiar();
                    MessageBox.Show("El rol de este usuario no tiene un menú asignado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Al cerrar el menú (X o "Cerrar sesión") se vuelve al login.
                // Application.Exit() ("Cerrar aplicación") sí termina el programa.
                menu.FormClosed += (s, args) =>
                {
                    if (args.CloseReason == CloseReason.UserClosing || args.CloseReason == CloseReason.None)
                    {
                        Sesion.Limpiar();
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
                case Sesion.Paciente: return new FrmInicioPaciente();
                case Sesion.Medico: return new FrmInicioMedico();
                case Sesion.Administrador: return new FrmInicioAdmin();
                default: return null;
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}