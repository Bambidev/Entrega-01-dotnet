using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Validadores
{
    public class UsuarioValidador()
    {
        public bool validar(Usuario unUsuario, out string error)
        {
            error = "";
            if(string.IsNullOrWhiteSpace(unUsuario.Nombre)) error += " NOMBRE NO VALIDO ";
            if(string.IsNullOrWhiteSpace(unUsuario.Apellido)) error += " APELLIDO NO VALIDO ";
            if(string.IsNullOrWhiteSpace(unUsuario.Contrasenia)) error += " CONTRASENA NO VALIDA ";
            if(string.IsNullOrWhiteSpace(unUsuario.Correo) || !unUsuario.Correo.Contains("@")) error += "CORREO NO VALIDO";
            return error == "";
        }
    }
}