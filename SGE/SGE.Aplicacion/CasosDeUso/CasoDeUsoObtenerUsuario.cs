using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoObtenerUsuario(IUsuarioRepositorio repo)
    {
        public Usuario Ejecutar(int id)
        {
            return repo.ObtenerUsuario(id);
        }
    }
}
