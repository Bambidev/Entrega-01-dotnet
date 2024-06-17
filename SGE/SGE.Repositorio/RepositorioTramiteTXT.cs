using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;


namespace SGE.Repositorio
{
    public class RepositorioTramiteTXT : ITramiteRepositorio
    {
        private readonly string _nombreArch;
        private int _ultimoId = 0;

        public RepositorioTramiteTXT()
        {
            DirectoryInfo? directorioPadre = Directory.GetParent(System.IO.Directory.GetCurrentDirectory());
            if (directorioPadre != null)
            {
                string directorioSolucion = directorioPadre.FullName;
                _nombreArch = Path.Combine(directorioSolucion, "Archivos", "tramites.txt");
            }

            if (File.Exists(_nombreArch))
            {
                var tramites = listarTramites();
                foreach(Tramite t in tramites)
                {
                    if(t.IdTramite > _ultimoId) _ultimoId = t.IdTramite;
                }
            }
            else {
             
                throw new Exception("EL ARCHIVO DE TRAMITES NO EXISTE.");
            }
        }

        public void AgregarTramite(Tramite tramite)
        {
            tramite.IdTramite = ++_ultimoId;
            using var sw = new StreamWriter(_nombreArch, true);
            sw.WriteLine(tramite.IdTramite);
            sw.WriteLine(tramite.IdExpediente);
            sw.WriteLine(tramite.Etiqueta);
            sw.WriteLine(tramite.Contenido);
            sw.WriteLine(tramite.FechaCreacion);
            sw.WriteLine(tramite.FechaModificacion);
            sw.WriteLine(tramite.idUpdateUser);
        }

        public void ElimitarTramiteID(int IdTramiteBorrar)
        {
            List<Tramite> listaTramites = listarTramites();
            foreach(Tramite t in listaTramites)
            {
                if(t.IdTramite == IdTramiteBorrar)
                {
                    listaTramites.Remove(t);
                    break; //el id es univoco
                }
            }
            GuardarTramitesEnArchivo(listaTramites);     
        }

        public void modificarTramite(int id, Tramite modificado)
        {
            List<Tramite> listaTramites = listarTramites();
            for(int i = 0; i < listaTramites.Count; i++) 
            {
                if(listaTramites[i].IdTramite == id)
                {
                    modificado.IdTramite = id;
                    modificado.FechaCreacion = listaTramites[i].FechaCreacion;
                    listaTramites[i] = modificado;
                    break;
                }
            }
            GuardarTramitesEnArchivo(listaTramites);     
        }

        public void EliminarTramitesByExpediente(int idExpediente)
        {
            List<Tramite> listaTramites = listarTramites();
            List<Tramite> tramitesEliminar = listaTramites.Where(item => item.IdExpediente == idExpediente).ToList();
            if (tramitesEliminar.Any()) // si contiene elementos 
            {
                foreach(var tramite in tramitesEliminar)
                {
                    listaTramites.Remove(tramite);
                }
                GuardarTramitesEnArchivo(listaTramites);
            }
          

        }

        public List<Tramite> obtenerTramitesExpediente(int idExpediente)
        {
            List<Tramite> resultado = new List<Tramite>();
            List<Tramite> tramites = listarTramites();
            foreach(Tramite t in tramites)
            {
                if(t.IdExpediente == idExpediente)
                {
                    resultado.Add(t);
                }
            }
            return resultado;
        }


        public List<Tramite> listarTramites()
        {
            var resultado = new List<Tramite>();
            using var sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                var tramite = new Tramite();
                tramite.IdTramite = int.Parse(sr.ReadLine() ?? "");
                tramite.IdExpediente = int.Parse(sr.ReadLine() ?? "");
                tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
                tramite.Contenido = sr.ReadLine() ?? "";
                tramite.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                tramite.FechaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
                tramite.idUpdateUser = int.Parse(sr.ReadLine() ?? "");
                resultado.Add(tramite);
            }
            return resultado;
        }

        public List<Tramite> listarTramitesEtiqueta(EtiquetaTramite etiquetaCriterio)
        {
            var resultado = new List<Tramite>();
            using var sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                var tramite = new Tramite();
                tramite.IdTramite = int.Parse(sr.ReadLine() ?? "");
                tramite.IdExpediente = int.Parse(sr.ReadLine() ?? "");
                tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
                tramite.Contenido = sr.ReadLine() ?? "";
                tramite.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                tramite.FechaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
                tramite.idUpdateUser = int.Parse(sr.ReadLine() ?? "");

                if(tramite.Etiqueta == etiquetaCriterio)
                {
                    resultado.Add(tramite);
                }  
            }
            return resultado;
        }

        private void GuardarTramitesEnArchivo(List<Tramite> lista)
        {
            using var sw = new StreamWriter(_nombreArch);
            foreach(Tramite tramite in lista)
            {
                sw.WriteLine(tramite.IdTramite);
                sw.WriteLine(tramite.IdExpediente);
                sw.WriteLine(tramite.Etiqueta);
                sw.WriteLine(tramite.Contenido);
                sw.WriteLine(tramite.FechaCreacion);
                sw.WriteLine(tramite.FechaModificacion);
                sw.WriteLine(tramite.idUpdateUser);
            }
        }

        public int recuperarIdExpedienteByIdTramite(int id)
        {
            List<Tramite> listaTramite = listarTramites();
            int idExpediente = -1;
            foreach (Tramite tramite in listaTramite)
            {
                if (tramite.IdTramite == id)
                {
                    idExpediente = tramite.IdExpediente;
                }
            }
            if (idExpediente == -1)
            {
                throw new RepositorioExcepcion("NO HAY TRAMITES PARA CAMBIAR EL ESTADO DEL EXPEDIENTE");
            } else
            {
                return idExpediente;
            }

        }


        public EtiquetaTramite recuperarEtiqueta(int idExpediente)
        {
            List<Tramite> lista = obtenerTramitesExpediente(idExpediente); // retorna una lista con los tramites de un idExpediente
            if (lista.Any())
            {
                Tramite ultimoTramite = lista.Last();
                return ultimoTramite.Etiqueta;
            } else
            {
                throw new RepositorioExcepcion($"NO HAY TRAMITES PARA EL EXPEDIENTE {idExpediente}" );
            }
        }


    }
}
