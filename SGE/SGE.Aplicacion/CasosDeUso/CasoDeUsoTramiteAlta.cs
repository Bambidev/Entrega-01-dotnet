using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador)
    {
        public void Ejecutar(Tramite tramite)
        {
            tramite.FechaCreacion = DateTime.Now;
            string resultado;
            if(validador.validar(tramite, out resultado)) repo.AgregarTramite(tramite);
            else throw new ValidacionExcepcion(resultado);
        }
    }
}
