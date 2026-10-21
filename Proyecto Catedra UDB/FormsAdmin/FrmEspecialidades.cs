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
    public partial class FrmEspecialidades : FrmAdministrador
    {
        private readonly N_Especialidad negocio = new N_Especialidad();

        public FrmEspecialidades()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnEspecialidades.BackColor = Color.SteelBlue;
            btnEspecialidades.ForeColor = Color.White;

            txtIdEspecialidad.ReadOnly = true;
            txtEspecialidad.MaxLength = 80;
            txtDescripcion.MaxLength = 200;
            Ui.ConfigurarGrid(dgvEspecialidades);

            Cargar();
        }
        private void Cargar()
        {
            try
            {
                dgvEspecialidades.DataSource = negocio.Buscar(txtBuscar.Text.Trim());
                dgvEspecialidades.Columns["ID_Especialidad"].HeaderText = "ID";
                dgvEspecialidades.Columns["NombreEspecialidad"].HeaderText = "Especialidad";
                dgvEspecialidades.Columns["Descripcion"].HeaderText = "Descripción";
                dgvEspecialidades.ClearSelection();
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }

        private void Limpiar()
        {
            txtIdEspecialidad.Clear();
            txtEspecialidad.Clear();
            txtDescripcion.Clear();
            dgvEspecialidades.ClearSelection();
        }

        private void FrmEspecialidades_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdEspecialidad.Text == "")
            {
                Ui.Aviso("Seleccione una especialidad de la tabla.");
                return;
            }
            Guardar("Especialidad actualizada correctamente.");
        }

        private void Guardar(string mensaje)
        {
            try
            {
                negocio.Guardar(new E_Especialidad
                {
                    Id = txtIdEspecialidad.Text == "" ? 0 : int.Parse(txtIdEspecialidad.Text),
                    Nombre = txtEspecialidad.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                });
                Ui.Info(mensaje);
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdEspecialidad.Text == "")
            {
                Ui.Aviso("Seleccione una especialidad de la tabla.");
                return;
            }
            DialogResult r = MessageBox.Show("¿Eliminar esta especialidad?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                negocio.Eliminar(int.Parse(txtIdEspecialidad.Text));
                Ui.Info("Especialidad eliminada.");
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

        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvEspecialidades.Rows[e.RowIndex];
            txtIdEspecialidad.Text = f.Cells["ID_Especialidad"].Value.ToString();
            txtEspecialidad.Text = f.Cells["NombreEspecialidad"].Value.ToString();
            txtDescripcion.Text = f.Cells["Descripcion"].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdEspecialidad.Text != "")
            {
                Ui.Aviso("Hay una especialidad seleccionada. Use EDITAR, o LIMPIAR para registrar otra.");
                return;
            }
            Guardar("Especialidad registrada correctamente.");
        }
    }
}
