using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion auth)
    {
        public void Ejecutar(Tramite tramite, int idEjecutor)
        {
            tramite.FechaCreacion = DateTime.Now;
            string resultado;
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.TramiteAlta))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA DAR DE ALTA EL TRAMITE";
                throw new AutorizacionExcepcion(resultado);
            }
            if(validador.validar(tramite, out resultado)) repo.AgregarTramite(tramite);
            else throw new ValidacionExcepcion(resultado);
        }
    }
}
