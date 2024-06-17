using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;


namespace SGE.Aplicacion.Interfaces
{
    public interface IExpedienteRepositorio
    {
        public void AgregarExpediente(Expediente expediente);
        public void modificarExpediente(int id, Expediente modificado);
        public void EliminarExpediente(int idExpediente);
        public Expediente consultaExpediente(int idExpediente);
        public List<Expediente> ListarExpedientesSinIncluirTramites();
        
        public void CambiarEstado(EstadoExpediente estado, int idExpediente); //rev
    }
}
