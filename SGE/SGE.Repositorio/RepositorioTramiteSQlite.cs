using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;


namespace SGE.Repositorio
{
    public class RepositorioTramiteSQlite : ITramiteRepositorio
    {
        public void AgregarTramite(Tramite tramite)
        {
            using (var context = new SistemaContext())
            {
                context.Tramites.Add(tramite);
                context.SaveChanges();
            }
        }

        public void EliminarTramitesByExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                Expediente? expediente = context.Expedientes.Find(idExpediente);
                if (expediente != null)
                {
                    if(expediente.listaTramites != null) 
                    {
                        context.Tramites.RemoveRange(expediente.listaTramites);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void ElimitarTramiteID(int IdTramiteBorrar)
        {
            using (var context = new SistemaContext())
            {
                Tramite? tramiteDelete = context.Tramites.FirstOrDefault(tr => tr.IdTramite ==  IdTramiteBorrar);
                if (tramiteDelete != null)
                {
                    context.Tramites.Remove(tramiteDelete);
                    context.SaveChanges();
                }
            }
        }

        public List<Tramite> listarTramites()
        {
            using (var context = new SistemaContext())
            {
                return context.Tramites.ToList();  
            }
        }

        public List<Tramite> listarTramitesEtiqueta(EtiquetaTramite etiquetaCriterio)
        {
            using (var context = new SistemaContext())
            {
                return context.Tramites.Where(tr => tr.Etiqueta == etiquetaCriterio).ToList();
            }
        }

        public void modificarTramite(Tramite modificado)
        {
            using (var context = new SistemaContext())
            {
                context.Tramites.Update(modificado);
                context.SaveChanges();
            }
        }

        public List<Tramite> obtenerTramitesExpediente(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                return context.Tramites.Where(tr => tr.IdExpediente == idExpediente).ToList();
            }
        }

        public EtiquetaTramite recuperarEtiqueta(int idExpediente)
        {
            using (var context = new SistemaContext())
            {
                EtiquetaTramite e = new EtiquetaTramite();
                Expediente? expediente = context.Expedientes.FirstOrDefault(tr => tr.Id == idExpediente);
                if(expediente != null)
                {
                    if(expediente.listaTramites != null) e = expediente.listaTramites.Last().Etiqueta;
                }
                return e;
            }
        }

        public int recuperarIdExpedienteByIdTramite(int idTramite)
        {
            using (var context = new SistemaContext())
            {
                var tramite = context.Tramites.Find(idTramite);
                if (tramite != null)
                {
                    return tramite.IdExpediente; // Usamos el operador de acceso condicional null (?.)
                }
                return -1;
            }
        }
    }
}
