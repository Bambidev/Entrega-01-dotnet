using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repo)
    {
        public void Ejecutar(Usuario user)
        {
            repo.EliminarUsuario(user.Id);
        }
    }
}
