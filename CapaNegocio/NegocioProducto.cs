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
    public class NegocioRegistro
    {
        private ConexionSQL conect1;

        public ConexionSQL Conect1 { get => conect1; set => conect1 = value; }

        public void configurarConexion()
        {
            this.conect1 = new ConexionSQL();
            this.conect1.NombreBaseDatos = "inventario";
            this.conect1.NombreTabla = "productos";
            this.conect1.CadenaConexion = "Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True";
        }
        //Web listo
        public Boolean Login(login login)
        {

            this.configurarConexion();
            this.conect1.CadenaSQL = "Select Count(*) From login where usuario='" + login.Usuario + "' and contrasena ='" + login.Contrasena + "'";
            this.Conect1.EsSelect = true;
            this.Conect1.conectar();
            DataTable dt = new DataTable();
            dt = this.Conect1.DbDataSet.Tables[0];
            if (dt.Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static List<bodega> cargarDatos()
        {
            var lista = new List<bodega>();
            using (var con = new SqlConnection("Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True"))
            {
                
                con.Open();
                const String consulta = "Select * from bodega";
                var cmd = new SqlCommand(consulta, con);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    var entidad = new bodega();
                    entidad.Nombre_bodega = Convert.ToString(lector[1]);
                    entidad.Codigo_bodega = Convert.ToString(lector[0]);
                    lista.Add(entidad);
                }
                return lista;
            }    
        }
        
        public void salidaProducto(productos registro)
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "UPDATE Productos SET cantidad = cantidad -'" + registro.Cantidad
                                    + "' WHERE cod_producto = '" + registro.Cod_producto + "';";
            this.conect1.EsSelect = false;
            this.conect1.conectar();
        }
        
        public void entradaProducto(productos registro)
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "UPDATE Productos SET cantidad = cantidad +'" + registro.Cantidad
                                    + "' WHERE cod_producto = '" + registro.Cod_producto + "';";
            this.conect1.EsSelect = false;
            this.conect1.conectar();
        }
        
        public void GuardarTransaccion(productos registro)
        {

            this.configurarConexion();
            this.conect1.CadenaSQL = " INSERT INTO " + this.conect1.NombreTabla
                                        + " (cod_producto,nom_producto,fecha_ingreso,cantidad,rut_prov,precio_unitario,especificaciones,condicion,codigo_bodega,rut_bodeguero) "
                                        +
                                        "VALUES ('"
                                                + registro.Cod_producto + "','"
                                                + registro.Nom_producto + "','"
                                                + registro.Fecha_ingreso + "','"
                                                + registro.Cantidad + "','"
                                                + registro.Rut_prov + "','"
                                                + registro.Precio_unitario + "','"
                                                + registro.Especificaciones + "','"
                                                + registro.Condicion + "','"
                                                + registro.Codigo_bodega + "','"
                                                + registro.Rut_bodeguero + "');";
            this.conect1.EsSelect = false;
            this.conect1.conectar();
            

        }
        
        public void actualizarProducto(productos producto)
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "UPDATE productos SET nom_producto = '" + producto.Nom_producto + "'," 
                                                            + " cantidad = " + producto.Cantidad + ","
                                                             //+ " rut_prov = '" + producto.Rut_prov + "',"
                                                             + " precio_unitario = " + producto.Precio_unitario + ","
                                                             + " especificaciones = '" + producto.Especificaciones + "',"
                                                             + " condicion = '" + producto.Condicion + "'"
                                                             //+ " codigo_bodega = '" + producto.Codigo_bodega + "'"
                                                             //+ " rut_bodeguero = '" + producto.Rut_bodeguero + "'"
                                                             + " WHERE cod_producto = '" + producto.Cod_producto + "';";
            this.conect1.EsSelect = false;
            this.conect1.conectar();

        }
        
        public void eliminarProducto(String cod_producto)
        {
            this.configurarConexion();
            this.Conect1.CadenaSQL = "DELETE FROM productos "
                                    + " WHERE cod_producto = '" + cod_producto + "';";
            this.Conect1.EsSelect = false;
            this.Conect1.conectar();

        }
        
        public DataSet listaProducto()
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "Select cod_producto, cantidad from productos";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            return this.conect1.DbDataSet;
        }
        
        public DataSet consultaProductos()
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "Select * from productos";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            return this.conect1.DbDataSet;
        }
       
        public productos posicionProducto(int pos)
        {
            productos auxProductos = new productos();
            this.configurarConexion();
            this.conect1.CadenaSQL = "SELECT * FROM productos";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            DataTable dt = new DataTable();
            dt = this.Conect1.DbDataSet.Tables[0];
            
            if(dt.Rows.Count > 0 && (pos <= (dt.Rows.Count - 1)) && (pos >=0))
            {
                auxProductos.Cod_producto = (String)dt.Rows[pos]["cod_producto"];
                auxProductos.Nom_producto = (String)dt.Rows[pos]["nom_producto"];
                auxProductos.Cantidad = (int)dt.Rows[pos]["cantidad"];
                auxProductos.Especificaciones = (String)dt.Rows[pos]["especificaciones"];
                auxProductos.Codigo_bodega = (String)dt.Rows[pos]["codigo_bodega"];
                auxProductos.Rut_bodeguero = (String)dt.Rows[pos]["rut_bodeguero"];
                auxProductos.Rut_prov = (String)dt.Rows[pos]["rut_prov"];
                auxProductos.Precio_unitario = (int)dt.Rows[pos]["precio_unitario"];
                auxProductos.Condicion = (String)dt.Rows[pos]["condicion"];
                auxProductos.Fecha_ingreso = (DateTime)dt.Rows[pos]["fecha_ingreso"];
            }
            else
            {
                auxProductos.Cod_producto = String.Empty;
                auxProductos.Nom_producto = String.Empty;
                auxProductos.Cantidad = 0;
            }

            return auxProductos;
        }

    }//Fin Clase
}//namespace
