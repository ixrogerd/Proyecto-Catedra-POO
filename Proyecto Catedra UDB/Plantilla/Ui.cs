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
        private static readonly Color AzulPrincipal = Color.FromArgb(31, 78, 121);
        private static readonly Color AzulMenu = Color.FromArgb(225, 237, 247);
        private static readonly Color Fondo = Color.FromArgb(247, 249, 252);
        private static readonly Color Texto = Color.FromArgb(39, 52, 66);

        public static void AplicarTema(Form formulario)
        {
            formulario.BackColor = Fondo;
            formulario.Font = new Font("Segoe UI", 9.75F);
            AplicarTemaControles(formulario.Controls);
        }

        private static void AplicarTemaControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                Panel panel = control as Panel;
                if (panel != null)
                {
                    if (panel.Name == "pnlMenu") panel.BackColor = AzulMenu;
                    else if (panel.Name == "pnlSuperior") panel.BackColor = AzulPrincipal;
                    else panel.BackColor = Color.White;
                }

                Label etiqueta = control as Label;
                if (etiqueta != null)
                {
                    etiqueta.ForeColor = etiqueta.Parent != null && etiqueta.Parent.Name == "pnlSuperior"
                        ? Color.White : Texto;
                }

                Button boton = control as Button;
                if (boton != null)
                {
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 96, 143);
                    boton.BackColor = boton.Name.IndexOf("Cerrar", StringComparison.OrdinalIgnoreCase) >= 0
                        ? Color.FromArgb(183, 71, 71) : AzulPrincipal;
                    boton.ForeColor = Color.White;
                    boton.Cursor = Cursors.Hand;
                }

                DataGridView grid = control as DataGridView;
                if (grid != null)
                {
                    ConfigurarGrid(grid);
                    grid.EnableHeadersVisualStyles = false;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = AzulPrincipal;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.75F);
                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 231, 245);
                    grid.DefaultCellStyle.SelectionForeColor = Texto;
                    grid.GridColor = Color.FromArgb(222, 229, 236);
                }

                TextBox caja = control as TextBox;
                if (caja != null)
                {
                    caja.Font = new Font("Segoe UI", 10F);
                    caja.BackColor = Color.White;
                    caja.ForeColor = Texto;
                }

                ComboBox lista = control as ComboBox;
                if (lista != null)
                {
                    lista.Font = new Font("Segoe UI", 10F);
                    lista.BackColor = Color.White;
                    lista.ForeColor = Texto;
                }

                if (control.HasChildren)
                {
                    AplicarTemaControles(control.Controls);
                }
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
