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
    public partial class PantallaMantenedorProveedor : Form
    {
        private int posicion;
        private int ultimo;

        public int Posicion { get => posicion; set => posicion = value; }
        public int Ultimo { get => ultimo; set => ultimo = value; }

        public PantallaMantenedorProveedor()
        {
            InitializeComponent();
            this.txtRutProveedor.MaxLength = 10;
            this.txtNombreProveedor.MaxLength = 30;
            this.txtComuna.MaxLength = 30;
            this.txtCiudad.MaxLength = 30;
            this.txtDireccion.MaxLength = 50;
            this.txtNumero.MaxLength = 9;
        }

        public void mostrar()
        {
            ServiceMantenedorProveedor.proveedor auxProveedor = new ServiceMantenedorProveedor.proveedor();
            ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient auxServicio = new ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient();

            this.Ultimo = auxServicio.webConsultaProveedor().Tables[0].Rows.Count - 1;

            if (this.Posicion < 0)
                this.Posicion = 0;
            if (this.Posicion > this.Ultimo)
                this.Posicion = this.Ultimo;

            auxProveedor = auxServicio.webPosicionProveedor(this.Posicion);

            this.txtRutProveedor.Text = auxProveedor.Rut_prov;
            this.txtNombreProveedor.Text = auxProveedor.Nombre_prov;
            this.txtComuna.Text = auxProveedor.Comuna_prov;
            this.txtCiudad.Text = auxProveedor.Ciudad_prov;
            this.txtNumero.Text = Convert.ToString(auxProveedor.Numero_prov);
            this.txtDireccion.Text = auxProveedor.Direccion_prov;

            this.txtPosicion.Text = (this.Posicion + 1) + " - "
                                    + (this.Ultimo + 1);
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
                    if (Convert.ToInt32(this.txtRutProveedor.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese rut proveedor", "Sistema");
                        this.txtRutProveedor.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreProveedor.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre del proveedor", "Sistema");
                        this.txtNombreProveedor.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtComuna.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese comuna del proveedor", "Sistema");
                        this.txtComuna.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtCiudad.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese ciudad del proveedor", "Sistema");
                        this.txtCiudad.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNumero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese numero de contacto del proveedor", "Sistema");
                        this.txtNumero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtDireccion.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese dirección del proveedor", "Sistema");
                        this.txtDireccion.Focus();
                        return;
                    }

                    ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient auxServicio = new ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient();
                    ServiceMantenedorProveedor.proveedor auxProv = new ServiceMantenedorProveedor.proveedor();
                    auxProv.Rut_prov = this.txtRutProveedor.Text;
                    auxProv.Nombre_prov = this.txtNombreProveedor.Text;
                    auxProv.Comuna_prov = this.txtComuna.Text;
                    auxProv.Ciudad_prov = this.txtCiudad.Text;
                    auxProv.Numero_prov = int.Parse(this.txtNumero.Text);
                    auxProv.Direccion_prov = this.txtDireccion.Text;
                    if(ValidaRut(txtRutProveedor.Text) == true)
                    {
                        auxServicio.webGuardarTransaccionProveedor(auxProv);
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
                        this.txtRutProveedor.Focus();
                    }
                    

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos No Guardados " + ex.Message, "Mensaje Sistema");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnActualizar.Text.Equals("Actualizar"))
                {
                    this.habilitar();
                    this.txtRutProveedor.Enabled = false;
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
                    if (Convert.ToInt32(this.txtRutProveedor.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese rut proveedor", "Sistema");
                        this.txtRutProveedor.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreProveedor.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre del proveedor", "Sistema");
                        this.txtNombreProveedor.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtComuna.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese comuna del proveedor", "Sistema");
                        this.txtComuna.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtCiudad.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese ciudad del proveedor", "Sistema");
                        this.txtCiudad.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNumero.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese numero de contacto del proveedor", "Sistema");
                        this.txtNumero.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtDireccion.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese dirección del proveedor", "Sistema");
                        this.txtDireccion.Focus();
                        return;
                    }

                    ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient auxServicio = new ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient();
                    ServiceMantenedorProveedor.proveedor auxProv = new ServiceMantenedorProveedor.proveedor();
                    auxProv.Rut_prov = this.txtRutProveedor.Text;
                    auxProv.Nombre_prov = this.txtNombreProveedor.Text;
                    auxProv.Comuna_prov = this.txtComuna.Text;
                    auxProv.Ciudad_prov = this.txtCiudad.Text;
                    auxProv.Numero_prov = int.Parse(this.txtNumero.Text);
                    auxProv.Direccion_prov = this.txtDireccion.Text;

                    auxServicio.webActualizarProveedor(auxProv);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
                DialogResult dr = MessageBox.Show("Esta seguro que desea eliminar el proveedor seleccionado", "Alerta", botones,
                    MessageBoxIcon.Question);

                if(dr == DialogResult.Yes)
                {
                    ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient auxServicio = new ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient();
                    auxServicio.webEliminarProveedor(this.txtRutProveedor.Text);
                    MessageBox.Show("Proveedor eliminado", "Mensaje Sistema");
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            PantallaListarProveedor plistar = new PantallaListarProveedor();
            plistar.ShowDialog();
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
                this.btnActualizar.Text = "Actualizar";
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

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            this.Posicion = 0;
            this.mostrar();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Posicion - 1;
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

        private void PantallaMantenedorProveedor_Load(object sender, EventArgs e)
        {
            this.txtPosicion.Enabled = false;
            this.Posicion = 0;
            this.mostrar();
        }

        private void deshabilitar()
        {
            this.txtRutProveedor.Enabled = false;
            this.txtNombreProveedor.Enabled = false;
            this.txtComuna.Enabled = false;
            this.txtCiudad.Enabled = false;
            this.txtNumero.Enabled = false;
            this.txtDireccion.Enabled = false;
        }

        private void habilitar()
        {
            this.txtRutProveedor.Enabled = true;
            this.txtNombreProveedor.Enabled = true;
            this.txtComuna.Enabled = true;
            this.txtCiudad.Enabled = true;
            this.txtNumero.Enabled = true;
            this.txtDireccion.Enabled = true;
        }

        private void Limpiar()
        {
            this.txtRutProveedor.Text = String.Empty;
            this.txtNombreProveedor.Text = String.Empty;
            this.txtComuna.Text = String.Empty;
            this.txtCiudad.Text = String.Empty;
            this.txtNumero.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
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

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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
