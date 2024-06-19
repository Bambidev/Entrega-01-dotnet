using System.Data.Common;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteBaja(IServicioAutorizacion auth, ITramiteRepositorio repo, ServicioActualizacionEstado servicio)
    {
        public void Ejecutar(int idBorrar, int idEjecutor)
        {
            string resultado;
            //si tiene permiso para borrar expedientes tambien para borrar tramites
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.TramiteBaja) && !auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.ExpedienteBaja))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA DAR DE BAJA EL TRAMITE";
                throw new AutorizacionExcepcion(resultado);
            }
            else
            {
                int idExpediente = repo.recuperarIdExpedienteByIdTramite(idBorrar);
                repo.ElimitarTramiteID(idBorrar);
                servicio.CambiarEstado(idExpediente);
            }
        }
    }
}
