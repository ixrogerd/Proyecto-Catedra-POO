using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Proyecto_Catedra_UDB.Plantilla
{
    internal static class Ui
    {
        private static readonly Color Acento = Color.FromArgb(16, 163, 127);
        private static readonly Color FondoSuave = Color.FromArgb(247, 247, 248);
        private static readonly Color Texto = Color.FromArgb(52, 53, 65);
        private static readonly Color Fondo = Color.White;
        private static readonly Font FuenteBase = new Font("Segoe UI", 9F, FontStyle.Regular);
        private static readonly Font FuenteBoton = new Font("Segoe UI", 9F, FontStyle.Bold);

        public static void AplicarTema(Form formulario)
        {
            formulario.BackColor = Fondo;
            formulario.Font = FuenteBase;
            Control encabezado = formulario.Controls["pnlSuperior"];
            Control menu = formulario.Controls["pnlMenu"];
            if (encabezado != null) encabezado.BackColor = Fondo;
            if (menu != null) menu.BackColor = FondoSuave;
            AplicarTemaControles(formulario.Controls);
        }

        private static void AplicarTemaControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control.Name == "pnlSuperior") control.BackColor = Fondo;
                if (control.Name == "pnlMenu") control.BackColor = FondoSuave;

                if (control is Button boton)
                {
                    if (boton.BackColor == Color.Transparent) continue;
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.Font = FuenteBoton;
                    boton.UseVisualStyleBackColor = false;
                    if (boton.Parent != null && boton.Parent.Name == "pnlMenu")
                    {
                        bool seleccionado = boton.BackColor == Color.LightBlue;
                        boton.BackColor = boton.Name == "btnCerrarSesion" ? Fondo :
                            seleccionado ? Acento : FondoSuave;
                        boton.ForeColor = seleccionado ? Fondo : Texto;
                    }
                    else if (boton.Enabled)
                    {
                        boton.BackColor = Acento;
                        boton.ForeColor = Fondo;
                    }
                    else
                    {
                        boton.BackColor = Color.LightGray;
                        boton.ForeColor = Color.DimGray;
                    }
                }
                else if (control is TextBox || control is MaskedTextBox || control is ComboBox ||
                         control is DateTimePicker || control is NumericUpDown)
                {
                    control.Font = FuenteBase;
                    control.BackColor = Fondo;
                    control.ForeColor = Texto;
                }
                else if (control is Label etiqueta)
                {
                    etiqueta.Font = new Font(FuenteBase.FontFamily, etiqueta.Font.Size,
                        etiqueta.Font.Bold ? FontStyle.Bold : FontStyle.Regular);
                    if (etiqueta.Font.Size >= 16F &&
                        (etiqueta.Parent == null || etiqueta.Parent.Name != "pnlSuperior"))
                        etiqueta.ForeColor = Texto;
                    if (etiqueta.Parent != null && etiqueta.Parent.Name == "pnlSuperior")
                        etiqueta.ForeColor = Texto;
                }
                else if (control is GroupBox grupo)
                {
                    grupo.Font = FuenteBoton;
                    grupo.ForeColor = Texto;
                }
                else if (control is DataGridView tabla)
                {
                    ConfigurarGrid(tabla);
                    tabla.Font = FuenteBase;
                    tabla.ColumnHeadersDefaultCellStyle.BackColor = FondoSuave;
                    tabla.ColumnHeadersDefaultCellStyle.ForeColor = Texto;
                    tabla.EnableHeadersVisualStyles = false;
                    tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                    tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 242, 235);
                    tabla.DefaultCellStyle.SelectionForeColor = Texto;
                }

                if (control.HasChildren) AplicarTemaControles(control.Controls);
            }
        }

        public static void ConfigurarGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = FondoSuave;
        }

        public static void Info(string m)
        { MessageBox.Show(m, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        public static void Aviso(string m)
        { MessageBox.Show(m, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        public static void Error(string m)
        { MessageBox.Show(m, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public static int IdSeleccionado(ComboBox cb)
        {
            return cb.SelectedValue is int ? (int)cb.SelectedValue : 0;
        }
    }
}
