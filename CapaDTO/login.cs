using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class login
    {
        private String usuario;
        private String contrasena;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
