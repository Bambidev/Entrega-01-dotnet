using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoAgregarPermiso(IUsuarioRepositorio repo)
    {
        public void Ejecutar(int idUser, Permiso unPermiso)
        {
            repo.agregarPermiso(idUser, unPermiso);
        }
    }
}