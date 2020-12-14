using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaDTO;
using CapaNegocio;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceMantenedorProducto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceMantenedorProducto : System.Web.Services.WebService
    {

        [WebMethod]
        public void WebGuardarTransaccion(productos registro)
        {
            NegocioRegistro auxNegocio = new NegocioRegistro();
            auxNegocio.GuardarTransaccion(registro);
        }

        [WebMethod]
        public DataSet WebConsultaProductos()
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            return auxProducto.consultaProductos();
        }

        [WebMethod]
        public DataSet WebListaProducto()
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            return auxProducto.listaProducto();
        }

        [WebMethod]
        public void WebEliminarProducto(String cod_producto)
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            auxProducto.eliminarProducto(cod_producto);
        }

        [WebMethod]
        public void WebActualizarProducto(productos producto)
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            auxProducto.actualizarProducto(producto);
        }

        [WebMethod]
        public productos WebPosicionProducto(int pos)
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            return auxProducto.posicionProducto(pos);
        }

        [WebMethod]
        public void WebEntradaProducto(productos registro)
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            auxProducto.entradaProducto(registro);
        }

        [WebMethod]
        public void WebSalidaProducto(productos registro)
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            auxProducto.salidaProducto(registro);
        }

        [WebMethod]
        public static List<bodega> WebCargarDatos()
        {
            return NegocioRegistro.cargarDatos();
        }

        [WebMethod]
        public Boolean WebLogin(login login)
        {
            NegocioRegistro auxProducto = new NegocioRegistro();
            return auxProducto.Login(login);
        }

    }
}
