using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
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
            } else
            {
                throw new RepositorioExcepcion("NO HAY TRAMITES A BORRAR PARA EL EXPEDIENTE");
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

        public void GuardarTramitesEnArchivo(List<Tramite> lista)
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


    }
}
