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
    public partial class PantallaListarBodega : Form
    {
        public PantallaListarBodega()
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
            ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient auxServicio = new ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient();
            this.dtgListar.DataSource = auxServicio.webConsultaBodega();
            this.dtgListar.DataMember = "bodega";
        }
    }
}
