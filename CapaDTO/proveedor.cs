using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class proveedor
    {
        private String rut_prov;
        private String nombre_prov;
        private String comuna_prov;
        private String ciudad_prov;
        private int numero_prov;
        private String direccion_prov;

        public string Rut_prov { get => rut_prov; set => rut_prov = value; }
        public string Nombre_prov { get => nombre_prov; set => nombre_prov = value; }
        public string Comuna_prov { get => comuna_prov; set => comuna_prov = value; }
        public string Ciudad_prov { get => ciudad_prov; set => ciudad_prov = value; }
        public int Numero_prov { get => numero_prov; set => numero_prov = value; }
        public string Direccion_prov { get => direccion_prov; set => direccion_prov = value; }
    }
}
