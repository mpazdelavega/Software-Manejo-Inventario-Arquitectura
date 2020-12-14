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

namespace CapaGUI
{
    public partial class PantallaListarProveedor : Form
    {
        public PantallaListarProveedor()
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
            ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient auxServicio = new ServiceMantenedorProveedor.WebServiceMantenedorProveedorSoapClient();
            this.dtgListar.DataSource = auxServicio.webConsultaProveedor();
            this.dtgListar.DataMember = "proveedor";
        }
    }

    
}
