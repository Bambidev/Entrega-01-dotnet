using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repo)
    {
        public List<Usuario> Ejecutar()
        {
            return repo.ListarUsuarios();
        }
    }
}
