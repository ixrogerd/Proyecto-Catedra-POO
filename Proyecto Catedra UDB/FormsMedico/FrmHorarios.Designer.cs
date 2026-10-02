namespace Proyecto_Catedra_UDB
{
    partial class FrmHorarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTituloHorarios;

        private System.Windows.Forms.GroupBox grpHorario;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.ComboBox cmbDia;

        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;

        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;

        private System.Windows.Forms.Button btnAgregarHorario;

        private System.Windows.Forms.DataGridView dgvHorarios;

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTituloHorarios = new System.Windows.Forms.Label();

            this.grpHorario = new System.Windows.Forms.GroupBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.cmbDia = new System.Windows.Forms.ComboBox();

            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();

            this.lblHoraFin = new System.Windows.Forms.Label();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();

            this.btnAgregarHorario = new System.Windows.Forms.Button();

            this.dgvHorarios = new System.Windows.Forms.DataGridView();

            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            this.grpHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.SuspendLayout();

            // =========================================
            // TÍTULO
            // =========================================

            this.lblTituloHorarios.AutoSize = true;
            this.lblTituloHorarios.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold);

            this.lblTituloHorarios.ForeColor =
                System.Drawing.Color.SteelBlue;

            this.lblTituloHorarios.Location =
                new System.Drawing.Point(260, 90);

            this.lblTituloHorarios.Name =
                "lblTituloHorarios";

            this.lblTituloHorarios.Size =
                new System.Drawing.Size(330, 37);

            this.lblTituloHorarios.Text =
                "GESTIÓN DE HORARIOS";


            // =========================================
            // GROUPBOX HORARIO
            // =========================================

            this.grpHorario.Controls.Add(this.lblDia);
            this.grpHorario.Controls.Add(this.cmbDia);

            this.grpHorario.Controls.Add(this.lblHoraInicio);
            this.grpHorario.Controls.Add(this.dtpHoraInicio);

            this.grpHorario.Controls.Add(this.lblHoraFin);
            this.grpHorario.Controls.Add(this.dtpHoraFin);

            this.grpHorario.Controls.Add(this.btnAgregarHorario);

            this.grpHorario.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold);

            this.grpHorario.Location =
                new System.Drawing.Point(260, 150);

            this.grpHorario.Name =
                "grpHorario";

            this.grpHorario.Size =
                new System.Drawing.Size(790, 150);

            this.grpHorario.Text =
                "NUEVO HORARIO";


            // =========================================
            // DÍA
            // =========================================

            this.lblDia.AutoSize = true;

            this.lblDia.Location =
                new System.Drawing.Point(25, 40);

            this.lblDia.Text =
                "Día:";


            this.cmbDia.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbDia.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.cmbDia.FormattingEnabled = true;

            this.cmbDia.Items.AddRange(
                new object[]
                {
                    "Lunes",
                    "Martes",
                    "Miércoles",
                    "Jueves",
                    "Viernes",
                    "Sábado",
                    "Domingo"
                });

            this.cmbDia.Location =
                new System.Drawing.Point(105, 36);

            this.cmbDia.Name =
                "cmbDia";

            this.cmbDia.Size =
                new System.Drawing.Size(200, 23);


            // =========================================
            // HORA INICIO
            // =========================================

            this.lblHoraInicio.AutoSize = true;

            this.lblHoraInicio.Location =
                new System.Drawing.Point(350, 40);

            this.lblHoraInicio.Text =
                "Hora inicio:";


            this.dtpHoraInicio.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.dtpHoraInicio.Format =
                System.Windows.Forms.DateTimePickerFormat.Time;

            this.dtpHoraInicio.ShowUpDown = true;

            this.dtpHoraInicio.Location =
                new System.Drawing.Point(440, 36);

            this.dtpHoraInicio.Name =
                "dtpHoraInicio";

            this.dtpHoraInicio.Size =
                new System.Drawing.Size(130, 23);


            // =========================================
            // HORA FIN
            // =========================================

            this.lblHoraFin.AutoSize = true;

            this.lblHoraFin.Location =
                new System.Drawing.Point(25, 90);

            this.lblHoraFin.Text =
                "Hora fin:";


            this.dtpHoraFin.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.dtpHoraFin.Format =
                System.Windows.Forms.DateTimePickerFormat.Time;

            this.dtpHoraFin.ShowUpDown = true;

            this.dtpHoraFin.Location =
                new System.Drawing.Point(105, 86);

            this.dtpHoraFin.Name =
                "dtpHoraFin";

            this.dtpHoraFin.Size =
                new System.Drawing.Size(200, 23);


            // =========================================
            // AGREGAR HORARIO
            // =========================================

            this.btnAgregarHorario.BackColor =
                System.Drawing.Color.SteelBlue;

            this.btnAgregarHorario.FlatAppearance.BorderSize = 0;

            this.btnAgregarHorario.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAgregarHorario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnAgregarHorario.ForeColor =
                System.Drawing.Color.White;

            this.btnAgregarHorario.Location =
                new System.Drawing.Point(440, 82);

            this.btnAgregarHorario.Name =
                "btnAgregarHorario";

            this.btnAgregarHorario.Size =
                new System.Drawing.Size(180, 35);

            this.btnAgregarHorario.Text =
                "AGREGAR HORARIO";

            this.btnAgregarHorario.UseVisualStyleBackColor = false;

            this.btnAgregarHorario.Click +=
                new System.EventHandler(this.btnAgregarHorario_Click);


            // =========================================
            // DATAGRIDVIEW
            // =========================================

            this.dgvHorarios.AllowUserToAddRows = false;
            this.dgvHorarios.AllowUserToDeleteRows = false;

            this.dgvHorarios.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvHorarios.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvHorarios.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvHorarios.Location =
                new System.Drawing.Point(260, 320);

            this.dgvHorarios.MultiSelect = false;

            this.dgvHorarios.Name =
                "dgvHorarios";

            this.dgvHorarios.ReadOnly = true;

            this.dgvHorarios.RowHeadersVisible = false;

            this.dgvHorarios.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvHorarios.Size =
                new System.Drawing.Size(790, 220);


            // =========================================
            // ELIMINAR
            // =========================================

            this.btnEliminar.BackColor =
                System.Drawing.Color.LightGray;

            this.btnEliminar.FlatAppearance.BorderSize = 0;

            this.btnEliminar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEliminar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnEliminar.Location =
                new System.Drawing.Point(260, 565);

            this.btnEliminar.Name =
                "btnEliminar";

            this.btnEliminar.Size =
                new System.Drawing.Size(130, 38);

            this.btnEliminar.Text =
                "ELIMINAR";

            this.btnEliminar.UseVisualStyleBackColor = false;

            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);


            // =========================================
            // LIMPIAR
            // =========================================

            this.btnLimpiar.BackColor =
                System.Drawing.Color.LightBlue;

            this.btnLimpiar.FlatAppearance.BorderSize = 0;

            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnLimpiar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnLimpiar.Location =
                new System.Drawing.Point(735, 565);

            this.btnLimpiar.Name =
                "btnLimpiar";

            this.btnLimpiar.Size =
                new System.Drawing.Size(130, 38);

            this.btnLimpiar.Text =
                "LIMPIAR";

            this.btnLimpiar.UseVisualStyleBackColor = false;

            this.btnLimpiar.Click +=
                new System.EventHandler(this.btnLimpiar_Click);


            // =========================================
            // GUARDAR
            // =========================================

            this.btnGuardar.BackColor =
                System.Drawing.Color.SteelBlue;

            this.btnGuardar.FlatAppearance.BorderSize = 0;

            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnGuardar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;

            this.btnGuardar.Location =
                new System.Drawing.Point(880, 565);

            this.btnGuardar.Name =
                "btnGuardar";

            this.btnGuardar.Size =
                new System.Drawing.Size(170, 38);

            this.btnGuardar.Text =
                "GUARDAR HORARIOS";

            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);


            // =========================================
            // FORMULARIO
            // =========================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1100, 700);

            this.Controls.Add(this.lblTituloHorarios);
            this.Controls.Add(this.grpHorario);
            this.Controls.Add(this.dgvHorarios);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);

            this.Name = "FrmHorarios";
            this.Text = "Horarios";

            this.grpHorario.ResumeLayout(false);
            this.grpHorario.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvHorarios)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}