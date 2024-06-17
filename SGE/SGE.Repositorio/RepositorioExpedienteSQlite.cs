using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;


namespace SGE.Repositorio
{
    public class RepositorioExpedienteSQlite : IExpedienteRepositorio
    {
        
        public void AgregarExpediente(Expediente expediente)
        {   
            using (var context = new SistemaContext())
            {
                context.Add(expediente);
                context.SaveChanges();
            }
           
        }

        public void CambiarEstado(EstadoExpediente estado, int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                var expediente = context.Expedientes.Find(idExpediente);
                if(expediente != null)
                {
                    expediente.Estado = estado;
                    context.SaveChanges();
                }
            }
        }

        public Expediente consultaExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                var expediente = context.Expedientes.Find(idExpediente);
                if(expediente == null) throw new RepositorioExcepcion("EL EXPEDIENTE CONSULTADO NO EXISTE");
                return expediente;
            }
        }

        public void EliminarExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                var expediente = context.Expedientes.Find(idExpediente);
                if (expediente != null)
                {
                    context.Expedientes.Remove(expediente);
                    context.SaveChanges();
                }
            }
        }

        public List<Expediente> ListarExpedientesSinIncluirTramites()
        {
            using (var context = new SistemaContext())
            {
                var expedientes = context.Expedientes.ToList();
                return expedientes;
            }
        }

        public void modificarExpediente(int id, Expediente modificado)
        {
            using (var context = new SistemaContext())
            {
                var expediente = context.Expedientes.Find(id);
                if(expediente != null)
                {
                    expediente.Caratula = modificado.Caratula;
                    expediente.FechaCreacion = modificado.FechaCreacion;
                    expediente.FechaActualizacion = modificado.FechaActualizacion;
                    expediente.IdUpdateUser = modificado.IdUpdateUser;
                    expediente.Estado = modificado.Estado;
                    if(expediente.listaTramites != null && modificado.listaTramites != null)
                    {
                        expediente.listaTramites.Clear();
                        expediente.listaTramites.AddRange(modificado.listaTramites);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
