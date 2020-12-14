using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class bodega
    {
        private String codigo_bodega;
        private String nombre_bodega;

        public string Codigo_bodega { get => codigo_bodega; set => codigo_bodega = value; }
        public string Nombre_bodega { get => nombre_bodega; set => nombre_bodega = value; }
    }
}
