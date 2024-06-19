using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Interfaces
{
    public interface IServicioAutorizacion
    {
   
        bool Login(string mail, string pass);
        void Logout();
        bool PoseeElPermiso(int idUser, Permiso unPermiso);
    }
}
