using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaDTO;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CapaNegocio
{
    public class NegocioBodega
    {
        private ConexionSQL conect1;

        public ConexionSQL Conect1 { get => conect1; set => conect1 = value; }

        public void configurarConexion()
        {
            this.conect1 = new ConexionSQL();
            this.conect1.NombreBaseDatos = "inventario";
            this.conect1.NombreTabla = "bodega";
            this.conect1.CadenaConexion = "Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True";
        }
        //Web Listo
        public DataSet consultaBodega()
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "Select * from bodega";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            return this.conect1.DbDataSet;
        }
        //Web Listo
        public bodega posicionBodega(int pos)
        {
            bodega auxBodega = new bodega();
            this.configurarConexion();
            this.conect1.CadenaSQL = "SELECT * FROM bodega";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            DataTable dt = new DataTable();
            dt = this.Conect1.DbDataSet.Tables[0];

            if (dt.Rows.Count > 0 && (pos <= (dt.Rows.Count - 1)) && (pos >= 0))
            {
                auxBodega.Codigo_bodega = (String)dt.Rows[pos]["codigo_bodega"];
                auxBodega.Nombre_bodega = (String)dt.Rows[pos]["nombre_bodega"];

            }
            else
            {
                auxBodega.Codigo_bodega = String.Empty;
                auxBodega.Nombre_bodega = String.Empty;
            }
            return auxBodega;

        }
        //Web Listo
        public void GuardarTransaccionBodega(bodega bod)
        {

            this.configurarConexion();
            this.conect1.CadenaSQL = " INSERT INTO " + this.conect1.NombreTabla
                                        + " (codigo_bodega,nombre_bodega) "
                                        +
                                        "VALUES ('" + bod.Codigo_bodega + "','" 
                                                    + bod.Nombre_bodega + "');";
            this.conect1.EsSelect = false;
            this.conect1.conectar();


        }
        //Web Listo
        public void actualizarBodega(bodega bodega)
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "UPDATE bodega SET nombre_bodega = '" + bodega.Nombre_bodega + "'"
                                                             + " WHERE codigo_bodega = '" + bodega.Codigo_bodega + "';";
            this.conect1.EsSelect = false;
            this.conect1.conectar();

        }
        //Web Listo
        public void eliminarBodega(String codigo_bodega)
        {
            this.configurarConexion();
            this.Conect1.CadenaSQL = "DELETE FROM bodega "
                                    + " WHERE codigo_bodega = '" + codigo_bodega + "';";
            this.Conect1.EsSelect = false;
            this.Conect1.conectar();

        }
    }
}
