using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion auth, ExpedienteValidador validador)
    {
        public void Ejecutar(Expediente exp, int idEjecutor)
        {
            exp.FechaCreacion = DateTime.Now;
            string resultado;
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.ExpedienteAlta)) 
            {
                resultado = "EL USUARIO NO TIENE PERMISO PARA ALTA DE EXPEDIENTES";
                throw new AutorizacionExcepcion(resultado);
            }
            if (!validador.validar(exp, out resultado))
            {
                throw new ValidacionExcepcion(resultado);
            }        
            repo.AgregarExpediente(exp);
        }
    }
}
