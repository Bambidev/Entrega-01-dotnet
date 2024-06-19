using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioActualizacionEstado(IExpedienteRepositorio repo, ITramiteRepositorio repoTrams, EspecificacionCambioEstado especificacion)
    {
        public void CambiarEstado(int idExpediente)
        {
            Expediente expediente = repo.consultaExpediente(idExpediente); //consulta verifica si existe
            expediente.listaTramites = repoTrams.obtenerTramitesExpediente(idExpediente); //actualiza la lista interna del objeto
            Tramite ultimoTramite;
            if(expediente.listaTramites.ToList().Any()) 
            {
                ultimoTramite = expediente.listaTramites.Last();
                especificacion.realizarCambio(ultimoTramite.Etiqueta, idExpediente);
            }
        }
    }
}
