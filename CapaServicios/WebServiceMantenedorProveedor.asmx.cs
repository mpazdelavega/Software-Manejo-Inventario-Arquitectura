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
    /// Descripción breve de WebServiceMantenedorProveedor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceMantenedorProveedor : System.Web.Services.WebService
    {

        [WebMethod]
        public void webGuardarTransaccionProveedor(proveedor prov)
        {
            NegocioProveedor auxNegocio = new NegocioProveedor();
            auxNegocio.GuardarTransaccionProveedor(prov);
        }

        [WebMethod]
        public void webActualizarProveedor(proveedor prov)
        {
            NegocioProveedor auxNegocio = new NegocioProveedor();
            auxNegocio.ActualizarProveedor(prov);
        }

        [WebMethod]
        public void webEliminarProveedor(String rut_prov)
        {
            NegocioProveedor auxNegocio = new NegocioProveedor();
            auxNegocio.eliminarProveedor(rut_prov);
        }

        [WebMethod]
        public DataSet webConsultaProveedor()
        {
            NegocioProveedor auxNegocio = new NegocioProveedor();
            return auxNegocio.consultaProveedor();
        }

        [WebMethod]
        public proveedor webPosicionProveedor(int pos)
        {
            NegocioProveedor auxNegocio = new NegocioProveedor();
            return auxNegocio.posicionProveedor(pos);
        }
    }
}
