using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class bodeguero
    {
        private String rut_bodeguero;
        private String nombre_bodeguero;
        private String apellido_bodeguero;
        private String genero_bodeguero;
        private String correo_bodeguero;
        private int telefono_bodeguero;

        public string Rut_bodeguero { get => rut_bodeguero; set => rut_bodeguero = value; }
        public string Nombre_bodeguero { get => nombre_bodeguero; set => nombre_bodeguero = value; }
        public string Apellido_bodeguero { get => apellido_bodeguero; set => apellido_bodeguero = value; }
        public string Genero_bodeguero { get => genero_bodeguero; set => genero_bodeguero = value; }
        public string Correo_bodeguero { get => correo_bodeguero; set => correo_bodeguero = value; }
        public int Telefono_bodeguero { get => telefono_bodeguero; set => telefono_bodeguero = value; }
    }
}
