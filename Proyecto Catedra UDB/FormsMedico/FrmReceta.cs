using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmReceta : FrmMedico
    {
        public FrmReceta()
        {
            InitializeComponent();

            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;

            btnReceta.BackColor = Color.SteelBlue;
            btnReceta.ForeColor = Color.White;

            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            dgvMedicamentos.Columns.Clear();

            dgvMedicamentos.Columns.Add(
                "Medicamento",
                "Medicamento");

            dgvMedicamentos.Columns.Add(
                "Dosis",
                "Dosis");

            dgvMedicamentos.Columns.Add(
                "Frecuencia",
                "Frecuencia");

            dgvMedicamentos.Columns.Add(
                "Duracion",
                "Duración");

            dgvMedicamentos.Columns.Add(
                "Indicaciones",
                "Indicaciones");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicamento.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del medicamento.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMedicamento.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDosis.Text))
            {
                MessageBox.Show(
                    "Ingrese la dosis del medicamento.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDosis.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFrecuencia.Text))
            {
                MessageBox.Show(
                    "Ingrese la frecuencia del medicamento.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFrecuencia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDuracion.Text))
            {
                MessageBox.Show(
                    "Ingrese la duración del tratamiento.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDuracion.Focus();
                return;
            }

            dgvMedicamentos.Rows.Add(
                txtMedicamento.Text,
                txtDosis.Text,
                txtFrecuencia.Text,
                txtDuracion.Text,
                txtIndicaciones.Text);

            LimpiarMedicamento();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow != null)
            {
                dgvMedicamentos.Rows.Remove(
                    dgvMedicamentos.CurrentRow);
            }
            else
            {
                MessageBox.Show(
                    "Seleccione un medicamento para eliminar.",
                    "Eliminar medicamento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPaciente.Clear();
            dtpFecha.Value = DateTime.Now;

            dgvMedicamentos.Rows.Clear();

            LimpiarMedicamento();
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del paciente.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPaciente.Focus();
                return;
            }

            if (dgvMedicamentos.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un medicamento.",
                    "Receta vacía",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "La receta ha sido emitida correctamente.",
                "Receta médica",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtPaciente.Clear();
            dgvMedicamentos.Rows.Clear();
            LimpiarMedicamento();
        }

        private void LimpiarMedicamento()
        {
            txtMedicamento.Clear();
            txtDosis.Clear();
            txtFrecuencia.Clear();
            txtDuracion.Clear();
            txtIndicaciones.Clear();

            txtMedicamento.Focus();
        }
    }
}