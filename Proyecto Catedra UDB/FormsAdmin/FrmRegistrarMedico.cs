using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
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
            txtTelefono.MaxLength = 15;
            txtCorreo.MaxLength = 100;
            txtUsuario.MaxLength = 50;
            txtClave.MaxLength = 50;
            txtClave.UseSystemPasswordChar = true;
            Ui.ConfigurarGrid(dgvMedicos);

            // Combo de especialidades
            cboEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEspecialidad.DisplayMember = "NombreEspecialidad";
            cboEspecialidad.ValueMember = "ID_Especialidad";
            try { cboEspecialidad.DataSource = new N_Especialidad().Listar(); }
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
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = true;
            cboEspecialidad.SelectedIndex = cboEspecialidad.Items.Count > 0 ? 0 : -1;
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
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                IdEspecialidad = cboEspecialidad.SelectedValue == null
                    ? 0 : Convert.ToInt32(cboEspecialidad.SelectedValue)
            };
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            txtTelefono.Text = f.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = f.Cells["Correo"].Value.ToString();
            txtUsuario.Text = f.Cells["Username"].Value.ToString();
            cboEspecialidad.SelectedValue = Convert.ToInt32(f.Cells["ID_Especialidad"].Value);
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = false;
        }

        private void FrmRegistrarMedico_Load(object sender, EventArgs e)
        {

        }
    }
}
