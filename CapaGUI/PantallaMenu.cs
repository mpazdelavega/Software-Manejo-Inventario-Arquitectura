using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaConexion;
using CapaDTO;

namespace CapaGUI
{
    public partial class PantallaMenu : Form
    {
        public PantallaMenu()
        {
            InitializeComponent();
        }

        private void entradaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaLogin pLog = new PantallaLogin();
            pLog.ShowDialog();
            this.Close();
        }

        private void salidaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaSalidaProductos pSal = new PantallaSalidaProductos();
            pSal.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaMantenedorProducto PMP = new PantallaMantenedorProducto();
            PMP.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaMantenedorProveedor PMP = new PantallaMantenedorProveedor();
            PMP.ShowDialog();
        }

        private void bodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaMantenedorBodega PMB = new PantallaMantenedorBodega();
            PMB.ShowDialog();
        }

        private void bodegueroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaMantenedorBodeguero PMB = new PantallaMantenedorBodeguero();
            PMB.ShowDialog();
        }

        private void registrarSalidaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaSalidaProductos pSalida = new PantallaSalidaProductos();
            pSalida.ShowDialog();
        }

        private void registrarEntradaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaEntradaProductos pEntrada = new PantallaEntradaProductos();
            pEntrada.ShowDialog();
        }
    }
}
