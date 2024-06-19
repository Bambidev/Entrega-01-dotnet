using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoQuitarPermiso(IUsuarioRepositorio repo)
    {
        public void Ejecutar(int idUser, Permiso unPermiso)
        {
            repo.quitarPermiso(idUser, unPermiso);
        }
    }
}