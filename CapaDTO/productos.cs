using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class productos
    {
        private String cod_producto;
        private String nom_producto;
        private DateTime fecha_ingreso;
        private int cantidad;
        private String rut_prov;
        private float precio_unitario;
        private String especificaciones;
        private String condicion;
        private String codigo_bodega;
        private String rut_bodeguero;

        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nom_producto { get => nom_producto; set => nom_producto = value; }
        public DateTime Fecha_ingreso { get => fecha_ingreso; set => fecha_ingreso = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Rut_prov { get => rut_prov; set => rut_prov = value; }
        public float Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
        public string Especificaciones { get => especificaciones; set => especificaciones = value; }
        public string Condicion { get => condicion; set => condicion = value; }
        public string Codigo_bodega { get => codigo_bodega; set => codigo_bodega = value; }
        public string Rut_bodeguero { get => rut_bodeguero; set => rut_bodeguero = value; }
    }
}
