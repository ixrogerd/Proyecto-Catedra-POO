using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;

namespace Proyecto_Catedra_UDB.FormsPaciente
{
    public partial class FrmCitasPaciente : FrmPaciente
    {
        private readonly N_Cita negocio = new N_Cita();

        public FrmCitasPaciente()
        {
            InitializeComponent();

            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;

            btnCitas.BackColor = Color.SteelBlue;
            btnCitas.ForeColor = Color.White;

            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Items.AddRange(new object[]
            {
                "Todos",
                "Pendiente",
                "Atendida",
                "Cancelada"
            });
            cboEstado.SelectedIndex = 0;

            dtpFecha.ShowCheckBox = true;
            dtpFecha.Checked = false;

            Ui.ConfigurarGrid(dgvCitas);

            dgvCitas.CellFormatting += dgvCitas_CellFormatting;

            Cargar();
        }

        private void Cargar()
        {
            try
            {
                string estado = cboEstado.SelectedIndex <= 0
                    ? null
                    : cboEstado.Text;

                DateTime? fecha = dtpFecha.Checked
                    ? (DateTime?)dtpFecha.Value.Date
                    : null;

                dgvCitas.DataSource = negocio.CitasPaciente(
                    Sesion.IdUsuario,
                    estado,
                    fecha
                );

                dgvCitas.Columns["ID_Cita"].Visible = false;

                dgvCitas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvCitas.Columns["Hora"].DefaultCellStyle.Format = @"hh\:mm";

                dgvCitas.Columns["Medico"].HeaderText = "Médico";
                dgvCitas.Columns["NombreEspecialidad"].HeaderText = "Especialidad";

                dgvCitas.ClearSelection();
            }
            catch (Exception ex)
            {
                Ui.Error(ex.Message);
            }
        }

        private void dgvCitas_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object estado = dgvCitas.Rows[e.RowIndex]
                .Cells["Estado"].Value;

            if (estado != null && estado.ToString() == "Cancelada")
            {
                e.CellStyle.ForeColor = Color.Gray;
            }
        }

        private void btnVerCita_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                Ui.Aviso("Seleccione una cita de la tabla.");
                return;
            }

            DataGridViewRow f = dgvCitas.SelectedRows[0];

            int idCita = Convert.ToInt32(
                f.Cells["ID_Cita"].Value
            );

            string detalle =
                "Fecha: " +
                Convert.ToDateTime(f.Cells["Fecha"].Value)
                    .ToString("dd/MM/yyyy") + "\n" +

                "Hora: " +
                ((TimeSpan)f.Cells["Hora"].Value)
                    .ToString(@"hh\:mm") + "\n" +

                "Médico: " +
                f.Cells["Medico"].Value + "\n" +

                "Especialidad: " +
                f.Cells["NombreEspecialidad"].Value + "\n" +

                "Motivo: " +
                f.Cells["Motivo"].Value + "\n" +

                "Estado: " +
                f.Cells["Estado"].Value;

            try
            {
                DataTable receta = negocio.Receta(
                    idCita,
                    Sesion.IdUsuario
                );

                if (receta.Rows.Count > 0)
                {
                    DataRow r = receta.Rows[0];

                    detalle +=
                        "\n\nRECETA\n" +
                        r["Descripcion"] +
                        "\nIndicaciones: " +
                        r["Indicaciones"];
                }
                else
                {
                    detalle += "\n\nSin receta emitida.";
                }
            }
            catch (Exception ex)
            {
                Ui.Error(ex.Message);
                return;
            }

            MessageBox.Show(
                detalle,
                "Detalle de la cita",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                Ui.Aviso("Seleccione una cita de la tabla.");
                return;
            }

            DataGridViewRow f = dgvCitas.SelectedRows[0];

            if (f.Cells["Estado"].Value.ToString() != "Pendiente")
            {
                Ui.Aviso("Solo se pueden cancelar citas pendientes.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Cancelar esta cita? El horario quedará libre.",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r != DialogResult.Yes)
                return;

            try
            {
                negocio.Cancelar(
                    Convert.ToInt32(f.Cells["ID_Cita"].Value),
                    Sesion.IdUsuario
                );

                Ui.Info("Cita cancelada.");

                Cargar();
            }
            catch (Exception ex)
            {
                Ui.Aviso(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}