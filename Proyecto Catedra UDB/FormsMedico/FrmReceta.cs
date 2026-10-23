using System;
using System.Drawing;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.Plantilla;
using System.Collections.Generic;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmReceta : FrmMedico
    {
        private readonly N_Cita negCita = new N_Cita();
        private readonly N_Receta negocio = new N_Receta();

        public FrmReceta()
        {
            InitializeComponent();

            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnReceta.BackColor = Color.SteelBlue;
            btnReceta.ForeColor = Color.White;

            txtMedicamento.MaxLength = 100;
            txtDosis.MaxLength = 50;
            txtFrecuencia.MaxLength = 50;
            txtDuracion.MaxLength = 50;
            txtIndicaciones.MaxLength = 150;

            dtpFecha.Enabled = false;          // la fecha de emisión la registra la BD
            dtpFecha.Value = DateTime.Today;

            cboCita.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCita.DisplayMember = "Texto";
            cboCita.ValueMember = "ID_Cita";

            Ui.ConfigurarGrid(dgvMedicamentos);
            ConfigurarTabla();
            CargarCitas();
        }

        private void ConfigurarTabla()
        {
            dgvMedicamentos.Columns.Clear();
            dgvMedicamentos.Columns.Add("Medicamento", "Medicamento");
            dgvMedicamentos.Columns.Add("Dosis", "Dosis");
            dgvMedicamentos.Columns.Add("Frecuencia", "Frecuencia");
            dgvMedicamentos.Columns.Add("Duracion", "Duración");
            dgvMedicamentos.Columns.Add("Indicaciones", "Indicaciones");
        }

        // Solo citas atendidas que todavía no tienen receta
        private void CargarCitas()
        {
            try { cboCita.DataSource = negCita.CitasParaReceta(Sesion.IdUsuario); }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            E_Medicamento m = new E_Medicamento
            {
                Medicamento = txtMedicamento.Text.Trim(),
                Dosis = txtDosis.Text.Trim(),
                Frecuencia = txtFrecuencia.Text.Trim(),
                Duracion = txtDuracion.Text.Trim(),
                Indicaciones = txtIndicaciones.Text.Trim()
            };

            try { negocio.ValidarMedicamento(m); }
            catch (Exception ex) { Ui.Aviso(ex.Message); return; }

            dgvMedicamentos.Rows.Add(m.Medicamento, m.Dosis, m.Frecuencia, m.Duracion, m.Indicaciones);
            LimpiarMedicamento();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 0)
            {
                Ui.Aviso("Seleccione un medicamento de la tabla.");
                return;
            }
            dgvMedicamentos.Rows.Remove(dgvMedicamentos.SelectedRows[0]);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvMedicamentos.Rows.Clear();
            LimpiarMedicamento();
            CargarCitas();
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            int idCita = Ui.IdSeleccionado(cboCita);
            if (idCita == 0)
            {
                Ui.Aviso("Seleccione la cita de la receta (solo aparecen citas atendidas sin receta).");
                return;
            }

            List<E_Medicamento> lista = new List<E_Medicamento>();
            foreach (DataGridViewRow f in dgvMedicamentos.Rows)
            {
                lista.Add(new E_Medicamento
                {
                    Medicamento = Convert.ToString(f.Cells["Medicamento"].Value),
                    Dosis = Convert.ToString(f.Cells["Dosis"].Value),
                    Frecuencia = Convert.ToString(f.Cells["Frecuencia"].Value),
                    Duracion = Convert.ToString(f.Cells["Duracion"].Value),
                    Indicaciones = Convert.ToString(f.Cells["Indicaciones"].Value)
                });
            }

            try
            {
                negocio.Emitir(idCita, Sesion.IdUsuario, lista);
                Ui.Info("Receta emitida correctamente.");
                dgvMedicamentos.Rows.Clear();
                LimpiarMedicamento();
                CargarCitas();   // la cita ya no aparece: tiene receta
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
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