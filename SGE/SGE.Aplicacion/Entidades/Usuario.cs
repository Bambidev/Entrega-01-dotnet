using System.ComponentModel.DataAnnotations;


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

        public Usuario() { }
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public List<EPermiso> Permisos { get; set; } = new List<EPermiso>();

    }
}
