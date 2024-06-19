using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite) //AL ELIMINAR UN EXPEDIENTE SE DEBEN ELIMINAR TODOS LOS TRAMITES RELACIONADOS AL MISMO
    {
        public void Ejecutar(int idExp, int idEjecutor)
        {
            string resultado = "";
            repoTramite.EliminarTramitesByExpediente(idExp);
            repoExpediente.EliminarExpediente(idExp);
        }
    }
}
