using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoConsultaExpedienteYTramites(IExpedienteRepositorio repoExps, ITramiteRepositorio repoTrams)
    {
        public InfoExpediente Ejecutar(int idExpediente)
        {
            Expediente buscado = repoExps.consultaExpediente(idExpediente);
            List<Tramite> tramitesExpediente = repoTrams.obtenerTramitesExpediente(idExpediente);
            return new InfoExpediente(buscado, tramitesExpediente);
        }
    }
}
