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
                        {
                            tipoPermiso = tipoPermiso,
                            poseedorPermiso = unUsuario,
                        };
                        permisosAdmin.Add(nuevoPermiso);
                    }
                    unUsuario.Permisos = permisosAdmin;
                }
                else
                {
                    unUsuario.Permisos.Add(new EPermiso{tipoPermiso = Permiso.Lectura, poseedorPermiso = unUsuario});
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
                return res;
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
    }
}


        