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
    internal class RepositorioTramiteSQlite : ITramiteRepositorio
    {
        public void AgregarTramite(Tramite tramite)
        {
            throw new NotImplementedException();
        }

        public void EliminarTramitesByExpediente(int idExpediente)
        {
            throw new NotImplementedException();
        }

        public void ElimitarTramiteID(int IdTramiteBorrar)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public List<Tramite> listarTramites()
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public List<Tramite> listarTramitesEtiqueta(EtiquetaTramite etiquetaCriterio)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public void modificarTramite(Tramite modificado)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public List<Tramite> obtenerTramitesExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public EtiquetaTramite recuperarEtiqueta(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }

        public int recuperarIdExpedienteByIdTramite(int idTramite)
        {
            using (var context = new SistemaContext())
            {
                context.SaveChanges();
            }
        }
    }
}
