using SGE.Aplicacion.Entidades;

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
    }
}