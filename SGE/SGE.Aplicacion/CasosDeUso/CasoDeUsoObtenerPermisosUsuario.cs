using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoObtenerPermisosUsuario(IUsuarioRepositorio repo)
    {
        public List<EPermiso> Ejecutar(int idUsuario)
        {
            return repo.obtenerPermisosUsuario(idUsuario);
        }
    }
}