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
    /// Descripción breve de WebServiceMantenedorBodega
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceMantenedorBodega : System.Web.Services.WebService
    {

        [WebMethod]
        public void webGuardarTransaccionBodega(bodega bod)
        {
            NegocioBodega auxNegocio = new NegocioBodega();
            auxNegocio.GuardarTransaccionBodega(bod);
        }

        [WebMethod]
        public void webActualizarBodega(bodega bodega)
        {
            NegocioBodega auxNegocio = new NegocioBodega();
            auxNegocio.actualizarBodega(bodega);
        }

        [WebMethod]
        public void webEliminarBodega(String codigo_bodega)
        {
            NegocioBodega auxNegocio = new NegocioBodega();
            auxNegocio.eliminarBodega(codigo_bodega);
        }

        [WebMethod]
        public DataSet webConsultaBodega()
        {
            NegocioBodega auxNegocio = new NegocioBodega();
            return auxNegocio.consultaBodega();
        }

        [WebMethod]
        public bodega webPosicionBodega(int pos)
        {
            NegocioBodega auxNegocio = new NegocioBodega();
            return auxNegocio.posicionBodega(pos);
        }
        

    }
}
