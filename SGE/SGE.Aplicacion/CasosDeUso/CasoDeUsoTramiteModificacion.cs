using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, TramiteValidador validador, ServicioActualizacionEstado servicio)
    {
        public void Ejecutar(Tramite modificado, int idEjecutor)
        {
            modificado.FechaModificacion = DateTime.Now;
            modificado.idUpdateUser = idEjecutor;

            string resultado;
            if (validador.validar(modificado, out resultado))
            {
                if(repo.modificarTramite(modificado))
                {
                    servicio.CambiarEstado(modificado.IdExpediente);
                }
                else
                {
                    resultado += "Expediente asociado no valido.";
                    throw new ValidacionExcepcion(resultado);
                }
            } else throw new ValidacionExcepcion(resultado);
        }
    }
}
