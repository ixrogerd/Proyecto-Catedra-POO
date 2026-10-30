using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Proyecto_Catedra_UDB
{
    public partial class FrmRegistrarMedico : FrmAdministrador
    {
        private readonly N_Medico negocio = new N_Medico();
        private int idSeleccionado = 0;
        public FrmRegistrarMedico()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnMedicos.BackColor = Color.SteelBlue;
            btnMedicos.ForeColor = Color.White;

            txtNombre.MaxLength = 60;
            txtApellido.MaxLength = 60;
            txtCorreo.MaxLength = 100;
            txtUsuario.MaxLength = 50;
            txtClave.MaxLength = 50;
            txtClave.UseSystemPasswordChar = true;
            Ui.ConfigurarGrid(dgvMedicos);

            // Combo de especialidades
            cboEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEspecialidad.DisplayMember = "NombreEspecialidad";
            cboEspecialidad.ValueMember = "ID_Especialidad";
            try 
            { 
                cboEspecialidad.DataSource = new N_Especialidad().Listar();
            }
            catch (Exception ex) { Ui.Error(ex.Message); }

          

            Limpiar();
            Cargar();
        }
        
        private void Cargar()
        {
            try
            {
                dgvMedicos.DataSource = negocio.Listar(txtBuscar.Text.Trim());
                dgvMedicos.Columns["ID_Medico"].Visible = false;
                dgvMedicos.Columns["ID_Especialidad"].Visible = false;
                dgvMedicos.Columns["Username"].HeaderText = "Usuario";
                dgvMedicos.Columns["Telefono"].HeaderText = "Teléfono";
                dgvMedicos.Columns["NombreEspecialidad"].HeaderText = "Especialidad";
                dgvMedicos.ClearSelection();
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            mtxTelefono.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = true;
            cboEspecialidad.SelectedIndex = -1;
            dgvMedicos.ClearSelection();
            txtNombre.Focus();
        }

        private E_Medico Leer()
        {
            return new E_Medico
            {
                Id = idSeleccionado,
                Username = txtUsuario.Text.Trim(),
                Clave = txtClave.Text,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = mtxTelefono.MaskFull ? mtxTelefono.Text : "",
                Correo = txtCorreo.Text.Trim(),
                IdEspecialidad = cboEspecialidad.SelectedValue == null
                    ? 0 : Convert.ToInt32(cboEspecialidad.SelectedValue)
            };
        }

        private string GenerarUsuario()
        {
            string usuario = txtNombre.Text.Trim().ToLower().Split(' ')[0] + "." + txtApellido.Text.Trim().ToLower().Split(' ')[0] + "_" + new Random().Next(100,999);
            int contador = 1;
            while (negocio.UsuarioExiste(usuario + contador))
                contador++;
            return usuario + contador;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Ui.Aviso("Hay un médico seleccionado. Use EDITAR, o LIMPIAR para registrar otro.");
                return;
            }
            try
            {
                negocio.Registrar(Leer());
                Ui.Info("Médico registrado correctamente.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un médico de la tabla.");
                return;
            }
            try
            {
                negocio.Actualizar(Leer());
                Ui.Info("Médico actualizado correctamente.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un médico de la tabla.");
                return;
            }
            DialogResult r = MessageBox.Show(
                "¿Eliminar este médico? Su cuenta quedará inhabilitada y sus citas pendientes se cancelarán.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                negocio.Eliminar(idSeleccionado);
                Ui.Info("Médico eliminado.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            Limpiar();
            Cargar();
        }

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvMedicos.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(f.Cells["ID_Medico"].Value);
            txtNombre.Text = f.Cells["Nombre"].Value.ToString();
            txtApellido.Text = f.Cells["Apellido"].Value.ToString();
            mtxTelefono.Text = f.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = f.Cells["Correo"].Value.ToString();
            txtUsuario.Text = f.Cells["Username"].Value.ToString();
            cboEspecialidad.SelectedValue = Convert.ToInt32(f.Cells["ID_Especialidad"].Value);
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cbMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !cbMostrarClave.Checked;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = GenerarUsuario();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = GenerarUsuario();
        }
    }
}
