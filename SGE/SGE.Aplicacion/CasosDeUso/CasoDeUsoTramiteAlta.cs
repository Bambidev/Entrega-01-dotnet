using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion auth, ServicioActualizacionEstado servicio)
    {
        public void Ejecutar(Tramite tramite, int idEjecutor)
        {
            tramite.FechaCreacion = DateTime.Now;
            string resultado;
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.TramiteAlta))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA DAR DE ALTA EL TRAMITE";
                throw new AutorizacionExcepcion(resultado);
            }
            tramite.idUpdateUser = idEjecutor;
            if (validador.validar(tramite, out resultado))
            {
                tramite.FechaModificacion = DateTime.Now;
                repo.AgregarTramite(tramite);
                servicio.CambiarEstado(tramite.IdExpediente);
            }
            else throw new ValidacionExcepcion(resultado);
        }
    }
}
