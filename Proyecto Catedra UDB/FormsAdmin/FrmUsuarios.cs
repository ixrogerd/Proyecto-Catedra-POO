using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmUsuarios : FrmAdministrador
    {
        public FrmUsuarios()
        {
            InitializeComponent();

            cmbTipoUsuario.SelectedIndex = 0;

            ConfigurarTabla();
            CargarEjemplos();
        }

        private void ConfigurarTabla()
        {
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add("Id", "ID");
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("Correo", "Correo");
            dgvUsuarios.Columns.Add("Tipo", "Tipo de usuario");
            dgvUsuarios.Columns.Add("Estado", "Estado");
        }

        private void CargarEjemplos()
        {
            dgvUsuarios.Rows.Clear();

            dgvUsuarios.Rows.Add(
                "1",
                "Administrador",
                "admin@sistema.com",
                "Administrador",
                "Activo");

            dgvUsuarios.Rows.Add(
                "2",
                "Juan Pérez",
                "juan@correo.com",
                "Médico",
                "Activo");

            dgvUsuarios.Rows.Add(
                "3",
                "María López",
                "maria@correo.com",
                "Paciente",
                "Activo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text.Trim().ToLower();
            string tipo = cmbTipoUsuario.Text;

            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                string nombreFila =
                    fila.Cells["Nombre"].Value?.ToString().ToLower() ?? "";

                string tipoFila =
                    fila.Cells["Tipo"].Value?.ToString() ?? "";

                bool coincideNombre =
                    nombre == "" || nombreFila.Contains(nombre);

                bool coincideTipo =
                    tipo == "Todos" || tipoFila == tipo;

                fila.Visible =
                    coincideNombre && coincideTipo;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Usuario seleccionado para actualizar.",
                "Usuarios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Desea eliminar el usuario seleccionado?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                dgvUsuarios.Rows.Remove(
                    dgvUsuarios.CurrentRow);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbTipoUsuario.SelectedIndex = 0;

            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
                fila.Visible = true;
        }
    }
}