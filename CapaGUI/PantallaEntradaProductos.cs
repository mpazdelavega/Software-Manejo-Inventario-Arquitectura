using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaDTO;

namespace CapaGUI
{
    public partial class PantallaEntradaProductos : Form
    {
        public PantallaEntradaProductos()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtCodigoProd.Text))
                {
                    MessageBox.Show("Ingrese codigo", "Sistema");
                    this.txtCodigoProd.Focus();
                    return;
                }
                if (Convert.ToInt32(this.nmcCantidad.Text) == 0)
                {
                    MessageBox.Show("Ingrese cantidad", "Sistema");
                    this.nmcCantidad.Focus();
                    return;
                }
                if (Convert.ToInt32(this.nmcCantidad.Text) < 0)
                {
                    MessageBox.Show("Cantidad ingresada no valida, porfavor ingresa una cantidad no negativa", "Sistema");
                    this.nmcCantidad.Focus();
                    return;
                }
                ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
                ServiceMantenedorProducto.productos auxP = new ServiceMantenedorProducto.productos();
                auxP.Cod_producto = this.txtCodigoProd.Text;
                auxP.Cantidad = int.Parse(this.nmcCantidad.Text);

                auxServicio.WebEntradaProducto(auxP);
                MessageBox.Show("Stock actualizado satisfactoriamente", "Mensaje Sistema");
                this.txtCodigoProd.Text = String.Empty;
                this.nmcCantidad.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Mensaje Sistema");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
            this.dtgListaProductos.DataSource = auxServicio.WebListaProducto();
            this.dtgListaProductos.DataMember = "Productos";
        }
    }
}
