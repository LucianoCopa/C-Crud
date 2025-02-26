using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using Integrador2024.Datos;
using Integrador2024.Entidades;


namespace Integrador2024
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //public string Usuario = "admin", Contrasena = "root";
        private void btn_Inicio_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            txt_rUsuario.Clear();
            txt_rApellyNom.Clear();
            txt_rPassw.Clear();


            txt_rUsuario.Select(0, 0);
            txt_rUsuario.Focus();
        }


        private void btn_registrar_Click(object sender, EventArgs e)
        {

        }
        private void btn_Inicio_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_usuario.Text) || string.IsNullOrEmpty(txt_contrasena.Text))
            {
                MessageBox.Show("Debe ingresar Usuario y Contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_usuario.Focus();
                return;
            }

            // Instanciar la clase DAL y validar el usuario
            Dal objDal = new Dal();
            bool esValido = objDal.ValidarUsuario(txt_usuario.Text, txt_contrasena.Text);

            if (esValido)
            {

                MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    // Abrir el formulario principal
                    frmsPrincipal frmPrincipal = new frmsPrincipal();
                    
                    frmPrincipal.Show();

                // Cerrar el formulario de login
                this.Hide();

            }
            
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar los campos y enfocar el campo usuario
                txt_usuario.Clear();
                txt_contrasena.Clear();
                txt_usuario.Focus();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
