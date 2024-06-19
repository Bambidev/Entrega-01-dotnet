using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        void registrarUsuario(Usuario unUsuario);
        bool loginUsuario(string correo, string hash);
        List<EPermiso> obtenerPermisosUsuario(int idUsuario);
        List<Usuario> ListarUsuarios();
        void EliminarUsuario(int usuarioId);
        void ModificarUsuario(Usuario usuario);
        Usuario ObtenerUsuario(int id);
        void quitarPermiso(int idUser, Permiso unPermiso);
        void agregarPermiso(int idUser, Permiso unPermiso);
        int RecuperarIdCorreo(string correo);
 
    }
}