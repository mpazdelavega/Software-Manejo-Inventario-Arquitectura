using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDTO;
using CapaConexion;
using CapaNegocio;
using System.Globalization;
using System.Threading;

namespace CapaGUI
{
    public partial class PantallaMantenedorProducto : Form
    {
        private int posicion;
        private int ultimo;
        private String condicion;
        

        public string Condicion { get => condicion; set => condicion = value; }

        public int Posicion { get => posicion; set => posicion = value; }
        public int Ultimo { get => ultimo; set => ultimo = value; }
        public PantallaMantenedorProducto()
        {
            InitializeComponent();
            this.txtCodigoProducto.MaxLength = 12;
            this.txtNombreProducto.MaxLength = 25;
            this.txtEspecificaciones.MaxLength = 50;
            this.txtPrecioUnitario.MaxLength = 7;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(btnSalir.Text.Equals("Salir"))
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

        public void mostrar()
        {
            
            ServiceMantenedorProducto.productos auxProductos = new ServiceMantenedorProducto.productos();
            ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();

            this.Ultimo = auxServicio.WebConsultaProductos().Tables[0].Rows.Count - 1;

            if (this.Posicion < 0)
                this.Posicion = 0;
            if (this.Posicion > this.Ultimo)
                this.Posicion = this.Ultimo;
            auxProductos = auxServicio.WebPosicionProducto(this.Posicion);

            this.txtCodigoProducto.Text = auxProductos.Cod_producto;
            this.txtNombreProducto.Text = auxProductos.Nom_producto;
            this.nmcCantidad.Text = Convert.ToString(auxProductos.Cantidad);
            this.txtEspecificaciones.Text = auxProductos.Especificaciones;
            this.cmbBodega.Text = auxProductos.Codigo_bodega;
            this.cmbBodeguero.Text = auxProductos.Rut_bodeguero;
            this.cmbProveedor.Text = auxProductos.Rut_prov;
            this.txtPrecioUnitario.Text = Convert.ToString(auxProductos.Precio_unitario);
            if (Convert.ToString(auxProductos.Condicion) == "Nuevo")
            {
                this.rbtNuevo.Checked = true;
            }
            else
            {
                this.rbtUsado.Checked = true;
            }
            if(this.Ultimo < 0)
            {
                this.dtpFechaIngreso.Value = DateTime.Now;
            }
            else
            {
                this.dtpFechaIngreso.Value = auxProductos.Fecha_ingreso;
            }
            
            this.txtPosicion.Text = (this.Posicion + 1) + " - "
                                    + (this.Ultimo + 1);

        }

        

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Posicion + 1;
            this.mostrar();
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

        private void btoUltimo_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Ultimo;
            this.mostrar();
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
                    this.cmbBodega.SelectedIndex = -1;
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
                    if (Convert.ToInt32(this.txtCodigoProducto.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese codigo", "Sistema");
                        this.txtCodigoProducto.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreProducto.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre del producto", "Sistema");
                        this.txtNombreProducto.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.nmcCantidad.Text) == 0)
                    {
                        MessageBox.Show("Ingrese cantidad", "Sistema");
                        this.nmcCantidad.Focus();
                        return;
                    }
                    if (cmbBodega.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe asignar una bodega", "Sistema");
                        this.cmbBodega.Focus();
                        return;
                    }
                    if (rbtNuevo.Checked == false && rbtUsado.Checked == false)
                    {
                        MessageBox.Show("Ingrese condición del producto", "Sistema");
                        return;
                    }
                    if (Convert.ToInt32(this.cmbProveedor.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre proveedor", "Sistema");
                        this.cmbProveedor.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtPrecioUnitario.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese precio unitario del producto", "Sistema");
                        this.txtPrecioUnitario.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtEspecificaciones.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese especificaciones del producto", "Sistema");
                        this.txtEspecificaciones.Focus();
                        return;
                    }
                    if (rbtNuevo.Checked == true)
                    {
                        this.condicion = "Nuevo";
                    }
                    else
                    {
                        this.condicion = "Usado";
                    }
                    if (cmbBodeguero.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe registrar tu nombre", "Sistema");
                        this.cmbBodeguero.Focus();
                        return;
                    }

                    ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
                    ServiceMantenedorProducto.productos auxReg = new ServiceMantenedorProducto.productos();
                    auxReg.Cod_producto = this.txtCodigoProducto.Text;
                    auxReg.Nom_producto = this.txtNombreProducto.Text;
                    auxReg.Fecha_ingreso = this.dtpFechaIngreso.Value;
                    auxReg.Cantidad = int.Parse(this.nmcCantidad.Text);
                    auxReg.Rut_prov = Convert.ToString(this.cmbProveedor.SelectedValue);
                    auxReg.Precio_unitario = int.Parse(this.txtPrecioUnitario.Text);
                    auxReg.Especificaciones = this.txtEspecificaciones.Text;
                    auxReg.Condicion = this.condicion;
                    auxReg.Codigo_bodega = Convert.ToString(this.cmbBodega.SelectedValue);
                    auxReg.Rut_bodeguero = Convert.ToString(this.cmbBodeguero.SelectedValue);

                    auxServicio.WebGuardarTransaccion(auxReg);
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
                DialogResult dr = MessageBox.Show("Esta seguro que desea eliminar al producto seleccionado", "Alerta", botones,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
                    auxServicio.WebEliminarProducto(this.txtCodigoProducto.Text);
                    MessageBox.Show("Producto eliminado", "Mensaje Sistema");
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
                    this.cmbBodega.Enabled = false;
                    this.cmbProveedor.Enabled = false;
                    this.cmbBodeguero.Enabled = false;
                    this.dtpFechaIngreso.Enabled = false;
                    this.txtCodigoProducto.Enabled = false;
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
                    if (Convert.ToInt32(this.txtCodigoProducto.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese codigo", "Sistema");
                        this.txtCodigoProducto.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreProducto.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre del producto", "Sistema");
                        this.txtNombreProducto.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.nmcCantidad.Text) == 0)
                    {
                        MessageBox.Show("Ingrese cantidad", "Sistema");
                        this.nmcCantidad.Focus();
                        return;
                    }
                    //if (cmbBodega.SelectedIndex == -1)
                    //{
                    //    MessageBox.Show("Debe asignar una bodega", "Sistema");
                    //    this.cmbBodega.Focus();
                    //    return;
                    //}
                    if (rbtNuevo.Checked == false && rbtUsado.Checked == false)
                    {
                        MessageBox.Show("Ingrese condición del producto", "Sistema");
                        return;
                    }
                    //if (Convert.ToInt32(this.cmbProveedor.Text.Length) == 0)
                    //{
                    //    MessageBox.Show("Ingrese nombre proveedor", "Sistema");
                    //    this.cmbProveedor.Focus();
                    //    return;
                    //}
                    if (Convert.ToInt32(this.txtPrecioUnitario.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese precio unitario del producto", "Sistema");
                        this.txtPrecioUnitario.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtEspecificaciones.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese especificaciones del producto", "Sistema");
                        this.txtEspecificaciones.Focus();
                        return;
                    }
                    if (rbtNuevo.Checked == true)
                    {
                        this.condicion = "Nuevo";
                    }
                    else
                    {
                        this.condicion = "Usado";
                    }
                    //if (cmbBodeguero.SelectedIndex == -1)
                    //{
                    //    MessageBox.Show("Debe registrar tu nombre", "Sistema");
                    //    this.cmbBodeguero.Focus();
                    //    return;
                    //}
                    //DateTime fecha = (DateTime)this.dtpFechaIngreso.Value;

                    ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
                    ServiceMantenedorProducto.productos auxProductos = new ServiceMantenedorProducto.productos();
                    auxProductos.Cod_producto = this.txtCodigoProducto.Text;
                    auxProductos.Nom_producto = this.txtNombreProducto.Text;

                    //auxProductos.Fecha_ingreso = this.dtpFechaIngreso.Value;
                    auxProductos.Cantidad = int.Parse(this.nmcCantidad.Text);
                    auxProductos.Rut_prov = Convert.ToString(this.cmbProveedor.SelectedValue);
                    auxProductos.Precio_unitario = int.Parse(this.txtPrecioUnitario.Text);
                    auxProductos.Especificaciones = this.txtEspecificaciones.Text;
                    auxProductos.Condicion = this.condicion;
                    auxProductos.Codigo_bodega = Convert.ToString(this.cmbBodega.SelectedValue);
                    auxProductos.Rut_bodeguero = Convert.ToString(this.cmbBodeguero.SelectedValue);

                    auxServicio.WebActualizarProducto(auxProductos);
                    MessageBox.Show("Datos Actualizados", "Mensaje Sistema");

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

        private void habilitar()
        {
            this.txtCodigoProducto.Enabled = true;
            this.txtNombreProducto.Enabled = true;
            this.dtpFechaIngreso.Enabled = true;
            this.nmcCantidad.Enabled = true;
            this.cmbBodega.Enabled = true;
            this.cmbProveedor.Enabled = true;
            this.cmbProveedor.Enabled = true;
            this.txtEspecificaciones.Enabled = true;
            this.txtPrecioUnitario.Enabled = true;
            this.cmbBodeguero.Enabled = true;
            this.rbtNuevo.Enabled = true;
            this.rbtUsado.Enabled = true;

        }

        private void deshabilitar()
        {
            this.txtCodigoProducto.Enabled = false;
            this.txtNombreProducto.Enabled = false;
            this.dtpFechaIngreso.Enabled = false;
            this.nmcCantidad.Enabled = false;
            this.cmbBodega.Enabled = false;
            this.cmbProveedor.Enabled = false;
            this.txtEspecificaciones.Enabled = false;
            this.txtPrecioUnitario.Enabled = false;
            this.cmbBodeguero.Enabled = false;
            this.rbtNuevo.Enabled = false;
            this.rbtUsado.Enabled = false;
        }

        private void Limpiar()
        {
            this.txtCodigoProducto.Text = String.Empty;
            this.txtNombreProducto.Text = String.Empty;
            this.nmcCantidad.Text = "0";
            this.cmbProveedor.SelectedIndex = -1;
            this.txtPrecioUnitario.Text = String.Empty;
            this.rbtNuevo.Checked = false;
            this.rbtUsado.Checked = false;
            this.txtEspecificaciones.Text = String.Empty;
            this.cmbBodega.SelectedIndex = -1;
            this.cmbBodeguero.SelectedIndex = -1;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            PantallaListarProducto pListar = new PantallaListarProducto();
            pListar.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PantallaMantenedorProducto_Load(object sender, EventArgs e)
        {
            this.txtPosicion.Enabled = false;
            this.Posicion = 0;
            this.mostrar();
            //Cargar datos combobox bodega (CAPA GUI / EVENTO LOAD)
            cmbBodega.DataSource = NegocioRegistro.cargarDatos();
            cmbBodega.ValueMember = "codigo_bodega";
            cmbBodega.DisplayMember = "nombre_bodega";
            //Cargar datos combobox proveedor
            cmbProveedor.DataSource = NegocioProveedor.cargarDatosP();
            cmbProveedor.DisplayMember = "nombre_prov";
            cmbProveedor.ValueMember = "rut_prov";
            //Cargar datos combobox Bodeguero
            cmbBodeguero.DataSource = NegocioBodeguero.cargarDatosBodeguero();
            cmbBodeguero.DisplayMember = "nombre_bodeguero";
            cmbBodeguero.ValueMember = "rut_bodeguero";

        }
    }
}
