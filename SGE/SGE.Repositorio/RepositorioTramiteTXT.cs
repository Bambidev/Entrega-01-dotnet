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
    public class RepositorioTramiteTXT : ITramiteRepositorio
    {
        readonly string _nombreArch = "tramites.txt";
        private int _ultimoId = 0;

        public RepositorioTramiteTXT()
        {
            if (File.Exists(_nombreArch))
            {
                var tramites = listarTramites();
                foreach(Tramite t in tramites)
                {
                    if(t.IdTramite > _ultimoId) _ultimoId = t.IdTramite;
                }
            }
            else throw new Exception("EL ARCHIVO DE TRAMITES NO EXISTE.");
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
    }
}
