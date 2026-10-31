using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmDisponibilidad : FrmPaciente
    {
        private readonly N_Especialidad negEspecialidad = new N_Especialidad();
        private readonly N_Medico negMedico = new N_Medico();
        private readonly N_Cita negCita = new N_Cita();

        private bool cargando = false;

        public FrmDisponibilidad()
        {
            InitializeComponent();

            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;

            btnDisponibilidad.BackColor = Color.SteelBlue;
            btnDisponibilidad.ForeColor = Color.White;

            Ui.ConfigurarGrid(dataGridView1);

            dtpFecha.MinDate = DateTime.Today;

            cbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEspecialidad.DisplayMember = "NombreEspecialidad";
            cbEspecialidad.ValueMember = "ID_Especialidad";

            cbMedico.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMedico.DisplayMember = "NombreCompleto";
            cbMedico.ValueMember = "ID_Medico";

            try
            {
                cbEspecialidad.DataSource = negEspecialidad.Listar();
            }
            catch (Exception ex)
            {
                Ui.Error(ex.Message);
            }

            cbEspecialidad.SelectedIndexChanged +=
                (s, e) => CargarMedicos();

            cbMedico.SelectedIndexChanged +=
                (s, e) => Consultar();

            dtpFecha.ValueChanged +=
                (s, e) => Consultar();

            dataGridView1.CellFormatting +=
                dataGridView1_CellFormatting;

            CargarMedicos();
        }

        private void CargarMedicos()
        {
            cargando = true;

            try
            {
                cbMedico.DataSource = negMedico.PorEspecialidad(
                    Ui.IdSeleccionado(cbEspecialidad)
                );
            }
            catch (Exception ex)
            {
                Ui.Error(ex.Message);
            }
            finally
            {
                cargando = false;
            }

            Consultar();
        }

        private void Consultar()
        {
            if (cargando)
                return;

            try
            {
                int idMedico = Ui.IdSeleccionado(cbMedico);

                DataTable dt = negCita.Disponibilidad(
                    idMedico,
                    dtpFecha.Value.Date
                );

                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();

                if (idMedico == 0)
                {
                    lblInfo.Text = "No hay médicos en esta especialidad.";
                }
                else if (dt.Rows.Count == 0)
                {
                    lblInfo.Text =
                        "El médico no atiende ese día o ya no quedan horas.";
                }
                else
                {
                    lblInfo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Ui.Error(ex.Message);
            }
        }

        private void dataGridView1_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dataGridView1.Columns[e.ColumnIndex].Name != "Estado")
                return;

            e.CellStyle.ForeColor =
                Convert.ToString(e.Value) == "Ocupada"
                ? Color.Gray
                : Color.SeaGreen;
        }

        private void FrmDisponibilidad_Load(object sender, EventArgs e)
        {
        }
    }
}