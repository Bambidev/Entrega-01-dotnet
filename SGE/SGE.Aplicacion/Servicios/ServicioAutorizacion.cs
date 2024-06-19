using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Utiles;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioAutorizacion(IUsuarioRepositorio repo, GeneradorHash generador) : IServicioAutorizacion
    {
       
        // variable para persistir el usuario actual

        public static Usuario? UsuarioActual;
        
        public bool Login(string mail, string pass)
        {
            string hash = generador.generarHash(pass);
            if (repo.loginUsuario(mail, hash))
            {
                int id = repo.RecuperarIdCorreo(mail);

                UsuarioActual = repo.ObtenerUsuario(id);
                return true;
            }
            return false;
        } 

        public bool PoseeElPermiso(int idUser, Permiso unPermiso)
        {
            List<EPermiso> permisos = repo.obtenerPermisosUsuario(idUser);
            bool resultado = false;
            foreach (EPermiso e in permisos)
            {
                if (e.tipoPermiso == unPermiso)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}