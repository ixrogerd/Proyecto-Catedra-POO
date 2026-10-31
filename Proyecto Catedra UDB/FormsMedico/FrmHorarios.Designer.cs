namespace Proyecto_Catedra_UDB
{
    partial class FrmHorarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvHorarios;
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
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.grpHorario = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.grpHorario.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(213, 50);
            this.lblTitulo.Text = "HORARIOS";
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.AllowUserToAddRows = false;
            this.dgvHorarios.AllowUserToDeleteRows = false;
            this.dgvHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHorarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarios.Location = new System.Drawing.Point(260, 320);
            this.dgvHorarios.MultiSelect = false;
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHorarios.RowHeadersVisible = false;
            this.dgvHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHorarios.Size = new System.Drawing.Size(790, 220);
            this.dgvHorarios.TabIndex = 21;
            this.dgvHorarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHorarios_CellClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(880, 563);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(170, 38);
            this.btnLimpiar.TabIndex = 23;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Enabled = false;
            this.dtpHoraFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(105, 86);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(200, 23);
            this.dtpHoraFin.TabIndex = 5;
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(25, 90);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(55, 15);
            this.lblHoraFin.TabIndex = 4;
            this.lblHoraFin.Text = "Hora fin:";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Enabled = false;
            this.dtpHoraInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(440, 36);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(130, 23);
            this.dtpHoraInicio.TabIndex = 3;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(350, 40);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(69, 15);
            this.lblHoraInicio.TabIndex = 2;
            this.lblHoraInicio.Text = "Hora inicio:";
            // 
            // cmbDia
            // 
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.cmbDia.Location = new System.Drawing.Point(105, 36);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(200, 23);
            this.cmbDia.TabIndex = 1;
            this.cmbDia.SelectedIndexChanged += new System.EventHandler(this.cmbDia_SelectedIndexChanged);
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(25, 40);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(28, 15);
            this.lblDia.TabIndex = 0;
            this.lblDia.Text = "Día:";
            // 
            // grpHorario
            // 
            this.grpHorario.Controls.Add(this.lblDia);
            this.grpHorario.Controls.Add(this.cmbDia);
            this.grpHorario.Controls.Add(this.lblHoraInicio);
            this.grpHorario.Controls.Add(this.dtpHoraInicio);
            this.grpHorario.Controls.Add(this.lblHoraFin);
            this.grpHorario.Controls.Add(this.dtpHoraFin);
            this.grpHorario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpHorario.Location = new System.Drawing.Point(260, 150);
            this.grpHorario.Name = "grpHorario";
            this.grpHorario.Size = new System.Drawing.Size(790, 150);
            this.grpHorario.TabIndex = 20;
            this.grpHorario.TabStop = false;
            this.grpHorario.Text = "Datos del horario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(259, 563);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "*Su horario de atención es definido por la administración.";
            // 
            // FrmHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpHorario);
            this.Controls.Add(this.dgvHorarios);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "FrmHorarios";
            this.Text = "Horarios";
            this.Load += new System.EventHandler(this.FrmHorarios_Load);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.dgvHorarios, 0);
            this.Controls.SetChildIndex(this.grpHorario, 0);
            this.Controls.SetChildIndex(this.pnlMenu, 0);
            this.Controls.SetChildIndex(this.pnlSuperior, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.grpHorario.ResumeLayout(false);
            this.grpHorario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.GroupBox grpHorario;
        private System.Windows.Forms.Label label1;
    }
}