namespace Proyecto_Catedra_UDB
{
    partial class FrmReceta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpPaciente;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpPaciente = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCita = new System.Windows.Forms.ComboBox();
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
            this.pnlMenu.SuspendLayout();
            this.grpPaciente.SuspendLayout();
            this.grpMedicamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCitas
            // 
            this.btnCitas.FlatAppearance.BorderSize = 0;
            // 
            // btnAtender
            // 
            this.btnAtender.FlatAppearance.BorderSize = 0;
            // 
            // btnReceta
            // 
            this.btnReceta.FlatAppearance.BorderSize = 0;
            // 
            // btnHorarios
            // 
            this.btnHorarios.FlatAppearance.BorderSize = 0;
            // 
            // btnInicio
            // 
            this.btnInicio.FlatAppearance.BorderSize = 0;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(289, 50);
            this.lblTitulo.Text = "EMITIR RECETA";
            // 
            // grpPaciente
            // 
            this.grpPaciente.Controls.Add(this.label1);
            this.grpPaciente.Controls.Add(this.cboCita);
            this.grpPaciente.Controls.Add(this.lblFecha);
            this.grpPaciente.Controls.Add(this.dtpFecha);
            this.grpPaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPaciente.Location = new System.Drawing.Point(260, 135);
            this.grpPaciente.Name = "grpPaciente";
            this.grpPaciente.Size = new System.Drawing.Size(790, 80);
            this.grpPaciente.TabIndex = 20;
            this.grpPaciente.TabStop = false;
            this.grpPaciente.Text = "DATOS DE LA CITA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cita:";
            // 
            // cboCita
            // 
            this.cboCita.FormattingEnabled = true;
            this.cboCita.Location = new System.Drawing.Point(78, 32);
            this.cboCita.Name = "cboCita";
            this.cboCita.Size = new System.Drawing.Size(169, 23);
            this.cboCita.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(525, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(42, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(580, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(165, 23);
            this.dtpFecha.TabIndex = 3;
            // 
            // grpMedicamento
            // 
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
            this.grpMedicamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpMedicamento.Location = new System.Drawing.Point(260, 230);
            this.grpMedicamento.Name = "grpMedicamento";
            this.grpMedicamento.Size = new System.Drawing.Size(790, 175);
            this.grpMedicamento.TabIndex = 21;
            this.grpMedicamento.TabStop = false;
            this.grpMedicamento.Text = "MEDICAMENTO";
            // 
            // lblMedicamento
            // 
            this.lblMedicamento.AutoSize = true;
            this.lblMedicamento.Location = new System.Drawing.Point(20, 32);
            this.lblMedicamento.Name = "lblMedicamento";
            this.lblMedicamento.Size = new System.Drawing.Size(87, 15);
            this.lblMedicamento.TabIndex = 0;
            this.lblMedicamento.Text = "Medicamento:";
            // 
            // txtMedicamento
            // 
            this.txtMedicamento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedicamento.Location = new System.Drawing.Point(120, 29);
            this.txtMedicamento.Name = "txtMedicamento";
            this.txtMedicamento.Size = new System.Drawing.Size(270, 23);
            this.txtMedicamento.TabIndex = 1;
            // 
            // lblDosis
            // 
            this.lblDosis.AutoSize = true;
            this.lblDosis.Location = new System.Drawing.Point(420, 32);
            this.lblDosis.Name = "lblDosis";
            this.lblDosis.Size = new System.Drawing.Size(39, 15);
            this.lblDosis.TabIndex = 2;
            this.lblDosis.Text = "Dosis:";
            // 
            // txtDosis
            // 
            this.txtDosis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDosis.Location = new System.Drawing.Point(475, 29);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(270, 23);
            this.txtDosis.TabIndex = 3;
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Location = new System.Drawing.Point(20, 70);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(70, 15);
            this.lblFrecuencia.TabIndex = 4;
            this.lblFrecuencia.Text = "Frecuencia:";
            // 
            // txtFrecuencia
            // 
            this.txtFrecuencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFrecuencia.Location = new System.Drawing.Point(120, 67);
            this.txtFrecuencia.Name = "txtFrecuencia";
            this.txtFrecuencia.Size = new System.Drawing.Size(270, 23);
            this.txtFrecuencia.TabIndex = 5;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(420, 70);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(60, 15);
            this.lblDuracion.TabIndex = 6;
            this.lblDuracion.Text = "Duración:";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDuracion.Location = new System.Drawing.Point(475, 67);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(270, 23);
            this.txtDuracion.TabIndex = 7;
            // 
            // lblIndicaciones
            // 
            this.lblIndicaciones.AutoSize = true;
            this.lblIndicaciones.Location = new System.Drawing.Point(20, 108);
            this.lblIndicaciones.Name = "lblIndicaciones";
            this.lblIndicaciones.Size = new System.Drawing.Size(78, 15);
            this.lblIndicaciones.TabIndex = 8;
            this.lblIndicaciones.Text = "Indicaciones:";
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIndicaciones.Location = new System.Drawing.Point(120, 105);
            this.txtIndicaciones.Multiline = true;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(470, 45);
            this.txtIndicaciones.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(610, 110);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 35);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvMedicamentos
            // 
            this.dgvMedicamentos.AllowUserToAddRows = false;
            this.dgvMedicamentos.AllowUserToDeleteRows = false;
            this.dgvMedicamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicamentos.Location = new System.Drawing.Point(260, 420);
            this.dgvMedicamentos.MultiSelect = false;
            this.dgvMedicamentos.Name = "dgvMedicamentos";
            this.dgvMedicamentos.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicamentos.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicamentos.RowHeadersVisible = false;
            this.dgvMedicamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicamentos.Size = new System.Drawing.Size(790, 135);
            this.dgvMedicamentos.TabIndex = 22;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightGray;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(260, 570);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 38);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEmitir
            // 
            this.btnEmitir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEmitir.FlatAppearance.BorderSize = 0;
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEmitir.ForeColor = System.Drawing.Color.White;
            this.btnEmitir.Location = new System.Drawing.Point(880, 570);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(170, 38);
            this.btnEmitir.TabIndex = 25;
            this.btnEmitir.Text = "EMITIR RECETA";
            this.btnEmitir.UseVisualStyleBackColor = false;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(735, 570);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 38);
            this.btnLimpiar.TabIndex = 24;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.grpPaciente);
            this.Controls.Add(this.grpMedicamento);
            this.Controls.Add(this.dgvMedicamentos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEmitir);
            this.Name = "FrmReceta";
            this.Text = "Emitir Receta";
            this.Controls.SetChildIndex(this.btnEmitir, 0);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.dgvMedicamentos, 0);
            this.Controls.SetChildIndex(this.grpMedicamento, 0);
            this.Controls.SetChildIndex(this.grpPaciente, 0);
            this.Controls.SetChildIndex(this.pnlMenu, 0);
            this.Controls.SetChildIndex(this.pnlSuperior, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.grpPaciente.ResumeLayout(false);
            this.grpPaciente.PerformLayout();
            this.grpMedicamento.ResumeLayout(false);
            this.grpMedicamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCita;
    }
}