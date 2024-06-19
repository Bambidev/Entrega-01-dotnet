using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Utiles;

namespace SGE.Aplicacion.Entidades
{
    public class EPermiso //entidad del  permiso para la BD
    {
        public EPermiso()
        {
            
        }
        public EPermiso(Permiso tipo, Usuario? poseedor)
        {
            tipoPermiso = tipo;
            poseedorPermiso = poseedor;
        }

        public int Id { get; set; }
        public int IdUsuario{ get; set; } //clave secundaria
        public Permiso tipoPermiso { get; set; }
        public Usuario? poseedorPermiso { get; set; } //propiedad navegacion
    }
}