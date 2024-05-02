using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Interfaces
{
    public interface ITramiteRepositorio
    {
        public void AgregarTramite(Tramite tramite);
        public void EliminarTramitesByExpediente(int idExpediente);
        public List<Tramite> listarTramites();
        public List<Tramite> listarTramitesEtiqueta(EtiquetaTramite etiquetaCriterio);
        public List<Tramite> obtenerTramitesExpediente(int idExpediente);
        public void ElimitarTramiteID(int IdTramiteBorrar);
        public void modificarTramite(int id, Tramite modificado);
        public EtiquetaTramite recuperarEtiqueta(int idExpediente);
        public int recuperarIdExpedienteByIdTramite(int idTramite);
    }
}
