using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion auth) //AL ELIMINAR UN EXPEDIENTE SE DEBEN ELIMINAR TODOS LOS TRAMITES RELACIONADOS AL MISMO
    {
        public void Ejecutar(int idExp, int idEjecutor)
        {
            string resultado = "";
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.ExpedienteBaja))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA DAR DE BAJA EL EXPEDIENTE";
                throw new AutorizacionExcepcion(resultado);
            }

            repoExpediente.EliminarExpediente(idExp);
            repoTramite.EliminarTramitesByExpediente(idExp);

        }
    }
}
