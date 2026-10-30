namespace Proyecto_Catedra_UDB
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTituloUsuarios;
        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnInhabilitar;
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
            this.lblTituloUsuarios = new System.Windows.Forms.Label();
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.cbMostrarClave = new System.Windows.Forms.CheckBox();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.Clave = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnInhabilitar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnReactivar = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPacientes
            // 
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.FlatAppearance.BorderSize = 0;
            // 
            // btnMedicos
            // 
            this.btnMedicos.FlatAppearance.BorderSize = 0;
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
            this.lblTitulo.Size = new System.Drawing.Size(432, 50);
            this.lblTitulo.Text = "GESTIÓN DE USUARIOS";
            // 
            // lblTituloUsuarios
            // 
            this.lblTituloUsuarios.AutoSize = true;
            this.lblTituloUsuarios.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloUsuarios.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTituloUsuarios.Location = new System.Drawing.Point(260, 90);
            this.lblTituloUsuarios.Name = "lblTituloUsuarios";
            this.lblTituloUsuarios.Size = new System.Drawing.Size(314, 37);
            this.lblTituloUsuarios.TabIndex = 19;
            this.lblTituloUsuarios.Text = "GESTIÓN DE USUARIOS";
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.cbMostrarClave);
            this.grpBusqueda.Controls.Add(this.txtNuevaClave);
            this.grpBusqueda.Controls.Add(this.Clave);
            this.grpBusqueda.Controls.Add(this.lblBuscar);
            this.grpBusqueda.Controls.Add(this.txtUsername);
            this.grpBusqueda.Controls.Add(this.txtBuscar);
            this.grpBusqueda.Controls.Add(this.label1);
            this.grpBusqueda.Controls.Add(this.lblTipo);
            this.grpBusqueda.Controls.Add(this.cmbTipoUsuario);
            this.grpBusqueda.Controls.Add(this.btnBuscar);
            this.grpBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBusqueda.Location = new System.Drawing.Point(260, 150);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(790, 110);
            this.grpBusqueda.TabIndex = 20;
            this.grpBusqueda.TabStop = false;
            this.grpBusqueda.Text = "BUSCAR USUARIO";
            // 
            // cbMostrarClave
            // 
            this.cbMostrarClave.AutoSize = true;
            this.cbMostrarClave.Location = new System.Drawing.Point(640, 80);
            this.cbMostrarClave.Name = "cbMostrarClave";
            this.cbMostrarClave.Size = new System.Drawing.Size(135, 19);
            this.cbMostrarClave.TabIndex = 30;
            this.cbMostrarClave.Text = "Mostrar Contraseña";
            this.cbMostrarClave.UseVisualStyleBackColor = true;
            this.cbMostrarClave.CheckedChanged += new System.EventHandler(this.cbMostrarClave_CheckedChanged);
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(440, 78);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.Size = new System.Drawing.Size(180, 23);
            this.txtNuevaClave.TabIndex = 29;
            // 
            // Clave
            // 
            this.Clave.AutoSize = true;
            this.Clave.ForeColor = System.Drawing.Color.Black;
            this.Clave.Location = new System.Drawing.Point(366, 81);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(69, 15);
            this.Clave.TabIndex = 28;
            this.Clave.Text = "Contraseña";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(20, 35);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(56, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Nombre:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(90, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(270, 23);
            this.txtUsername.TabIndex = 27;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(90, 32);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(270, 23);
            this.txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Usuario";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(390, 35);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 15);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo:";
            // 
            // cmbTipoUsuario
            // 
            this.cmbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoUsuario.Items.AddRange(new object[] {
            "Todos",
            "Administrador",
            "Médico",
            "Paciente"});
            this.cmbTipoUsuario.Location = new System.Drawing.Point(440, 32);
            this.cmbTipoUsuario.Name = "cmbTipoUsuario";
            this.cmbTipoUsuario.Size = new System.Drawing.Size(180, 23);
            this.cmbTipoUsuario.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(640, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(260, 280);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(790, 270);
            this.dgvUsuarios.TabIndex = 21;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(260, 575);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 38);
            this.btnActualizar.TabIndex = 22;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnInhabilitar
            // 
            this.btnInhabilitar.BackColor = System.Drawing.Color.LightGray;
            this.btnInhabilitar.FlatAppearance.BorderSize = 0;
            this.btnInhabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInhabilitar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInhabilitar.Location = new System.Drawing.Point(440, 575);
            this.btnInhabilitar.Name = "btnInhabilitar";
            this.btnInhabilitar.Size = new System.Drawing.Size(160, 38);
            this.btnInhabilitar.TabIndex = 23;
            this.btnInhabilitar.Text = "INHABILITAR";
            this.btnInhabilitar.UseVisualStyleBackColor = false;
            this.btnInhabilitar.Click += new System.EventHandler(this.btnInhabilitar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(890, 575);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 38);
            this.btnLimpiar.TabIndex = 24;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnReactivar
            // 
            this.btnReactivar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReactivar.FlatAppearance.BorderSize = 0;
            this.btnReactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReactivar.ForeColor = System.Drawing.Color.White;
            this.btnReactivar.Location = new System.Drawing.Point(627, 575);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(160, 38);
            this.btnReactivar.TabIndex = 25;
            this.btnReactivar.Text = "REACTIVAR";
            this.btnReactivar.UseVisualStyleBackColor = false;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.btnReactivar);
            this.Controls.Add(this.lblTituloUsuarios);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnInhabilitar);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "FrmUsuarios";
            this.Text = "Gestión de Usuarios";
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.btnInhabilitar, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.dgvUsuarios, 0);
            this.Controls.SetChildIndex(this.grpBusqueda, 0);
            this.Controls.SetChildIndex(this.lblTituloUsuarios, 0);
            this.Controls.SetChildIndex(this.pnlMenu, 0);
            this.Controls.SetChildIndex(this.pnlSuperior, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.btnReactivar, 0);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReactivar;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Label Clave;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbMostrarClave;
    }
}