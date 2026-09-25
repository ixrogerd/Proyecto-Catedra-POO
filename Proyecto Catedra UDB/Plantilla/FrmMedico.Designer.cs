namespace Proyecto_Catedra_UDB
{
    partial class FrmMedico
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
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnReceta = new System.Windows.Forms.Button();
            this.btnHorarios = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRol
            // 
            this.lblRol.Size = new System.Drawing.Size(87, 28);
            this.lblRol.Text = "MÉDICO";
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
            this.pnlMenu.Controls.Add(this.btnHorarios);
            this.pnlMenu.Controls.Add(this.btnReceta);
            this.pnlMenu.Controls.Add(this.btnAtender);
            this.pnlMenu.Controls.Add(this.btnCitas);
            this.pnlMenu.Controls.SetChildIndex(this.btnInicio, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnCerrarSesion, 0);
            this.pnlMenu.Controls.SetChildIndex(this.lblRol, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnCitas, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnAtender, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnReceta, 0);
            this.pnlMenu.Controls.SetChildIndex(this.btnHorarios, 0);
            // 
            // btnCitas
            // 
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCitas.Location = new System.Drawing.Point(0, 130);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(230, 50);
            this.btnCitas.TabIndex = 9;
            this.btnCitas.Text = "MIS CITAS";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnAtender
            // 
            this.btnAtender.FlatAppearance.BorderSize = 0;
            this.btnAtender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtender.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAtender.Location = new System.Drawing.Point(0, 180);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(230, 50);
            this.btnAtender.TabIndex = 10;
            this.btnAtender.Text = "ATENDER CITA";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(this.btnAtender_Click);
            // 
            // btnReceta
            // 
            this.btnReceta.FlatAppearance.BorderSize = 0;
            this.btnReceta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceta.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnReceta.Location = new System.Drawing.Point(0, 230);
            this.btnReceta.Name = "btnReceta";
            this.btnReceta.Size = new System.Drawing.Size(230, 50);
            this.btnReceta.TabIndex = 11;
            this.btnReceta.Text = "EMITIR RECETA";
            this.btnReceta.UseVisualStyleBackColor = true;
            this.btnReceta.Click += new System.EventHandler(this.btnReceta_Click);
            // 
            // btnHorarios
            // 
            this.btnHorarios.FlatAppearance.BorderSize = 0;
            this.btnHorarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorarios.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnHorarios.Location = new System.Drawing.Point(0, 280);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Size = new System.Drawing.Size(230, 50);
            this.btnHorarios.TabIndex = 12;
            this.btnHorarios.Text = "HORARIOS";
            this.btnHorarios.UseVisualStyleBackColor = true;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // FrmMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Name = "FrmMedico";
            this.Text = "FrmMedico";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnCitas;
        protected System.Windows.Forms.Button btnAtender;
        protected System.Windows.Forms.Button btnReceta;
        protected System.Windows.Forms.Button btnHorarios;
    }
}