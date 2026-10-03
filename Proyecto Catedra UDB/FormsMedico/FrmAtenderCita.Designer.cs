namespace Proyecto_Catedra_UDB
{
    partial class FrmAtenderCita
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpDatosCita;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;

        private System.Windows.Forms.GroupBox grpConsulta;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTratamiento;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;

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
            this.grpDatosCita = new System.Windows.Forms.GroupBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.grpConsulta = new System.Windows.Forms.GroupBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblTratamiento = new System.Windows.Forms.Label();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.grpDatosCita.SuspendLayout();
            this.grpConsulta.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(277, 50);
            this.lblTitulo.Text = "ATENDER CITA";
            // 
            // grpDatosCita
            // 
            this.grpDatosCita.Controls.Add(this.lblPaciente);
            this.grpDatosCita.Controls.Add(this.txtPaciente);
            this.grpDatosCita.Controls.Add(this.lblFecha);
            this.grpDatosCita.Controls.Add(this.dtpFecha);
            this.grpDatosCita.Controls.Add(this.lblHora);
            this.grpDatosCita.Controls.Add(this.txtHora);
            this.grpDatosCita.Controls.Add(this.lblMotivo);
            this.grpDatosCita.Controls.Add(this.txtMotivo);
            this.grpDatosCita.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDatosCita.Location = new System.Drawing.Point(260, 140);
            this.grpDatosCita.Name = "grpDatosCita";
            this.grpDatosCita.Size = new System.Drawing.Size(790, 145);
            this.grpDatosCita.TabIndex = 20;
            this.grpDatosCita.TabStop = false;
            this.grpDatosCita.Text = "DATOS DE LA CITA";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(20, 30);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(58, 15);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente:";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPaciente.Location = new System.Drawing.Point(95, 27);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(650, 23);
            this.txtPaciente.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(20, 67);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(42, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(95, 64);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 23);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(290, 67);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(37, 15);
            this.lblHora.TabIndex = 4;
            this.lblHora.Text = "Hora:";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHora.Location = new System.Drawing.Point(340, 64);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(130, 23);
            this.txtHora.TabIndex = 5;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(20, 105);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(50, 15);
            this.lblMotivo.TabIndex = 6;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMotivo.Location = new System.Drawing.Point(95, 102);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ReadOnly = true;
            this.txtMotivo.Size = new System.Drawing.Size(650, 23);
            this.txtMotivo.TabIndex = 7;
            // 
            // grpConsulta
            // 
            this.grpConsulta.Controls.Add(this.lblDiagnostico);
            this.grpConsulta.Controls.Add(this.txtDiagnostico);
            this.grpConsulta.Controls.Add(this.lblTratamiento);
            this.grpConsulta.Controls.Add(this.txtTratamiento);
            this.grpConsulta.Controls.Add(this.lblObservaciones);
            this.grpConsulta.Controls.Add(this.txtObservaciones);
            this.grpConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpConsulta.Location = new System.Drawing.Point(260, 300);
            this.grpConsulta.Name = "grpConsulta";
            this.grpConsulta.Size = new System.Drawing.Size(790, 240);
            this.grpConsulta.TabIndex = 21;
            this.grpConsulta.TabStop = false;
            this.grpConsulta.Text = "CONSULTA MÉDICA";
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(20, 32);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(75, 15);
            this.lblDiagnostico.TabIndex = 0;
            this.lblDiagnostico.Text = "Diagnóstico:";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiagnostico.Location = new System.Drawing.Point(130, 28);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnostico.Size = new System.Drawing.Size(615, 50);
            this.txtDiagnostico.TabIndex = 1;
            // 
            // lblTratamiento
            // 
            this.lblTratamiento.AutoSize = true;
            this.lblTratamiento.Location = new System.Drawing.Point(20, 100);
            this.lblTratamiento.Name = "lblTratamiento";
            this.lblTratamiento.Size = new System.Drawing.Size(78, 15);
            this.lblTratamiento.TabIndex = 2;
            this.lblTratamiento.Text = "Tratamiento:";
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTratamiento.Location = new System.Drawing.Point(130, 95);
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTratamiento.Size = new System.Drawing.Size(615, 50);
            this.txtTratamiento.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(20, 168);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(91, 15);
            this.lblObservaciones.TabIndex = 4;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(130, 163);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(615, 50);
            this.txtObservaciones.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(570, 565);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 38);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "GUARDAR ATENCIÓN";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(770, 565);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 38);
            this.btnLimpiar.TabIndex = 23;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmAtenderCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.grpDatosCita);
            this.Controls.Add(this.grpConsulta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAtenderCita";
            this.Text = "Atender Cita";
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.grpConsulta, 0);
            this.Controls.SetChildIndex(this.grpDatosCita, 0);
            this.Controls.SetChildIndex(this.pnlMenu, 0);
            this.Controls.SetChildIndex(this.pnlSuperior, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.grpDatosCita.ResumeLayout(false);
            this.grpDatosCita.PerformLayout();
            this.grpConsulta.ResumeLayout(false);
            this.grpConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}