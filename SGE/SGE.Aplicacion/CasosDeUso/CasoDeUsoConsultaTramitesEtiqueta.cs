using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoConsultaTramitesEtiqueta(ITramiteRepositorio repo)
    {
        public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
        {
            return repo.listarTramitesEtiqueta(etiqueta);
        }
    }
}
