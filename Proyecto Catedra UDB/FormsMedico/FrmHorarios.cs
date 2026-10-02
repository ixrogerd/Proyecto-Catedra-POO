using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmHorarios : FrmMedico
    {
        public FrmHorarios()
        {
            InitializeComponent();

            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;

            btnHorarios.BackColor = Color.SteelBlue;
            btnHorarios.ForeColor = Color.White;

            ConfigurarTabla();

            cmbDia.SelectedIndex = 0;

            dtpHoraInicio.Value =
                DateTime.Today.AddHours(8);

            dtpHoraFin.Value =
                DateTime.Today.AddHours(17);
        }

        private void ConfigurarTabla()
        {
            dgvHorarios.Columns.Clear();

            dgvHorarios.Columns.Add(
                "Dia",
                "Día");

            dgvHorarios.Columns.Add(
                "HoraInicio",
                "Hora de inicio");

            dgvHorarios.Columns.Add(
                "HoraFin",
                "Hora de finalización");
        }

        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            if (cmbDia.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un día.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dtpHoraFin.Value.TimeOfDay <=
                dtpHoraInicio.Value.TimeOfDay)
            {
                MessageBox.Show(
                    "La hora de finalización debe ser mayor que la hora de inicio.",
                    "Horario incorrecto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Evitar agregar el mismo día dos veces
            foreach (DataGridViewRow fila in dgvHorarios.Rows)
            {
                if (fila.Cells["Dia"].Value != null &&
                    fila.Cells["Dia"].Value.ToString() ==
                    cmbDia.Text)
                {
                    MessageBox.Show(
                        "Ya existe un horario para " + cmbDia.Text + ".",
                        "Horario existente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            dgvHorarios.Rows.Add(
                cmbDia.Text,
                dtpHoraInicio.Value.ToString("hh:mm tt"),
                dtpHoraFin.Value.ToString("hh:mm tt"));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow != null)
            {
                dgvHorarios.Rows.Remove(
                    dgvHorarios.CurrentRow);
            }
            else
            {
                MessageBox.Show(
                    "Seleccione un horario para eliminar.",
                    "Eliminar horario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvHorarios.Rows.Clear();

            cmbDia.SelectedIndex = 0;

            dtpHoraInicio.Value =
                DateTime.Today.AddHours(8);

            dtpHoraFin.Value =
                DateTime.Today.AddHours(17);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un horario.",
                    "Sin horarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Los horarios han sido guardados correctamente.",
                "Horarios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}