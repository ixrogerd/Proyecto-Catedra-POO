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

namespace Proyecto_Catedra_UDB.FormsAdmin
{
    public partial class FrmHorariosMedico : FrmAdministrador
    {
        private readonly N_Horario negocio = new N_Horario();
        private readonly int idMedico;       // médico cuyo horario se gestiona
        private int idSeleccionado = 0;      // fila de horario seleccionada

        public FrmHorariosMedico(int idMedico, string nombreMedico)
        {
            InitializeComponent();
            this.idMedico = idMedico;

            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnMedicos.BackColor = Color.SteelBlue;
            btnMedicos.ForeColor = Color.White;

            grpHorario.Text = "Horario de " + nombreMedico;
            Ui.ConfigurarGrid(dgvHorarios);
            ConfigurarHora(dtpHoraInicio);
            ConfigurarHora(dtpHoraFin);

            Limpiar();
            Cargar();
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
                dgvHorarios.DataSource = negocio.Listar(idMedico, cmbDia.SelectedIndex + 1);
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
            dtpHoraFin.Value = DateTime.Today.AddHours(12);
            dgvHorarios.ClearSelection();
        }

        private E_Horario Leer()
        {
            return new E_Horario
            {
                Id = idSeleccionado,
                IdMedico = idMedico,
                Dia = cmbDia.SelectedIndex + 1,   // Lunes = 1 ... Domingo = 7
                HoraInicio = new TimeSpan(dtpHoraInicio.Value.Hour, dtpHoraInicio.Value.Minute, 0),
                HoraFin = new TimeSpan(dtpHoraFin.Value.Hour, dtpHoraFin.Value.Minute, 0)
            };
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
                negocio.Eliminar(idSeleccionado, idMedico);
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

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvHorarios.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(f.Cells["ID_Horario"].Value);
            cmbDia.SelectedIndex = Convert.ToInt32(f.Cells["DiaSemana"].Value) - 1;
            dtpHoraInicio.Value = DateTime.Today.Add((TimeSpan)f.Cells["HoraInicio"].Value);
            dtpHoraFin.Value = DateTime.Today.Add((TimeSpan)f.Cells["HoraFin"].Value);
        }

        private void btnSeleccionarMedico_Click(object sender, EventArgs e)
        {
            FrmRegistrarMedico frmRegistrarMedico = new FrmRegistrarMedico();
            frmRegistrarMedico.Show();
            this.Hide();
        }
    }
}
