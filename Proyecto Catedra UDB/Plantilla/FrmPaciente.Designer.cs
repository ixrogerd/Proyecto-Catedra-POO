namespace Proyecto_Catedra_UDB
{
    partial class FrmPaciente
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
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnAgendarCita = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRol
            // 
            this.lblRol.Size = new System.Drawing.Size(100, 28);
            this.lblRol.Text = "PACIENTE";
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
            this.pnlMenu.Controls.Add(this.btnAgendarCita);
            this.pnlMenu.Controls.Add(this.btnCitas);
            this.pnlMenu.Controls.Add(this.btnDisponibilidad);
            this.pnlMenu.Controls.SetChildIndex(this.btnDisponibilidad, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnCitas, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnAgendarCita, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnInicio, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnCerrarSesion, 0);
            this.pnlMenu.Controls.SetChildIndex(this.lblRol, 0);
            // 
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.FlatAppearance.BorderSize = 0;
            this.btnDisponibilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisponibilidad.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDisponibilidad.Location = new System.Drawing.Point(0, 130);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(230, 50);
            this.btnDisponibilidad.TabIndex = 19;
            this.btnDisponibilidad.Text = "DISPONIBILIDAD";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            this.btnDisponibilidad.Click += new System.EventHandler(this.btnDisponibilidad_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCitas.Location = new System.Drawing.Point(0, 230);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(230, 50);
            this.btnCitas.TabIndex = 20;
            this.btnCitas.Text = "MIS CITAS";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnAgendarCita
            // 
            this.btnAgendarCita.FlatAppearance.BorderSize = 0;
            this.btnAgendarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendarCita.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAgendarCita.Location = new System.Drawing.Point(0, 180);
            this.btnAgendarCita.Name = "btnAgendar";
            this.btnAgendarCita.Size = new System.Drawing.Size(230, 50);
            this.btnAgendarCita.TabIndex = 21;
            this.btnAgendarCita.Text = "AGENDAR CITA";
            this.btnAgendarCita.UseVisualStyleBackColor = true;
            this.btnAgendarCita.Click += new System.EventHandler(this.btnAgendarCita_Click);
            // 
            // FrmPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Name = "FrmPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel del Paciente";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnAgendarCita;
        protected System.Windows.Forms.Button btnCitas;
        protected System.Windows.Forms.Button btnDisponibilidad;
    }
}