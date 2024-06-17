using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Entidades
{
    public class Usuario
    {
        public Usuario(string nombre, string apellido, string correo, string contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo; 
            Contrasenia = contrasenia;
        }
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    }
}
