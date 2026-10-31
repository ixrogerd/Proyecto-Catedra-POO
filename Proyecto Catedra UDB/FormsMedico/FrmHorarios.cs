using System;
using System.Drawing;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;


namespace Proyecto_Catedra_UDB
{
    public partial class FrmHorarios : FrmMedico
    {
        private readonly N_Horario negocio = new N_Horario();
        private int idSeleccionado = 0;
        private bool seleccionProgramatica = false; // Variable para evitar que el evento SelectedIndexChanged se dispare al cargar el combo
        public FrmHorarios()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnHorarios.BackColor = Color.SteelBlue;
            btnHorarios.ForeColor = Color.White;
        }
        private static void ConfigurarHora(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "HH:mm";
            dtp.ShowUpDown = true;
        }

        private void Cargar()
        {
            try
            {
                dgvHorarios.DataSource = negocio.Listar(Sesion.IdUsuario, cmbDia.SelectedIndex + 1);
                dgvHorarios.Columns["ID_Horario"].Visible = false;
                dgvHorarios.Columns["DiaSemana"].Visible = false;
                dgvHorarios.Columns["Dia"].HeaderText = "Día";
                dgvHorarios.Columns["HoraInicio"].HeaderText = "Hora de inicio";
                dgvHorarios.Columns["HoraFin"].HeaderText = "Hora de finalización";
                dgvHorarios.Columns["HoraInicio"].DefaultCellStyle.Format = @"hh\:mm";
                dgvHorarios.Columns["HoraFin"].DefaultCellStyle.Format = @"hh\:mm";
                dgvHorarios.ClearSelection();
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            cmbDia.SelectedIndex = -1;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(17);
            dgvHorarios.ClearSelection();
        }
        private void FrmHorarios_Load(object sender, EventArgs e)
        {

            Ui.ConfigurarGrid(dgvHorarios);
            ConfigurarHora(dtpHoraInicio);
            ConfigurarHora(dtpHoraFin);
            dgvHorarios.CellClick += dgvHorarios_CellClick;

            Limpiar();
            Cargar();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvHorarios.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(f.Cells["ID_Horario"].Value);

            // Activamos el seguro para que cambiar el combo no dispare Cargar()
            seleccionProgramatica = true;
            cmbDia.SelectedIndex = Convert.ToInt32(f.Cells["DiaSemana"].Value) -1;
            seleccionProgramatica = false;

            dtpHoraInicio.Value = DateTime.Today.Add((TimeSpan)f.Cells["HoraInicio"].Value);
            dtpHoraFin.Value = DateTime.Today.Add((TimeSpan)f.Cells["HoraFin"].Value);
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seleccionProgramatica) return; // Si el cambio viene del código, no recarga
            Cargar();
        }
    }
}