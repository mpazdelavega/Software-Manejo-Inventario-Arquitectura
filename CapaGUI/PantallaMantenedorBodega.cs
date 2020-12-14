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
using CapaNegocio;

namespace CapaGUI
{
    public partial class PantallaMantenedorBodega : Form
    {
        private int posicion;
        private int ultimo;

        public int Posicion { get => posicion; set => posicion = value; }
        public int Ultimo { get => ultimo; set => ultimo = value; }
        public PantallaMantenedorBodega()
        {
            InitializeComponent();
            this.txtCodigoBodega.MaxLength = 10;
            this.txtNombreBodega.MaxLength = 25;
        }

        public void mostrar()
        {
            ServiceMantenedorBodega.bodega auxBodega = new ServiceMantenedorBodega.bodega();
            ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient auxServicio = new ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient();

            this.Ultimo = auxServicio.webConsultaBodega().Tables[0].Rows.Count - 1;

            if (this.Posicion < 0)
                this.Posicion = 0;
            if (this.Posicion > this.Ultimo)
                this.Posicion = this.Ultimo;

            auxBodega = auxServicio.webPosicionBodega(this.Posicion);

            this.txtCodigoBodega.Text = auxBodega.Codigo_bodega;
            this.txtNombreBodega.Text = auxBodega.Nombre_bodega;

            this.txtPosicion.Text = (this.Posicion + 1) + " - "
                                    + (this.Ultimo + 1);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            PantallaListarBodega pListar = new PantallaListarBodega();
            pListar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
                DialogResult dr = MessageBox.Show("¿Esta seguro que desea eliminar la bodega seleccionada?", "Alerta", botones,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient auxServicio = new ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient();
                    auxServicio.webEliminarBodega(this.txtCodigoBodega.Text);
                    MessageBox.Show("Bodega eliminada", "Mensaje Sistema");
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
                    this.btnActualizar.Text = "Aceptar";
                    this.btnSalir.Text = "Atras";
                    this.txtCodigoBodega.Enabled = false;
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
                    if (Convert.ToInt32(this.txtCodigoBodega.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese codigo de la bodega", "Sistema");
                        this.txtCodigoBodega.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreBodega.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre de la bodega", "Sistema");
                        this.txtNombreBodega.Focus();
                        return;
                    }

                    ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient auxServicio = new ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient();
                    ServiceMantenedorBodega.bodega auxBodega = new ServiceMantenedorBodega.bodega();
                    auxBodega.Codigo_bodega = this.txtCodigoBodega.Text;
                    auxBodega.Nombre_bodega = this.txtNombreBodega.Text;


                    auxServicio.webActualizarBodega(auxBodega);
                    MessageBox.Show("Datos Actualizados", "Mensaje Sistema");

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
                    if (Convert.ToInt32(this.txtCodigoBodega.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese codigo de la bodega", "Sistema");
                        this.txtCodigoBodega.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtNombreBodega.Text.Length) == 0)
                    {
                        MessageBox.Show("Ingrese nombre de la bodega", "Sistema");
                        this.txtNombreBodega.Focus();
                        return;
                    }
                    
                    ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient auxServicio = new ServiceMantenedorBodega.WebServiceMantenedorBodegaSoapClient();
                    ServiceMantenedorBodega.bodega auxBodega = new ServiceMantenedorBodega.bodega();
                    auxBodega.Codigo_bodega = this.txtCodigoBodega.Text;
                    auxBodega.Nombre_bodega = this.txtNombreBodega.Text;


                    auxServicio.webGuardarTransaccionBodega(auxBodega);
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

        private void deshabilitar()
        {
            this.txtCodigoBodega.Enabled = false;
            this.txtNombreBodega.Enabled = false;
        }

        private void habilitar()
        {
            this.txtCodigoBodega.Enabled = true;
            this.txtNombreBodega.Enabled = true;
        }

        private void Limpiar()
        {
            this.txtCodigoBodega.Text = String.Empty;
            this.txtNombreBodega.Text = String.Empty;
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

        private void btoUltimo_Click(object sender, EventArgs e)
        {
            this.Posicion = this.Ultimo;
            this.mostrar();
        }

        private void PantallaMantenedorBodega_Load(object sender, EventArgs e)
        {
            this.txtPosicion.Enabled = false;
            this.Posicion = 0;
            this.mostrar();
        }
    }
}
