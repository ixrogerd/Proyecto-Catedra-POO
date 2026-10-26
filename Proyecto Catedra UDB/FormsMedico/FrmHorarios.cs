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
            dtp.CustomFormat = "hh:mm tt";
            dtp.ShowUpDown = true;
        }

        private void Cargar()
        {
            try
            {
                dgvHorarios.DataSource = negocio.Listar(Sesion.IdUsuario);
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
            cmbDia.SelectedIndex = 0;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(17);
            dgvHorarios.ClearSelection();
        }
        private E_Horario Leer()
        {
            return new E_Horario
            {
                Id = idSeleccionado,
                IdMedico = Sesion.IdUsuario,
                Dia = cmbDia.SelectedIndex + 1,   // Lunes = 1 ... Domingo = 7
                HoraInicio = new TimeSpan(dtpHoraInicio.Value.Hour, dtpHoraInicio.Value.Minute, 0),
                HoraFin = new TimeSpan(dtpHoraFin.Value.Hour, dtpHoraFin.Value.Minute, 0)
            };
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
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un horario de la tabla.");
                return;
            }
            DialogResult r = MessageBox.Show("¿Eliminar este horario?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                negocio.Eliminar(idSeleccionado, Sesion.IdUsuario);
                Ui.Info("Horario eliminado.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Ui.Aviso("Hay un horario seleccionado. Use EDITAR, o LIMPIAR para registrar otro.");
                return;
            }
            try
            {
                negocio.Registrar(Leer());
                Ui.Info("Horario guardado correctamente.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Ui.Aviso("Seleccione un horario de la tabla.");
                return;
            }
            try
            {
                negocio.Actualizar(Leer());
                Ui.Info("Horario actualizado correctamente.");
                Limpiar();
                Cargar();
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvHorarios.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(f.Cells["ID_Horario"].Value);
            cmbDia.SelectedIndex = Convert.ToInt32(f.Cells["DiaSemana"].Value) - 1;
            dtpHoraInicio.Value = DateTime.Today.Add((TimeSpan)f.Cells["HoraInicio"].Value);
            dtpHoraFin.Value = DateTime.Today.Add((TimeSpan)f.Cells["HoraFin"].Value);
        }
    }
}