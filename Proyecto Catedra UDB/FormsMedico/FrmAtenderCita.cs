using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmAtenderCita : FrmMedico
    {
        public FrmAtenderCita()
        {
            InitializeComponent();

            // Resaltar la opción actual del menú.
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;

            btnAtender.BackColor = Color.SteelBlue;
            btnAtender.ForeColor = Color.White;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el diagnóstico del paciente.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDiagnostico.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTratamiento.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el tratamiento o las indicaciones.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTratamiento.Focus();
                return;
            }

            MessageBox.Show(
                "La atención médica ha sido registrada correctamente.",
                "Atención registrada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarConsulta();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarConsulta();
        }

        private void LimpiarConsulta()
        {
            txtDiagnostico.Clear();
            txtTratamiento.Clear();
            txtObservaciones.Clear();

            txtDiagnostico.Focus();
        }
    }
}