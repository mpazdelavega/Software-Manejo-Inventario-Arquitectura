using CapaDTO;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class PantallaMantenedorBodeguero : Form
    {
        private int posicion;
        private int ultimo;
        private String genero;

        public int Posicion { get => posicion; set => posicion = value; }
        public int Ultimo { get => ultimo; set => ultimo = value; }
        public string Genero { get => genero; set => genero = value; }

        public PantallaMantenedorBodeguero()
        {
            InitializeComponent();
            this.txtRutBodeguero.MaxLength = 10;
            this.txtNombreBodeguero.MaxLength = 25;
            this.txtApellidoBodeguero.MaxLength = 30;
            this.txtCorreoBodeguero.MaxLength = 50;
            this.txtTelefonoBodeguero.MaxLength = 9;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void mostrar()
        {
            ServiceMantenedorBodeguero.bodeguero auxBodeguero = new ServiceMantenedorBodeguero.bodeguero();
            ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient auxServicio = new ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient();

            this.Ultimo = auxServicio.webConsultaBodeguero().Tables[0].Rows.Count - 1;

            if (this.Posicion < 0)
                this.Posicion = 0;
            if (this.Posicion > this.Ultimo)
                this.Posicion = this.Ultimo;

            auxBodeguero = auxServicio.webPosicionBodeguero(this.Posicion);

            this.txtRutBodeguero.Text = auxBodeguero.Rut_bodeguero;
            this.txtNombreBodeguero.Text = auxBodeguero.Nombre_bodeguero;
            this.txtApellidoBodeguero.Text = auxBodeguero.Apellido_bodeguero;
            if (Convert.ToString(auxBodeguero.Genero_bodeguero) == "Masculino")
            {
                this.rbtMasculino.Checked = true;
            }
            else
            {
                this.rbtFemenino.Checked = true;
            }
            this.txtCorreoBodeguero.Text = auxBodeguero.Correo_bodeguero;
            this.txtTelefonoBodeguero.Text = Convert.ToString(auxBodeguero.Telefono_bodeguero);


            this.txtPosicion.Text = (this.Posicion + 1) + " - "
                                    + (this.Ultimo + 1);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (btnSalir.Text.Equals("Salir"))
            {
                this.Dispose();
                GC.Collect();
            }
            else if (btnSalir.Text.Equals("Cancelar"))
            {
                this.deshabilitar();
                this.Limpiar();
                this.mostrar();
                this.btnRegistrar.Text = "Registrar";
                this.btnSalir.Text = "Salir";
                this.btnActualizar.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.btnListar.Enabled = true;
                this.btnPrimero.Enabled = true;
                this.btnSiguiente.Enabled = true;
                this.btnAnterior.Enabled = true;
                this.btoUltimo.Enabled = true;
            }
            else
            {
                this.deshabilitar();
                this.Limpiar();
                this.mostrar();
                this.btnActualizar.Text = "Actualizar";
                this.btnSalir.Text = "Salir";
                this.btnRegistrar.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.btnListar.Enabled = true;
                this.btnPrimero.Enabled = true;
                this.btnSiguiente.Enabled = true;
                this.btnAnterior.Enabled = true;
                this.btoUltimo.Enabled = true;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            PantallaListarBodeguero pListar = new PantallaListarBodeguero();
            pListar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
                DialogResult dr = MessageBox.Show("Esta seguro que desea eliminar al bodguero seleccionado", "Alerta", botones,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient auxServicio = new ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient();
                    auxServicio.webEliminarBodeguero(this.txtRutBodeguero.Text);
                    MessageBox.Show("Bodeguero eliminado", "Mensaje Sistema");
                    this.mostrar();
                }
                else
                {
                    this.mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Mensaje Sistema");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnActualizar.Text.Equals("Actualizar"))
                {
                    this.habilitar();
                    this.txtRutBodeguero.Enabled = false;
                    this.btnActualizar.Text = "Aceptar";
                    this.btnSalir.Text = "Atras";
                    this.btnRegistrar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnListar.Enabled = false;
                    this.btnPrimero.Enabled = false;
                    this.btnSiguiente.Enabled = false;
                    this.btnAnterior.Enabled = false;
                    this.btoUltimo.Enabled = false;

                }
                else
                {
                    if (Convert.ToInt32(this.txtRutBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese rut bodeguero", "Sistema");
                        this.txtRutBodeguero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre del bodeguero", "Sistema");
                        this.txtNombreBodeguero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtApellidoBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese apellido del proveedor", "Sistema");
                        this.txtApellidoBodeguero.Focus();
                        return;
                    }
                    if (rbtMasculino.Checked == false && rbtFemenino.Checked == false)
                    {
                        MessageBox.Show("Ingrese genero", "Sistema");
                        return;
                    }
                    if (Convert.ToInt32(this.txtCorreoBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese correo del proveedor", "Sistema");
                        this.txtCorreoBodeguero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtTelefonoBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese telefono del proveedor", "Sistema");
                        this.txtTelefonoBodeguero.Focus();
                        return;
                    }
                    if (this.rbtMasculino.Checked == true)
                    {
                        this.genero = "Masculino";
                    }
                    else
                    {
                        this.genero = "Femenino";
                    }
                    ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient auxServicio = new ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient();
                    ServiceMantenedorBodeguero.bodeguero auxBodeguero = new ServiceMantenedorBodeguero.bodeguero();
                    auxBodeguero.Rut_bodeguero = this.txtRutBodeguero.Text;
                    auxBodeguero.Nombre_bodeguero = this.txtNombreBodeguero.Text;
                    auxBodeguero.Apellido_bodeguero = this.txtApellidoBodeguero.Text;
                    auxBodeguero.Genero_bodeguero = this.genero;
                    auxBodeguero.Correo_bodeguero = this.txtCorreoBodeguero.Text;
                    auxBodeguero.Telefono_bodeguero = int.Parse(this.txtTelefonoBodeguero.Text);

                    auxServicio.webActualizarBodeguero(auxBodeguero);
                    MessageBox.Show("Datos actualizados", "Mensaje Sistema");

                    this.deshabilitar();
                    this.Limpiar();
                    this.mostrar();
                    this.btnActualizar.Text = "Actualizar";
                    this.btnSalir.Text = "Salir";
                    this.btnRegistrar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnListar.Enabled = true;
                    this.btnPrimero.Enabled = true;
                    this.btnSiguiente.Enabled = true;
                    this.btnAnterior.Enabled = true;
                    this.btoUltimo.Enabled = true;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos No Guardados " + ex.Message, "Mensaje Sistema");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnRegistrar.Text.Equals("Registrar"))
                {
                    this.habilitar();
                    this.Limpiar();
                    this.btnRegistrar.Text = "Guardar";
                    this.btnSalir.Text = "Cancelar";
                    this.btnActualizar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnListar.Enabled = false;
                    this.btnPrimero.Enabled = false;
                    this.btnSiguiente.Enabled = false;
                    this.btnAnterior.Enabled = false;
                    this.btoUltimo.Enabled = false;

                }
                else
                {
                    if (Convert.ToInt32(this.txtRutBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese rut bodeguero", "Sistema");
                        this.txtRutBodeguero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre del bodeguero", "Sistema");
                        this.txtNombreBodeguero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtApellidoBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese apellido del proveedor", "Sistema");
                        this.txtApellidoBodeguero.Focus();
                        return;
                    }
                    if (rbtMasculino.Checked == false && rbtFemenino.Checked == false)
                    {
                        MessageBox.Show("Ingrese genero", "Sistema");
                        return;
                    }
                    if (Convert.ToInt32(this.txtCorreoBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese correo del proveedor", "Sistema");
                        this.txtCorreoBodeguero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtTelefonoBodeguero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese telefono del proveedor", "Sistema");
                        this.txtTelefonoBodeguero.Focus();
                        return;
                    }
                    if (this.rbtMasculino.Checked == true)
                    {
                        this.genero = "Masculino";
                    }
                    else
                    {
                        this.genero = "Femenino";
                    }
                    //NegocioBodeguero auxNegocio = new NegocioBodeguero();
                    ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient auxServicio = new ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoapClient();
                    ServiceMantenedorBodeguero.bodeguero auxBodeguero = new ServiceMantenedorBodeguero.bodeguero();
                    auxBodeguero.Rut_bodeguero = this.txtRutBodeguero.Text;
                    auxBodeguero.Nombre_bodeguero = this.txtNombreBodeguero.Text;
                    auxBodeguero.Apellido_bodeguero = this.txtApellidoBodeguero.Text;
                    auxBodeguero.Genero_bodeguero = this.genero;
                    auxBodeguero.Correo_bodeguero = this.txtCorreoBodeguero.Text;
                    auxBodeguero.Telefono_bodeguero = int.Parse(this.txtTelefonoBodeguero.Text);
                    if(ValidaRut(txtRutBodeguero.Text) == true)
                    {
                        auxServicio.webGuardarTransaccionBodeguero(auxBodeguero);
                        MessageBox.Show("Datos Guardados", "Mensaje Sistema");

                        this.deshabilitar();
                        this.Limpiar();
                        this.mostrar();
                        this.btnRegistrar.Text = "Registrar";
                        this.btnSalir.Text = "Salir";
                        this.btnActualizar.Enabled = true;
                        this.btnEliminar.Enabled = true;
                        this.btnListar.Enabled = true;
                        this.btnPrimero.Enabled = true;
                        this.btnSiguiente.Enabled = true;
                        this.btnAnterior.Enabled = true;
                        this.btoUltimo.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Rut ingresado NO valido.\nFormato valido: 12345678-9", "Error");
                        this.txtRutBodeguero.Focus();
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos No Guardados " + ex.Message, "Mensaje Sistema");
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Posicion - 1;
            this.mostrar();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            this.Posicion = 0;
            this.mostrar();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Posicion + 1;
            this.mostrar();
        }


        private void btoUltimo_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Ultimo;
            this.mostrar();
        }

        

        private void PantallaMantenedorBodeguero_Load(object sender, EventArgs e)
        {
            this.txtPosicion.Enabled = false;
            this.Posicion = 0;
            this.mostrar();
        }

        private void deshabilitar()
        {
            this.txtRutBodeguero.Enabled = false;
            this.txtNombreBodeguero.Enabled = false;
            this.txtApellidoBodeguero.Enabled = false;
            this.rbtMasculino.Enabled = false;
            this.rbtFemenino.Enabled = false;
            this.txtCorreoBodeguero.Enabled = false;
            this.txtTelefonoBodeguero.Enabled = false;
        }

        private void habilitar()
        {
            this.txtRutBodeguero.Enabled = true;
            this.txtNombreBodeguero.Enabled = true;
            this.txtApellidoBodeguero.Enabled = true;
            this.rbtMasculino.Enabled = true;
            this.rbtFemenino.Enabled = true;
            this.txtCorreoBodeguero.Enabled = true;
            this.txtTelefonoBodeguero.Enabled = true;
        }

        private void Limpiar()
        {
            this.txtRutBodeguero.Text = String.Empty;
            this.txtNombreBodeguero.Text = String.Empty;
            this.txtApellidoBodeguero.Text = String.Empty;
            this.txtTelefonoBodeguero.Text = String.Empty;
            this.txtCorreoBodeguero.Text = String.Empty;
            this.rbtMasculino.Checked = false;
            this.rbtFemenino.Checked = false;
        }

        private void txtNombreBodeguero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtApellidoBodeguero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        private void txtTelefonoBodeguero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
    }
}
