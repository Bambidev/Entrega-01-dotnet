using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioAutorizacion(IUsuarioRepositorio repo) : IServicioAutorizacion
    {
        public bool PoseeElPermiso(int idUser, Permiso unPermiso)
        {
            List<EPermiso> permisos = repo.obtenerPermisosUsuario(idUser);
            bool resultado = false;
            foreach(EPermiso e in permisos)
            {
                if(e.tipoPermiso == unPermiso)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }
    }
}