using System.Data.Common;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, ServicioActualizacionEstado servicio)
    {
        public void Ejecutar(int idBorrar, int idEjecutor)
        {
            string resultado;
            //si tiene permiso para borrar expedientes tambien para borrar tramites
         
                int idExpediente = repo.recuperarIdExpedienteByIdTramite(idBorrar);
                repo.ElimitarTramiteID(idBorrar);
                servicio.CambiarEstado(idExpediente);
            
        }
    }
}
