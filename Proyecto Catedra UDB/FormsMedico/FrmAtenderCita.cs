using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Proyecto_Catedra_UDB
{
    public partial class FrmAtenderCita : FrmMedico
    {
        private readonly N_Cita negocio = new N_Cita();
        private bool cargando = false;
        public FrmAtenderCita()
        {
            InitializeComponent();

            // Resaltar la opción actual del menú
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnAtender.BackColor = Color.SteelBlue;
            btnAtender.ForeColor = Color.White;

            txtDiagnostico.MaxLength = 500;
            txtTratamiento.MaxLength = 500;
            txtObservaciones.MaxLength = 500;

            cboCita.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCita.DisplayMember = "Texto";
            cboCita.ValueMember = "ID_Cita";
            cboCita.SelectedIndexChanged += (s, e) => MostrarCita();

            CargarCitas();
        }
        private void CargarCitas()
        {
            cargando = true;
            try { cboCita.DataSource = negocio.CitasPorAtender(Sesion.IdUsuario); }
            catch (Exception ex) { Ui.Error(ex.Message); }
            finally { cargando = false; }
            MostrarCita();
        }

        // Muestra los datos de la cita elegida en los campos de solo lectura
        private void MostrarCita()
        {
            if (cargando) return;

            DataRowView r = cboCita.SelectedItem as DataRowView;
            if (r == null)
            {
                txtPaciente.Text = "No hay citas pendientes";
                txtHora.Clear();
                txtMotivo.Clear();
                dtpFecha.Value = DateTime.Today;
                return;
            }
            txtPaciente.Text = r["Paciente"].ToString();
            dtpFecha.Value = Convert.ToDateTime(r["Fecha"]);
            txtHora.Text = ((TimeSpan)r["Hora"]).ToString(@"hh\:mm");
            txtMotivo.Text = r["Motivo"].ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCita = Ui.IdSeleccionado(cboCita);
            if (idCita == 0)
            {
                Ui.Aviso("Seleccione la cita que va a atender.");
                return;
            }
            try
            {
                negocio.Atender(idCita, Sesion.IdUsuario,
                    txtDiagnostico.Text.Trim(), txtTratamiento.Text.Trim(), txtObservaciones.Text.Trim());
                Ui.Info("La atención fue registrada. La cita quedó como Atendida.");
                LimpiarConsulta();
                CargarCitas();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
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

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}