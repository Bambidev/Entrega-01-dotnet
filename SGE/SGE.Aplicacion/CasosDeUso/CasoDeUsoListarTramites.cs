using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoListarTramites(ITramiteRepositorio repo)
    {
        public List<Tramite> Ejecutar()
        {
            return repo.listarTramites();
        }
    }
}