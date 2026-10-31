namespace Proyecto_Catedra_UDB
{
    partial class frmRegistrarse
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
            this.components = new System.ComponentModel.Container();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblAplicacion = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4 = new System.Windows.Forms.TabPage();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736 = new System.Windows.Forms.TabControl();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.cbMostrarClave = new System.Windows.Forms.CheckBox();
            this.pnlDatosPer = new System.Windows.Forms.Panel();
            this.mtxTelefono = new System.Windows.Forms.MaskedTextBox();
            this.errContraseña = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlSuperior.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.pnlDatosPer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errContraseña)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlSuperior.Controls.Add(this.lblAplicacion);
            this.pnlSuperior.Controls.Add(this.lblUser);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(288, 511);
            this.pnlSuperior.TabIndex = 25;
            // 
            // lblAplicacion
            // 
            this.lblAplicacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAplicacion.AutoSize = true;
            this.lblAplicacion.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold);
            this.lblAplicacion.ForeColor = System.Drawing.Color.White;
            this.lblAplicacion.Location = new System.Drawing.Point(30, 197);
            this.lblAplicacion.Name = "lblAplicacion";
            this.lblAplicacion.Size = new System.Drawing.Size(231, 92);
            this.lblAplicacion.TabIndex = 9;
            this.lblAplicacion.Text = "Gestión de \r\nCitas Médicas";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(534, 240);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(81, 28);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "Usuario";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.LightBlue;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.Black;
            this.btnSiguiente.Location = new System.Drawing.Point(43, 319);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(300, 28);
            this.btnSiguiente.TabIndex = 30;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.White;
            this.txtApellido.Location = new System.Drawing.Point(43, 148);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(300, 20);
            this.txtApellido.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellidos";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(43, 94);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 20);
            this.txtNombre.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombres";
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.Location = new System.Drawing.Point(166, 200);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(177, 20);
            this.txtCorreo.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Correo Electrónico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Teléfono";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(40, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(43, 262);
            this.dtpFechaNacimiento.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(300, 29);
            this.dtpFechaNacimiento.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(40, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 37);
            this.label5.TabIndex = 32;
            this.label5.Text = "Datos Personales";
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegistrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarse.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarse.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarse.Location = new System.Drawing.Point(43, 264);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(300, 35);
            this.btnRegistrarse.TabIndex = 40;
            this.btnRegistrarse.Text = "REGISTRARSE";
            this.btnRegistrarse.UseVisualStyleBackColor = false;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.LightBlue;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.Black;
            this.btnRegresar.Location = new System.Drawing.Point(43, 319);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(300, 28);
            this.btnRegresar.TabIndex = 41;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(40, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 37);
            this.label7.TabIndex = 37;
            this.label7.Text = "Crear Usuario";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Nombre de Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(43, 94);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(300, 20);
            this.txtUsuario.TabIndex = 34;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(44, 130);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(78, 17);
            this.lblClave.TabIndex = 35;
            this.lblClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.Location = new System.Drawing.Point(43, 150);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(300, 20);
            this.txtClave.TabIndex = 36;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(373, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "¿Ya tienes una cuenta? ";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.Location = new System.Drawing.Point(515, 465);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(107, 25);
            this.btnLogin.TabIndex = 42;
            this.btnLogin.Text = "Inicia Sesión";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // object_b6e53596_c515_4b6e_b7e2_944567c8f2d4
            // 
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.Location = new System.Drawing.Point(4, 22);
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.Name = "object_b6e53596_c515_4b6e_b7e2_944567c8f2d4";
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.Padding = new System.Windows.Forms.Padding(3);
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.Size = new System.Drawing.Size(378, 416);
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.TabIndex = 1;
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.Text = "Creación de Usuario";
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.UseVisualStyleBackColor = true;
            this.object_b6e53596_c515_4b6e_b7e2_944567c8f2d4.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitulo.Location = new System.Drawing.Point(417, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(146, 37);
            this.lblTitulo.TabIndex = 26;
            this.lblTitulo.Text = "REGISTRO";
            // 
            // object_f162e00b_c7c2_421e_aa64_1156bbe65736
            // 
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.Location = new System.Drawing.Point(0, 69);
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.Name = "object_f162e00b_c7c2_421e_aa64_1156bbe65736";
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.SelectedIndex = 0;
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.Size = new System.Drawing.Size(674, 442);
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.TabIndex = 31;
            this.object_f162e00b_c7c2_421e_aa64_1156bbe65736.Visible = false;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.White;
            this.pnlUsuario.Controls.Add(this.cbMostrarClave);
            this.pnlUsuario.Controls.Add(this.btnRegistrarse);
            this.pnlUsuario.Controls.Add(this.btnRegresar);
            this.pnlUsuario.Controls.Add(this.label7);
            this.pnlUsuario.Controls.Add(this.txtClave);
            this.pnlUsuario.Controls.Add(this.lblClave);
            this.pnlUsuario.Controls.Add(this.txtUsuario);
            this.pnlUsuario.Controls.Add(this.label8);
            this.pnlUsuario.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.pnlUsuario.Location = new System.Drawing.Point(288, 69);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(385, 371);
            this.pnlUsuario.TabIndex = 11;
            this.pnlUsuario.Visible = false;
            // 
            // cbMostrarClave
            // 
            this.cbMostrarClave.AutoSize = true;
            this.cbMostrarClave.Location = new System.Drawing.Point(43, 182);
            this.cbMostrarClave.Name = "cbMostrarClave";
            this.cbMostrarClave.Size = new System.Drawing.Size(118, 17);
            this.cbMostrarClave.TabIndex = 37;
            this.cbMostrarClave.Text = "Mostrar Contraseña";
            this.cbMostrarClave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbMostrarClave.UseVisualStyleBackColor = true;
            this.cbMostrarClave.CheckedChanged += new System.EventHandler(this.cbMostrarClave_CheckedChanged);
            // 
            // pnlDatosPer
            // 
            this.pnlDatosPer.BackColor = System.Drawing.Color.Transparent;
            this.pnlDatosPer.Controls.Add(this.mtxTelefono);
            this.pnlDatosPer.Controls.Add(this.label11);
            this.pnlDatosPer.Controls.Add(this.dtpFechaNacimiento);
            this.pnlDatosPer.Controls.Add(this.label5);
            this.pnlDatosPer.Controls.Add(this.txtApellido);
            this.pnlDatosPer.Controls.Add(this.label3);
            this.pnlDatosPer.Controls.Add(this.label1);
            this.pnlDatosPer.Controls.Add(this.label2);
            this.pnlDatosPer.Controls.Add(this.label4);
            this.pnlDatosPer.Controls.Add(this.txtCorreo);
            this.pnlDatosPer.Controls.Add(this.btnSiguiente);
            this.pnlDatosPer.Controls.Add(this.txtNombre);
            this.pnlDatosPer.Location = new System.Drawing.Point(288, 69);
            this.pnlDatosPer.Name = "pnlDatosPer";
            this.pnlDatosPer.Size = new System.Drawing.Size(385, 374);
            this.pnlDatosPer.TabIndex = 12;
            // 
            // mtxTelefono
            // 
            this.mtxTelefono.Location = new System.Drawing.Point(43, 199);
            this.mtxTelefono.Mask = "0000-0000";
            this.mtxTelefono.Name = "mtxTelefono";
            this.mtxTelefono.Size = new System.Drawing.Size(100, 20);
            this.mtxTelefono.TabIndex = 33;
            // 
            // errContraseña
            // 
            this.errContraseña.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errContraseña.ContainerControl = this;
            // 
            // frmRegistrarse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(674, 511);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlDatosPer);
            this.Controls.Add(this.pnlUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmRegistrarse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegistrarse";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.pnlDatosPer.ResumeLayout(false);
            this.pnlDatosPer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errContraseña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblAplicacion;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegresar;
        protected System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.TabPage object_b6e53596_c515_4b6e_b7e2_944567c8f2d4;
        protected System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TabControl object_f162e00b_c7c2_421e_aa64_1156bbe65736;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Panel pnlDatosPer;
        private System.Windows.Forms.CheckBox cbMostrarClave;
        private System.Windows.Forms.ErrorProvider errContraseña;
        private System.Windows.Forms.MaskedTextBox mtxTelefono;
    }
}