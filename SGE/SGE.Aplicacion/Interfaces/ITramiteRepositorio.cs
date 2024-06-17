using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;


namespace SGE.Aplicacion.Interfaces
{
    public interface ITramiteRepositorio
    {
        public void AgregarTramite(Tramite tramite);
        public void modificarTramite(int id, Tramite modificado);
        public void EliminarTramitesByExpediente(int idExpediente);
        public List<Tramite> listarTramites();
        public List<Tramite> listarTramitesEtiqueta(EtiquetaTramite etiquetaCriterio);
        public List<Tramite> obtenerTramitesExpediente(int idExpediente);
        public void ElimitarTramiteID(int IdTramiteBorrar);
        
        public EtiquetaTramite recuperarEtiqueta(int idExpediente);
        public int recuperarIdExpedienteByIdTramite(int idTramite);
    }
}
