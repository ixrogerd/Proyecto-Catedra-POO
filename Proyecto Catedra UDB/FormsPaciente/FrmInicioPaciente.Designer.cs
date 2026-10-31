namespace Proyecto_Catedra_UDB.FormsPaciente
{
    partial class FrmInicioPaciente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();

            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(500, 50);
            this.lblTitulo.Text = "INICIO";

            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font(
                "Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(45, 65, 85);
            this.label1.Location = new System.Drawing.Point(275, 205);
            this.label1.MaximumSize = new System.Drawing.Size(740, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 110);
            this.label1.TabIndex = 20;
            this.label1.Text = "¡Bienvenido a su sistema de citas médicas!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // FrmInicioPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);

            this.Controls.Add(this.label1);

            this.Name = "FrmInicioPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio del paciente";

            this.Controls.SetChildIndex(this.pnlMenu, 0);
            this.Controls.SetChildIndex(this.pnlSuperior, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.label1, 0);

            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        protected System.Windows.Forms.Label label1;
    }
}