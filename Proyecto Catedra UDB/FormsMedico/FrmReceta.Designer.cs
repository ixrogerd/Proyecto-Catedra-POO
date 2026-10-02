namespace Proyecto_Catedra_UDB
{
    partial class FrmReceta
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTituloReceta;
        private System.Windows.Forms.GroupBox grpPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;

        private System.Windows.Forms.GroupBox grpMedicamento;
        private System.Windows.Forms.Label lblMedicamento;
        private System.Windows.Forms.TextBox txtMedicamento;
        private System.Windows.Forms.Label lblDosis;
        private System.Windows.Forms.TextBox txtDosis;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.TextBox txtFrecuencia;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label lblIndicaciones;
        private System.Windows.Forms.TextBox txtIndicaciones;

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvMedicamentos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEmitir;
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
            this.lblTituloReceta = new System.Windows.Forms.Label();

            this.grpPaciente = new System.Windows.Forms.GroupBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();

            this.grpMedicamento = new System.Windows.Forms.GroupBox();
            this.lblMedicamento = new System.Windows.Forms.Label();
            this.txtMedicamento = new System.Windows.Forms.TextBox();
            this.lblDosis = new System.Windows.Forms.Label();
            this.txtDosis = new System.Windows.Forms.TextBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.txtFrecuencia = new System.Windows.Forms.TextBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lblIndicaciones = new System.Windows.Forms.Label();
            this.txtIndicaciones = new System.Windows.Forms.TextBox();

            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvMedicamentos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            this.grpPaciente.SuspendLayout();
            this.grpMedicamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).BeginInit();
            this.SuspendLayout();

            // ==============================
            // TÍTULO
            // ==============================
            this.lblTituloReceta.AutoSize = true;
            this.lblTituloReceta.Font = new System.Drawing.Font(
                "Segoe UI", 20F,
                System.Drawing.FontStyle.Bold);

            this.lblTituloReceta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTituloReceta.Location = new System.Drawing.Point(260, 85);
            this.lblTituloReceta.Name = "lblTituloReceta";
            this.lblTituloReceta.Size = new System.Drawing.Size(250, 37);
            this.lblTituloReceta.Text = "EMITIR RECETA";

            // ==============================
            // DATOS DEL PACIENTE
            // ==============================
            this.grpPaciente.Controls.Add(this.lblPaciente);
            this.grpPaciente.Controls.Add(this.txtPaciente);
            this.grpPaciente.Controls.Add(this.lblFecha);
            this.grpPaciente.Controls.Add(this.dtpFecha);

            this.grpPaciente.Font = new System.Drawing.Font(
                "Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.grpPaciente.Location = new System.Drawing.Point(260, 135);
            this.grpPaciente.Name = "grpPaciente";
            this.grpPaciente.Size = new System.Drawing.Size(790, 80);
            this.grpPaciente.Text = "DATOS DEL PACIENTE";

            // Paciente
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(20, 35);
            this.lblPaciente.Text = "Paciente:";

            this.txtPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPaciente.Location = new System.Drawing.Point(95, 32);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(400, 23);

            // Fecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(525, 35);
            this.lblFecha.Text = "Fecha:";

            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(580, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(165, 23);

            // ==============================
            // MEDICAMENTO
            // ==============================
            this.grpMedicamento.Controls.Add(this.lblMedicamento);
            this.grpMedicamento.Controls.Add(this.txtMedicamento);
            this.grpMedicamento.Controls.Add(this.lblDosis);
            this.grpMedicamento.Controls.Add(this.txtDosis);
            this.grpMedicamento.Controls.Add(this.lblFrecuencia);
            this.grpMedicamento.Controls.Add(this.txtFrecuencia);
            this.grpMedicamento.Controls.Add(this.lblDuracion);
            this.grpMedicamento.Controls.Add(this.txtDuracion);
            this.grpMedicamento.Controls.Add(this.lblIndicaciones);
            this.grpMedicamento.Controls.Add(this.txtIndicaciones);
            this.grpMedicamento.Controls.Add(this.btnAgregar);

            this.grpMedicamento.Font = new System.Drawing.Font(
                "Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.grpMedicamento.Location = new System.Drawing.Point(260, 230);
            this.grpMedicamento.Name = "grpMedicamento";
            this.grpMedicamento.Size = new System.Drawing.Size(790, 175);
            this.grpMedicamento.Text = "MEDICAMENTO";

            // Medicamento
            this.lblMedicamento.AutoSize = true;
            this.lblMedicamento.Location = new System.Drawing.Point(20, 32);
            this.lblMedicamento.Text = "Medicamento:";

            this.txtMedicamento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedicamento.Location = new System.Drawing.Point(120, 29);
            this.txtMedicamento.Name = "txtMedicamento";
            this.txtMedicamento.Size = new System.Drawing.Size(270, 23);

            // Dosis
            this.lblDosis.AutoSize = true;
            this.lblDosis.Location = new System.Drawing.Point(420, 32);
            this.lblDosis.Text = "Dosis:";

            this.txtDosis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDosis.Location = new System.Drawing.Point(475, 29);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(270, 23);

            // Frecuencia
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Location = new System.Drawing.Point(20, 70);
            this.lblFrecuencia.Text = "Frecuencia:";

            this.txtFrecuencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFrecuencia.Location = new System.Drawing.Point(120, 67);
            this.txtFrecuencia.Name = "txtFrecuencia";
            this.txtFrecuencia.Size = new System.Drawing.Size(270, 23);

            // Duración
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(420, 70);
            this.lblDuracion.Text = "Duración:";

            this.txtDuracion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDuracion.Location = new System.Drawing.Point(475, 67);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(270, 23);

            // Indicaciones
            this.lblIndicaciones.AutoSize = true;
            this.lblIndicaciones.Location = new System.Drawing.Point(20, 108);
            this.lblIndicaciones.Text = "Indicaciones:";

            this.txtIndicaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIndicaciones.Location = new System.Drawing.Point(120, 105);
            this.txtIndicaciones.Multiline = true;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(470, 45);

            // Agregar
            this.btnAgregar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font(
                "Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(610, 110);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 35);
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // ==============================
            // TABLA
            // ==============================
            this.dgvMedicamentos.AllowUserToAddRows = false;
            this.dgvMedicamentos.AllowUserToDeleteRows = false;
            this.dgvMedicamentos.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvMedicamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicamentos.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvMedicamentos.Location = new System.Drawing.Point(260, 420);
            this.dgvMedicamentos.MultiSelect = false;
            this.dgvMedicamentos.Name = "dgvMedicamentos";
            this.dgvMedicamentos.ReadOnly = true;
            this.dgvMedicamentos.RowHeadersVisible = false;
            this.dgvMedicamentos.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvMedicamentos.Size = new System.Drawing.Size(790, 135);

            // ==============================
            // ELIMINAR
            // ==============================
            this.btnEliminar.BackColor = System.Drawing.Color.LightGray;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font(
                "Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.btnEliminar.Location = new System.Drawing.Point(260, 570);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 38);
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ==============================
            // LIMPIAR
            // ==============================
            this.btnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font(
                "Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.btnLimpiar.Location = new System.Drawing.Point(735, 570);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 38);
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // ==============================
            // EMITIR RECETA
            // ==============================
            this.btnEmitir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEmitir.FlatAppearance.BorderSize = 0;
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitir.Font = new System.Drawing.Font(
                "Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.btnEmitir.ForeColor = System.Drawing.Color.White;
            this.btnEmitir.Location = new System.Drawing.Point(880, 570);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(170, 38);
            this.btnEmitir.Text = "EMITIR RECETA";
            this.btnEmitir.UseVisualStyleBackColor = false;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);

            // ==============================
            // FORMULARIO
            // ==============================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);

            this.Controls.Add(this.lblTituloReceta);
            this.Controls.Add(this.grpPaciente);
            this.Controls.Add(this.grpMedicamento);
            this.Controls.Add(this.dgvMedicamentos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEmitir);

            this.Name = "FrmReceta";
            this.Text = "Emitir Receta";

            this.grpPaciente.ResumeLayout(false);
            this.grpPaciente.PerformLayout();

            this.grpMedicamento.ResumeLayout(false);
            this.grpMedicamento.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}