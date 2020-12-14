using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;
using CapaDTO;
using System.Data;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceMantenedorBodeguero
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceMantenedorBodeguero : System.Web.Services.WebService
    {

        [WebMethod]
        public void webGuardarTransaccionBodeguero(bodeguero bod)
        {
            NegocioBodeguero auxNegocio = new NegocioBodeguero();
            auxNegocio.GuardarTransaccionBodeguero(bod);
        }

        [WebMethod]
        public void webActualizarBodeguero(bodeguero bodeguero)
        {
            NegocioBodeguero auxNegocio = new NegocioBodeguero();
            auxNegocio.actualizarBodeguero(bodeguero);
        }

        [WebMethod]
        public void webEliminarBodeguero(String rut_bodeguero)
        {
            NegocioBodeguero auxNegocio = new NegocioBodeguero();
            auxNegocio.eliminarBodeguero(rut_bodeguero);
        }

        [WebMethod]
        public bodeguero webPosicionBodeguero(int pos)
        {
            NegocioBodeguero auxNegocio = new NegocioBodeguero();
            return auxNegocio.posicionBodeguero(pos);
        }

        [WebMethod]
        public DataSet webConsultaBodeguero()
        {
            NegocioBodeguero auxNegocio = new NegocioBodeguero();
            return auxNegocio.consultaBodeguero();
        }
    }
}
