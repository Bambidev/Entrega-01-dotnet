using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Repositorio
{
    public class RepositorioUsuariosSQlite : IUsuarioRepositorio
    {
        public void registrarUsuario(Usuario unUsuario)
        {
            using (var context = new SistemaContext())
            {
                bool seraAdmin = !context.Usuarios.Any();
                if (seraAdmin)
                {
                    List<EPermiso> permisosAdmin = new List<EPermiso>();
                    foreach (Permiso tipoPermiso in Enum.GetValues(typeof(Permiso)))
                    {
                        EPermiso nuevoPermiso = new EPermiso
                        (
                            tipoPermiso,
                            unUsuario
                        );
                        permisosAdmin.Add(nuevoPermiso);
                    }
                    unUsuario.Permisos = permisosAdmin;
                }
                else
                {
                    unUsuario.Permisos.Add(new EPermiso(Permiso.Lectura , unUsuario));
                }
                context.Add(unUsuario); 
                context.SaveChanges(); 
            }
        }

        public bool loginUsuario(string correo, string hash)
        {
            using (var context = new SistemaContext())
            {
                bool res = false;
                Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Correo == correo);
                if(usuario != null)
                {
                    if(usuario.Contrasenia.Equals(hash)) res = true; //compara los hash no las contrasenas
                }
                return res;
            }
        }

        public List<EPermiso> obtenerPermisosUsuario(int idUsuario)
        {
            using (var context = new SistemaContext())
            {
                List<EPermiso> res = new List<EPermiso>();
                Usuario? usuario = context.Usuarios
                    .Include(u => u.Permisos)
                    .FirstOrDefault(u => u.Id == idUsuario);

                if(usuario != null) res = new List<EPermiso>(usuario.Permisos);
                else throw new RepositorioExcepcion("Usuario no existente");
                return res;
            }
        }

        public void quitarPermiso(int idUser, Permiso unPermiso)
        {
            using (var context = new SistemaContext())
            {
                Usuario user = ObtenerUsuario(idUser);
                List<EPermiso> permisosUser = obtenerPermisosUsuario(idUser);
                for (int i = permisosUser.Count - 1; i >= 0; i--)
                {
                    if (permisosUser[i].tipoPermiso == unPermiso)
                    {
                        context.Permisos.Remove(permisosUser[i]);
                        context.SaveChanges();
                    }
                }
            }
        }

    public void agregarPermiso(int idUser, Permiso unPermiso)
    {
        using (var context = new SistemaContext())
        {
            var user = context.Usuarios.Include(u => u.Permisos).FirstOrDefault(u => u.Id == idUser);
            if (user == null)
            {
                throw new RepositorioExcepcion("El usuario no existe");
            }
            Boolean yaEsta = false;
            foreach(EPermiso per in user.Permisos)
            {
                if(per.tipoPermiso == unPermiso) yaEsta = true;
            }
            if(!yaEsta)
            {
                var nuevoPermiso = new EPermiso
                (
                    unPermiso,
                    user
                );
                context.Permisos.Add(nuevoPermiso);
                context.SaveChanges();
            }
        }
    }

        public List<Usuario> ListarUsuarios()
        {
            using (var context = new SistemaContext())
            {
                return context.Usuarios.ToList();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (var context = new SistemaContext())
            {
                var usuario = context.Usuarios.Find(idUsuario);
                if (usuario != null)
                {
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();
                }
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            using ( var context = new SistemaContext())
            {
                context.Usuarios.Update(usuario);
              
                context.SaveChanges();
        
            }
        }

        public Usuario ObtenerUsuario(int id)
        {
            using (var context = new SistemaContext())
            {
                var usuario = context.Usuarios.Find(id);
                if (usuario == null) throw new RepositorioExcepcion("EL USUARIO CONSULTADO NO EXISTE");
                return usuario;
            }
        }

        public int RecuperarIdCorreo(string correo)
        {
            using (var context = new SistemaContext())
            {
                Usuario? user = context.Usuarios.FirstOrDefault(u => u.Correo == correo);
                return user != null ? user.Id : -1;
            }
        }
    }
}


        