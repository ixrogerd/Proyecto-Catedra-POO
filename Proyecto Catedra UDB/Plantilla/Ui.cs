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
