using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;


namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoConsultaTramite(ITramiteRepositorio repo)
    {
        public Tramite Ejecutar(int idTramite)
        {
            Tramite buscado = repo.consultaTramite(idTramite); 
          
            return buscado;
        }

    }
}
