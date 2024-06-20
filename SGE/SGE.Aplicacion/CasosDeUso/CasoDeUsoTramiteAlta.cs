using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador, ServicioActualizacionEstado servicio)
    {
        public void Ejecutar(Tramite tramite, int idEjecutor)
        {
            tramite.FechaCreacion = DateTime.Now;
            string resultado;
            
            tramite.idUpdateUser = idEjecutor;
            if (validador.validar(tramite, out resultado))
            {
                tramite.FechaModificacion = DateTime.Now;
                if(repo.AgregarTramite(tramite))
                {
                    servicio.CambiarEstado(tramite.IdExpediente);
                }
                else
                {
                    resultado += "Expediente asociado no valido.";
                    throw new ValidacionExcepcion(resultado);
                } 
            }
            else throw new ValidacionExcepcion(resultado);
        }
    }
}
