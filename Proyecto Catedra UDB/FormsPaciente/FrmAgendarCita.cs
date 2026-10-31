using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using Proyecto_Catedra_UDB.FormsPaciente;
using Proyecto_Catedra_UDB.Plantilla;

namespace Proyecto_Catedra_UDB
{
    public partial class FrmAgendarCita : FrmPaciente
    {
        private readonly N_Especialidad negEspecialidad = new N_Especialidad();
        private readonly N_Medico negMedico = new N_Medico();
        private readonly N_Cita negCita = new N_Cita();
        private bool cargando = false;
        public FrmAgendarCita()
        {
            InitializeComponent();
            btnInicio.BackColor = Color.LightBlue;
            btnInicio.ForeColor = Color.Black;
            btnAgendarCita.BackColor = Color.SteelBlue;
            btnAgendarCita.ForeColor = Color.White;

            txtMotivo.MaxLength = 200;
            dtpFecha.MinDate = DateTime.Today;

            cbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEspecialidad.DisplayMember = "NombreEspecialidad";
            cbEspecialidad.ValueMember = "ID_Especialidad";
            cbMedico.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMedico.DisplayMember = "NombreCompleto";
            cbMedico.ValueMember = "ID_Medico";
            cbHora.DropDownStyle = ComboBoxStyle.DropDownList;

            try { cbEspecialidad.DataSource = negEspecialidad.Listar(); }
            catch (Exception ex) { Ui.Error(ex.Message); }

            cbEspecialidad.SelectedIndexChanged += (s, e) => CargarMedicos();
            cbMedico.SelectedIndexChanged += (s, e) => CargarHoras();
            dtpFecha.ValueChanged += (s, e) => CargarHoras();

            CargarMedicos();
        }
        private void CargarMedicos()
        {
            cargando = true;
            try
            {
                cbMedico.DataSource = negMedico.PorEspecialidad(Ui.IdSeleccionado(cbEspecialidad));
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
            finally { cargando = false; }
            CargarHoras();
        }

        private void CargarHoras()
        {
            if (cargando) return;
            cbHora.Items.Clear();
            try
            {
                foreach (TimeSpan h in negCita.HorasLibres(Ui.IdSeleccionado(cbMedico), dtpFecha.Value.Date))
                    cbHora.Items.Add(h.ToString(@"hh\:mm"));

                if (cbHora.Items.Count > 0)
                {
                    cbHora.SelectedIndex = 0;
                    lblInfo.Text = "";
                }
                else
                    lblInfo.Text = "Sin horas disponibles para ese día.";
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }


        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (Ui.IdSeleccionado(cbMedico) == 0)
            {
                Ui.Aviso("Seleccione un médico.");
                return;
            }
            if (cbHora.SelectedItem == null)
            {
                Ui.Aviso("Seleccione una hora disponible.");
                return;
            }

            try
            {
                negCita.Agendar(new E_Cita
                {
                    IdPaciente = Sesion.IdUsuario,
                    IdMedico = Ui.IdSeleccionado(cbMedico),
                    Fecha = dtpFecha.Value.Date,
                    Hora = TimeSpan.Parse(cbHora.SelectedItem.ToString()),
                    Motivo = txtMotivo.Text.Trim()
                });
                Ui.Info("Cita agendada correctamente.");
                txtMotivo.Clear();
                CargarHoras();   // la hora tomada desaparece de la lista
            }
            catch (Exception ex) { Ui.Aviso(ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMotivo.Clear();
            dtpFecha.Value = DateTime.Today;
            if (cbEspecialidad.Items.Count > 0) cbEspecialidad.SelectedIndex = 0;
            CargarMedicos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            new FrmInicioPaciente().Show();
            Hide();
        }
    }
}
