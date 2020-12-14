using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDTO;
using CapaNegocio;

namespace CapaGUI
{
    public partial class PantallaLogin : Form
    {
        private int posicion;

        public int Posicion { get => posicion; set => posicion = value; }

        public PantallaLogin()
        {
            InitializeComponent();
            //this.txtUsuario.Text = "user1";
            //this.txtContrasena.Text = "duoc123";
        }

        private void validarLogin()
        {
            try
            {
                ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
                ServiceMantenedorProducto.login auxLogin = new ServiceMantenedorProducto.login();
                if (Convert.ToInt32(this.txtUsuario.Text.Length) == 0)
                {
                    MessageBox.Show("Ingrese usuario", "Sistema");
                    this.txtUsuario.Focus();
                    return;
                }
                if (Convert.ToInt32(this.txtContrasena.Text.Length) == 0)
                {
                    MessageBox.Show("Ingrese contraseña", "Sistema");
                    this.txtContrasena.Focus();
                    return;
                }

                auxLogin.Usuario = this.txtUsuario.Text;

                auxLogin.Contrasena = this.txtContrasena.Text;

                if (auxServicio.WebLogin(auxLogin) == true)
                {
                    this.Hide();
                    PantallaMenu pMenu = new PantallaMenu();
                    pMenu.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Mensaje Sistema");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validarLogin();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.GC.Collect();
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validarLogin();
            }
        }
    }
}
