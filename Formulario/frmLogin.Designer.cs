namespace Integrador2024
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btn_cerrarProgram = new Button();
            pictureBox1 = new PictureBox();
            txt_contrasena = new TextBox();
            lbl_contrasena = new Label();
            txt_usuario = new TextBox();
            lbl_usuario = new Label();
            btn_Inicio = new Button();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            btn_limpiar = new Button();
            btn_registrar = new Button();
            txt_rPassw = new TextBox();
            txt_rApellyNom = new TextBox();
            txt_rUsuario = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(144, 46);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(473, 517);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btn_cerrarProgram);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(txt_contrasena);
            tabPage1.Controls.Add(lbl_contrasena);
            tabPage1.Controls.Add(txt_usuario);
            tabPage1.Controls.Add(lbl_usuario);
            tabPage1.Controls.Add(btn_Inicio);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(465, 489);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Iniciar sesion  ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_cerrarProgram
            // 
            btn_cerrarProgram.BackColor = Color.Silver;
            btn_cerrarProgram.FlatAppearance.BorderSize = 0;
            btn_cerrarProgram.FlatStyle = FlatStyle.Flat;
            btn_cerrarProgram.Image = (Image)resources.GetObject("btn_cerrarProgram.Image");
            btn_cerrarProgram.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cerrarProgram.Location = new Point(239, 375);
            btn_cerrarProgram.Name = "btn_cerrarProgram";
            btn_cerrarProgram.Size = new Size(87, 40);
            btn_cerrarProgram.TabIndex = 13;
            btn_cerrarProgram.Text = "Cerrar";
            btn_cerrarProgram.TextAlign = ContentAlignment.MiddleRight;
            btn_cerrarProgram.UseVisualStyleBackColor = false;
            btn_cerrarProgram.Click += button1_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(144, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // txt_contrasena
            // 
            txt_contrasena.Location = new Point(157, 290);
            txt_contrasena.Name = "txt_contrasena";
            txt_contrasena.PasswordChar = '*';
            txt_contrasena.PlaceholderText = "Ingrese contrasena";
            txt_contrasena.Size = new Size(194, 23);
            txt_contrasena.TabIndex = 11;
            // 
            // lbl_contrasena
            // 
            lbl_contrasena.AutoSize = true;
            lbl_contrasena.Location = new Point(74, 293);
            lbl_contrasena.Name = "lbl_contrasena";
            lbl_contrasena.Size = new Size(67, 15);
            lbl_contrasena.TabIndex = 10;
            lbl_contrasena.Text = "Contrasena";
            // 
            // txt_usuario
            // 
            txt_usuario.Location = new Point(157, 234);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.PlaceholderText = "Ingrese usuario";
            txt_usuario.Size = new Size(194, 23);
            txt_usuario.TabIndex = 8;
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.Location = new Point(74, 234);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(47, 15);
            lbl_usuario.TabIndex = 7;
            lbl_usuario.Text = "Usuario";
            // 
            // btn_Inicio
            // 
            btn_Inicio.BackColor = Color.Silver;
            btn_Inicio.FlatAppearance.BorderSize = 0;
            btn_Inicio.FlatStyle = FlatStyle.Flat;
            btn_Inicio.Image = (Image)resources.GetObject("btn_Inicio.Image");
            btn_Inicio.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Inicio.Location = new Point(104, 375);
            btn_Inicio.Name = "btn_Inicio";
            btn_Inicio.Size = new Size(102, 40);
            btn_Inicio.TabIndex = 6;
            btn_Inicio.Text = "Ingresar";
            btn_Inicio.TextAlign = ContentAlignment.MiddleRight;
            btn_Inicio.UseVisualStyleBackColor = false;
            btn_Inicio.Click += btn_Inicio_Click_1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(465, 489);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Registar";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_limpiar);
            groupBox1.Controls.Add(btn_registrar);
            groupBox1.Controls.Add(txt_rPassw);
            groupBox1.Controls.Add(txt_rApellyNom);
            groupBox1.Controls.Add(txt_rUsuario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label6);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(52, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 399);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos personales";
            // 
            // btn_limpiar
            // 
            btn_limpiar.Image = (Image)resources.GetObject("btn_limpiar.Image");
            btn_limpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_limpiar.Location = new Point(188, 316);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(91, 39);
            btn_limpiar.TabIndex = 11;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.TextAlign = ContentAlignment.MiddleRight;
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += button2_Click;
            // 
            // btn_registrar
            // 
            btn_registrar.Image = (Image)resources.GetObject("btn_registrar.Image");
            btn_registrar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_registrar.Location = new Point(61, 316);
            btn_registrar.Name = "btn_registrar";
            btn_registrar.Size = new Size(97, 39);
            btn_registrar.TabIndex = 10;
            btn_registrar.Text = "Registrar";
            btn_registrar.TextAlign = ContentAlignment.MiddleRight;
            btn_registrar.UseVisualStyleBackColor = true;
            btn_registrar.Click += btn_registrar_Click;
            // 
            // txt_rPassw
            // 
            txt_rPassw.Location = new Point(144, 215);
            txt_rPassw.Name = "txt_rPassw";
            txt_rPassw.PlaceholderText = "Ingrese contraseña";
            txt_rPassw.Size = new Size(181, 23);
            txt_rPassw.TabIndex = 7;
            // 
            // txt_rApellyNom
            // 
            txt_rApellyNom.Location = new Point(144, 167);
            txt_rApellyNom.Name = "txt_rApellyNom";
            txt_rApellyNom.PlaceholderText = "Ingrese nombre y apellido";
            txt_rApellyNom.Size = new Size(181, 23);
            txt_rApellyNom.TabIndex = 6;
            // 
            // txt_rUsuario
            // 
            txt_rUsuario.Location = new Point(144, 125);
            txt_rUsuario.Name = "txt_rUsuario";
            txt_rUsuario.PlaceholderText = "Ingrese su usuario";
            txt_rUsuario.Size = new Size(181, 23);
            txt_rUsuario.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 218);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 170);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre y Apellido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 128);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 0;
            label6.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 16);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 613);
            Controls.Add(tabControl1);
            Name = "frmLogin";
            Text = "frmLogin";
            Load += frmLogin_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private PictureBox pictureBox1;
        private TextBox txt_contrasena;
        private Label lbl_contrasena;
        private TextBox txt_usuario;
        private Label lbl_usuario;
        private Button btn_Inicio;
        private TabPage tabPage2;
        private Label label1;
        private GroupBox groupBox1;
        private Button btn_limpiar;
        private Button btn_registrar;
        private TextBox txt_rPassw;
        private TextBox txt_rApellyNom;
        private TextBox txt_rUsuario;
        private Label label3;
        private Label label2;
        private Label label6;
        private Button btn_cerrarProgram;
    }
}