using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Proyecto_Catedra_UDB
{
    public partial class FrmUsuarios : FrmAdministrador
    {
        private readonly N_Usuario negocio = new N_Usuario();
        private int idSeleccionado = 0;
        private int idRolSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnUsuarios.BackColor = Color.SteelBlue;
            btnUsuarios.ForeColor = Color.White;

            cmbTipoUsuario.SelectedIndex = 0;
            txtUsername.MaxLength = 50;
            txtNuevaClave.MaxLength = 50;
            txtNuevaClave.UseSystemPasswordChar = true;
            Ui.ConfigurarGrid(dgvUsuarios);
            dgvUsuarios.CellFormatting += dgvUsuarios_CellFormatting;
            txtNuevaClave.Enabled = false;
            cbMostrarClave.Enabled = false;

            Cargar();
        }
        // Orden del combo: Todos, Administrador, Médico, Paciente
        private int IdRolSeleccionado()
        {
            switch (cmbTipoUsuario.Text)
            {
                case "Administrador": return Sesion.Administrador;
                case "Médico": return Sesion.Medico;
                case "Paciente": return Sesion.Paciente;
                default: return 0;
            }
        }
        // Carga los usuarios en el DataGridView según el texto de búsqueda y el tipo de usuario seleccionado
        private void Cargar()
        {
            try
            {
                dgvUsuarios.DataSource = negocio.Listar(txtBuscar.Text.Trim(), IdRolSeleccionado());
                dgvUsuarios.Columns["ID_Usuario"].Visible = false;
                dgvUsuarios.Columns["ID_Rol"].Visible = false;
                dgvUsuarios.Columns["Username"].HeaderText = "Usuario";
                dgvUsuarios.Columns["Rol"].HeaderText = "Tipo de usuario";

                foreach (DataGridViewRow f in dgvUsuarios.Rows)
                    if (f.Cells["Estado"].Value.ToString() == "Inactivo")
                        f.DefaultCellStyle.ForeColor = Color.Gray;

                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }
        // Limpia los campos de texto y el ID del usuario seleccionado
        private void LimpiarSeleccion()
        {
            idSeleccionado = 0;
            idRolSeleccionado = 0;
            txtUsername.Clear();
            txtNuevaClave.Clear();
            txtNuevaClave.Enabled = false;
            cbMostrarClave.Checked = false;
            cbMostrarClave.Enabled = false;
            dgvUsuarios.ClearSelection();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarSeleccion();
            Cargar();
        }
        // Actualiza la cuenta del usuario seleccionado
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un usuario de la tabla.");
                return;
            }
            try
            {
                negocio.ActualizarCuenta(idSeleccionado, txtUsername.Text, txtNuevaClave.Text);
                Ui.Info("Cuenta actualizada correctamente.");
                LimpiarSeleccion();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }
        // Inhabilita la cuenta del usuario seleccionado
        private void btnInhabilitar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un usuario de la tabla.");
                return;
            }
            DialogResult r = MessageBox.Show(
                "¿Inhabilitar esta cuenta? No podrá iniciar sesión y sus citas pendientes se cancelarán.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                negocio.Desactivar(idSeleccionado, idRolSeleccionado);
                LimpiarSeleccion();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbTipoUsuario.SelectedIndex = 0;
            LimpiarSeleccion();
            Cargar();
        }

        // Cambia el color de los usuarios inactivos a gris
        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            object estado = dgvUsuarios.Rows[e.RowIndex].Cells["Estado"].Value;
            if (estado != null && estado.ToString() == "Inactivo")
                e.CellStyle.ForeColor = Color.Gray;
        }

        // lleva el ID del usuario seleccionado a los campos de texto para poder editarlo
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvUsuarios.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(f.Cells["ID_Usuario"].Value);
            idRolSeleccionado = Convert.ToInt32(f.Cells["ID_Rol"].Value);
            txtUsername.Text = f.Cells["Username"].Value.ToString();
            txtBuscar.Text = f.Cells["Nombre"].Value.ToString();
            txtNuevaClave.Enabled = true;
            txtNuevaClave.Clear();
            cbMostrarClave.Checked = false;
            cbMostrarClave.Enabled = true;
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un usuario de la tabla.");
                return;
            }
            try
            {
                negocio.Reactivar(idSeleccionado, idRolSeleccionado);
                LimpiarSeleccion();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        // Muestra u oculta la contraseña según el estado del checkbox
        private void cbMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtNuevaClave.UseSystemPasswordChar = !cbMostrarClave.Checked;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}