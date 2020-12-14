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
    public class NegocioBodeguero
    {
        private ConexionSQL conect1;

        public ConexionSQL Conect1 { get => conect1; set => conect1 = value; }

        public void configurarConexion()
        {
            this.conect1 = new ConexionSQL();
            this.conect1.NombreBaseDatos = "inventario";
            this.conect1.NombreTabla = "bodeguero";
            this.conect1.CadenaConexion = "Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True";
        }
        //web listo
        public DataSet consultaBodeguero()
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "Select * from bodeguero";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            return this.conect1.DbDataSet;
        }
        //web listo
        public bodeguero posicionBodeguero(int pos)
        {
            bodeguero auxBodeguero = new bodeguero();
            this.configurarConexion();
            this.conect1.CadenaSQL = "SELECT * FROM bodeguero";
            this.conect1.EsSelect = true;
            this.conect1.conectar();
            DataTable dt = new DataTable();
            dt = this.Conect1.DbDataSet.Tables[0];

            if (dt.Rows.Count > 0 && (pos <= (dt.Rows.Count - 1)) && (pos >= 0))
            {
                auxBodeguero.Rut_bodeguero = (String)dt.Rows[pos]["rut_bodeguero"];
                auxBodeguero.Nombre_bodeguero = (String)dt.Rows[pos]["nombre_bodeguero"];
                auxBodeguero.Apellido_bodeguero = (String)dt.Rows[pos]["apellido_bodeguero"];
                auxBodeguero.Genero_bodeguero = (String)dt.Rows[pos]["genero"];
                auxBodeguero.Correo_bodeguero = (String)dt.Rows[pos]["correo_bodeguero"];
                auxBodeguero.Telefono_bodeguero = (int)dt.Rows[pos]["telefono_bodeguero"];
            }
            else
            {
                auxBodeguero.Rut_bodeguero = String.Empty;
                auxBodeguero.Nombre_bodeguero = String.Empty;
                auxBodeguero.Apellido_bodeguero = String.Empty;
                auxBodeguero.Correo_bodeguero = String.Empty;
                auxBodeguero.Telefono_bodeguero = 0;
            }
            return auxBodeguero;

        }
        //web listo
        public void GuardarTransaccionBodeguero(bodeguero bod)
        {

            this.configurarConexion();
            this.conect1.CadenaSQL = " INSERT INTO " + this.conect1.NombreTabla
                                        + " (rut_bodeguero,nombre_bodeguero,apellido_bodeguero,genero,correo_bodeguero,telefono_bodeguero) "
                                        +
                                        "VALUES ('" + bod.Rut_bodeguero + "','"
                                                    + bod.Nombre_bodeguero + "','"
                                                    + bod.Apellido_bodeguero + "','"
                                                    + bod.Genero_bodeguero + "','"
                                                    + bod.Correo_bodeguero + "','"
                                                    + bod.Telefono_bodeguero + "');";
            this.conect1.EsSelect = false;
            this.conect1.conectar();


        }

        //Metodo para cargar combobox bodeguero
        public static List<bodeguero> cargarDatosBodeguero()
        {
            var lista = new List<bodeguero>();
            using (var con = new SqlConnection("Data Source=DESKTOP-BG65M78\\SQLEXPRESS;Initial Catalog=inventario;Integrated Security=True"))
            {

                con.Open();
                const String consulta = "Select * from bodeguero";
                var cmd = new SqlCommand(consulta, con);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    var entidad = new bodeguero();
                    entidad.Nombre_bodeguero = Convert.ToString(lector[1]);
                    entidad.Rut_bodeguero = Convert.ToString(lector[0]);
                    lista.Add(entidad);
                }
                return lista;
            }
        }
        //web listo
        public void actualizarBodeguero(bodeguero bodeguero)
        {
            this.configurarConexion();
            this.conect1.CadenaSQL = "UPDATE bodeguero SET nombre_bodeguero = '" + bodeguero.Nombre_bodeguero + "',"
                                                            + " apellido_bodeguero = '" + bodeguero.Apellido_bodeguero + "',"
                                                             + " genero = '" + bodeguero.Genero_bodeguero + "',"
                                                             + " correo_bodeguero = '" + bodeguero.Correo_bodeguero + "',"
                                                             + " telefono_bodeguero = '" + bodeguero.Telefono_bodeguero + "'"
                                                             + " WHERE rut_bodeguero = '" + bodeguero.Rut_bodeguero + "';";
            this.conect1.EsSelect = false;
            this.conect1.conectar();

        }
        //web listo
        public void eliminarBodeguero(String rut_bodeguero)
        {
            this.configurarConexion();
            this.Conect1.CadenaSQL = "DELETE FROM bodeguero "
                                    + " WHERE rut_bodeguero = '" + rut_bodeguero + "';";
            this.Conect1.EsSelect = false;
            this.Conect1.conectar();

        }
    }
}
