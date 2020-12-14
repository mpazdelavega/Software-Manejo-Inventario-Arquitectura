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
    public class NegocioProveedor
    {
        private ConexionSQL conect1;

        public ConexionSQL Conect1 { get => conect1; set => conect1 = value; }

        public void configurarConexion()
        {
            this.conect1 = new ConexionSQL();
            this.conect1.NombreBaseDatos = "inventario";
            this.conect1.NombreTabla = "proveedor";
            this.conect1.CadenaConexion = "Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True";
        }
        //Web Pendiente
        public static List<proveedor> cargarDatosP()
        {
            var lista = new List<proveedor>();
            using (var con = new SqlConnection("Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True"))
            {
                con.Open();
                const String consulta = "Select rut_prov, nombre_prov from proveedor";
                var cmd = new SqlCommand(consulta, con);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    var entidad = new proveedor();
                    entidad.Nombre_prov = Convert.ToString(lector[1]);
                    entidad.Rut_prov = Convert.ToString(lector[0]);
                    lista.Add(entidad);
                }
                return lista;
            }
        }
        //Web Listo
        public DataSet consultaProveedor()
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "Select * from proveedor";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            return this.conect1.DbDataSet;
        }
        //Web Listo
        public proveedor posicionProveedor(int pos)
        {
            proveedor auxProveedor = new proveedor();
            this.configurarConexion();
            this.conect1.CadenaSQL = "SELECT * FROM proveedor";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            DataTable dt = new DataTable();
            dt = this.Conect1.DbDataSet.Tables[0];

            if (dt.Rows.Count > 0 && (pos <= (dt.Rows.Count - 1)) && (pos >= 0))
            {
                auxProveedor.Rut_prov = (String)dt.Rows[pos]["rut_prov"];
                auxProveedor.Nombre_prov = (String)dt.Rows[pos]["nombre_prov"];
                auxProveedor.Comuna_prov = (String)dt.Rows[pos]["comuna_prov"];
                auxProveedor.Ciudad_prov = (String)dt.Rows[pos]["ciudad_prov"];
                auxProveedor.Numero_prov = (int)dt.Rows[pos]["numero_prov"];
                auxProveedor.Direccion_prov = (String)dt.Rows[pos]["direccion_prov"];
            }
            else
            {
                auxProveedor.Rut_prov = String.Empty;
                auxProveedor.Nombre_prov = String.Empty;
                auxProveedor.Comuna_prov = String.Empty;
                auxProveedor.Ciudad_prov = String.Empty;
                auxProveedor.Numero_prov = 0;
                auxProveedor.Direccion_prov = String.Empty;
            }
            return auxProveedor;

        }
        //Web Listo
        public void GuardarTransaccionProveedor(proveedor prov)
        {

            this.configurarConexion();
            this.conect1.CadenaSQL = " INSERT INTO " + this.conect1.NombreTabla
                                        + " (rut_prov,nombre_prov,comuna_prov,ciudad_prov,numero_prov,direccion_prov) "
                                        +
                                        "VALUES ('"+prov.Rut_prov+"','"+prov.Nombre_prov+"','"+prov.Comuna_prov+"','"+prov.Ciudad_prov+"','"+prov.Numero_prov+"','"+prov.Direccion_prov+"');";
            this.conect1.EsSelect = false;
            this.conect1.conectar();


        }
        //Web Listo
        public void ActualizarProveedor(proveedor prov)
        {

            this.configurarConexion();
            this.conect1.CadenaSQL = "UPDATE proveedor SET nombre_prov = '" + prov.Nombre_prov + "',"
                                                            + " comuna_prov = '" + prov.Comuna_prov + "',"
                                                             + " ciudad_prov = '" + prov.Ciudad_prov + "',"
                                                             + " numero_prov = '" + prov.Numero_prov + "',"
                                                             + " direccion_prov = '" + prov.Direccion_prov + "'"
                                                             + " WHERE rut_prov = '" + prov.Rut_prov + "';";
            this.conect1.EsSelect = false;
            this.conect1.conectar();


        }
        //Web Listo
        public void eliminarProveedor(String rut_prov)
        {
            this.configurarConexion();
            this.Conect1.CadenaSQL = "DELETE FROM proveedor "
                                    + " WHERE rut_prov = '" + rut_prov + "';";
            this.Conect1.EsSelect = false;
            this.Conect1.conectar();

        }


    }
}
