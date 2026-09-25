namespace Proyecto_Catedra_UDB
{
    partial class FrmAdministrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRol
            // 
            this.lblRol.Location = new System.Drawing.Point(30, 30);
            this.lblRol.Size = new System.Drawing.Size(172, 28);
            this.lblRol.Text = "ADMINISTRADOR";
            // 
            // btnInicio
            // 
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnReportes);
            this.pnlMenu.Controls.Add(this.btnUsuarios);
            this.pnlMenu.Controls.Add(this.btnEspecialidades);
            this.pnlMenu.Controls.Add(this.btnMedicos);
            this.pnlMenu.Controls.Add(this.btnPacientes);
            this.pnlMenu.Controls.SetChildIndex(this.btnInicio, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnCerrarSesion, 0);
            this.pnlMenu.Controls.SetChildIndex(this.lblRol, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnPacientes, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnMedicos, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnEspecialidades, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnUsuarios, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnReportes, 0);
            // 
            // btnPacientes
            // 
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.Location = new System.Drawing.Point(0, 130);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(230, 50);
            this.btnPacientes.TabIndex = 8;
            this.btnPacientes.Text = "PACIENTES";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.FlatAppearance.BorderSize = 0;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMedicos.Location = new System.Drawing.Point(0, 180);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(230, 50);
            this.btnMedicos.TabIndex = 9;
            this.btnMedicos.Text = "MÉDICOS";
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.FlatAppearance.BorderSize = 0;
            this.btnEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecialidades.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEspecialidades.Location = new System.Drawing.Point(0, 230);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(230, 50);
            this.btnEspecialidades.TabIndex = 10;
            this.btnEspecialidades.Text = "ESPECIALIDADES";
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.Location = new System.Drawing.Point(0, 280);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(230, 50);
            this.btnUsuarios.TabIndex = 11;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnReportes.Location = new System.Drawing.Point(0, 330);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(230, 50);
            this.btnReportes.TabIndex = 12;
            this.btnReportes.Text = "REPORTES";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // FrmAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Name = "FrmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Administrador";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Button btnPacientes;
        protected System.Windows.Forms.Button btnUsuarios;
        protected System.Windows.Forms.Button btnEspecialidades;
        protected System.Windows.Forms.Button btnMedicos;
        protected System.Windows.Forms.Button btnReportes;
    }
}