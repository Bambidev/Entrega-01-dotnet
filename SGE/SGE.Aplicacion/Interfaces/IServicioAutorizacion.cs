using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Interfaces
{
    public interface IServicioAutorizacion
    {
        bool PoseeElPermiso(int idUsuario, Permiso permiso);
    }
}
