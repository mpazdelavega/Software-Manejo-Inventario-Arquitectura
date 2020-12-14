using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class PantallaListarProducto : Form
    {
        public PantallaListarProducto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.GC.Collect();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient auxServicio = new ServiceMantenedorProducto.WebServiceMantenedorProductoSoapClient();
            this.dtgListar.DataSource = auxServicio.WebConsultaProductos();
            this.dtgListar.DataMember = "productos";
        }
    }
}
