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
    public partial class FrmRegistrarPaciente : FrmAdministrador
    {
        private readonly N_Paciente negocio = new N_Paciente();
        private int idSeleccionado = 0;
        public FrmRegistrarPaciente()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnPacientes.BackColor = Color.SteelBlue;
            btnPacientes.ForeColor = Color.White;

            txtNombre.MaxLength = 60;
            txtApellido.MaxLength = 60;
            txtTelefono.MaxLength = 15;
            txtCorreo.MaxLength = 100;
            txtUsuario.MaxLength = 50;
            txtClave.MaxLength = 50;
            txtClave.UseSystemPasswordChar = true;
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            Ui.ConfigurarGrid(dataGridView1);


            Limpiar();
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                dataGridView1.DataSource = negocio.Listar(txtBuscar.Text.Trim());
                dataGridView1.Columns["ID_Paciente"].Visible = false;
                dataGridView1.Columns["Username"].HeaderText = "Usuario";
                dataGridView1.Columns["FechaNacimiento"].HeaderText = "Fecha de nacimiento";
                dataGridView1.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridView1.ClearSelection();
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
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
            dataGridView1.ClearSelection();
            txtNombre.Focus();
        }
        private E_Paciente Leer()
        {
            return new E_Paciente
            {
                Id = idSeleccionado,
                Username = txtUsuario.Text.Trim(),
                Clave = txtClave.Text,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };
        }


        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Ui.Aviso("Hay un paciente seleccionado. Use EDITAR, o LIMPIAR para registrar otro.");
                return;
            }
            try
            {
                negocio.Registrar(Leer());
                Ui.Info("Paciente registrado correctamente.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un paciente de la tabla.");
                return;
            }
            try
            {
                negocio.Actualizar(Leer());
                Ui.Info("Paciente actualizado correctamente.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un paciente de la tabla.");
                return;
            }
            DialogResult r = MessageBox.Show(
                "¿Eliminar este paciente? Su cuenta quedará inhabilitada y sus citas pendientes se cancelarán.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                negocio.Eliminar(idSeleccionado);
                Ui.Info("Paciente eliminado.");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dataGridView1.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(f.Cells["ID_Paciente"].Value);
            txtNombre.Text = f.Cells["Nombre"].Value.ToString();
            txtApellido.Text = f.Cells["Apellido"].Value.ToString();
            dtpFechaNacimiento.Value = Convert.ToDateTime(f.Cells["FechaNacimiento"].Value);
            txtTelefono.Text = f.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = f.Cells["Correo"].Value.ToString();
            txtUsuario.Text = f.Cells["Username"].Value.ToString();
            txtClave.Clear();
            txtUsuario.Enabled = txtClave.Enabled = false;   // la cuenta se edita en Usuarios
        }

        private void FrmRegistrarPaciente_Load(object sender, EventArgs e)
        {

        }
    }
}
