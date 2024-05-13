using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion auth, ExpedienteValidador validador)
    {
        public void Ejecutar(Expediente expediente, int idEjecutor)
        {
            expediente.FechaCreacion = DateTime.Now;
            string resultado;

            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.ExpedienteAlta)) 
            {
                resultado = "EL USUARIO NO TIENE PERMISO PARA ALTA DE EXPEDIENTES";
                throw new AutorizacionExcepcion(resultado);
            }
            expediente.IdUpdateUser = idEjecutor;
            if (!validador.validar(expediente, out resultado))
            {
                throw new ValidacionExcepcion(resultado);
            }        
            expediente.FechaActualizacion = DateTime.Now;
            repo.AgregarExpediente(expediente);
        }
    }
}
