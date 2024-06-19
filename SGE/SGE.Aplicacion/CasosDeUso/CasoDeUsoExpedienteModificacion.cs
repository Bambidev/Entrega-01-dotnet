using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteModificacion( IExpedienteRepositorio repo, ExpedienteValidador validador)
    { 
        public void Ejecutar(Expediente modificado, int idEjecutor)
        {
            modificado.FechaActualizacion = DateTime.Now;
            modificado.IdUpdateUser = idEjecutor;
            string resultado;
            if (validador.validar(modificado, out resultado))
            {
                repo.modificarExpediente(modificado.Id, modificado);
            } else throw new ValidacionExcepcion(resultado);
        }
    }
}
