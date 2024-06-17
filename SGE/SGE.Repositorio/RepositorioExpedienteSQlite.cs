using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Repositorio
{
    internal class RepositorioExpedienteSQlite : IExpedienteRepositorio
    {
        public void AgregarExpediente(Expediente expediente)
        {   
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
           
        }

        public void CambiarEstado(EstadoExpediente estado, int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public Expediente consultaExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public void EliminarExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public List<Expediente> ListarExpedientesSinIncluirTramites()
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public void modificarExpediente(int id, Expediente modificado)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }
    }
}
