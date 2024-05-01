using SGE.Aplicacion.Entidades;
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
    }
}
