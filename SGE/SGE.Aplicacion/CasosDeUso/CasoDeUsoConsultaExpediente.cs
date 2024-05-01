namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoConsultaExpedienteYTramites(IExpedienteRepositorio repoExps, ITramiteRepositorio repoTrams, IServicioAutorizacion auth)
    {
        public InfoExpediente Ejecutar(int idExpediente)
        {
            Expediente buscado = repoExps.consultaExpediente(idExpediente);
            List<Tramite> tramitesExpediente = repoTrams.obtenerTramitesExpediente(idExpediente);
            InfoExpediente resultado = new InfoExpediente(buscado, tramitesExpediente);
            return resultado;
        }
    }
}
