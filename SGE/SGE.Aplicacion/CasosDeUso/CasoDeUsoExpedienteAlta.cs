using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador)
    {
        public void Ejecutar(Expediente expediente, int idEjecutor)
        {
            string resultado;
        
            expediente.IdUpdateUser = idEjecutor;    
            if (!validador.validar(expediente, out resultado))
            {
                throw new ValidacionExcepcion(resultado);
            }        
            expediente.FechaCreacion = DateTime.Now;
            expediente.FechaActualizacion = DateTime.Now;
            repo.AgregarExpediente(expediente);
        }
    }
}
