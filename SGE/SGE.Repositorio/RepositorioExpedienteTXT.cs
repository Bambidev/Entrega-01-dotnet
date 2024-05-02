using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SGE.Repositorio
{
    public class RepositorioExpedienteTXT : IExpedienteRepositorio
    {
        readonly string _nombreArch = "expedientes.txt";
        private int _ultimoId = 0;

        public RepositorioExpedienteTXT()
        {
            if (File.Exists(_nombreArch))
            {
                var expedientes = ListarExpedientesSinIncluirTramites();
                foreach(Expediente e in expedientes)
                {
                    if(e.Id > _ultimoId) _ultimoId = e.Id;
                }
            }
            else throw new RepositorioExcepcion("EL ARCHIVO DE EXPEDIENTES NO EXISTE.");
        }

        
        public void AgregarExpediente(Expediente expediente) 
        {
            expediente.Id = ++_ultimoId;
            using var sw = new StreamWriter(_nombreArch, true);
            sw.WriteLine(expediente.Id);
            sw.WriteLine(expediente.Caratula);
            sw.WriteLine(expediente.FechaCreacion);
            sw.WriteLine(expediente.FechaActualizacion);
            sw.WriteLine(expediente.IdUpdateUser);
            sw.WriteLine(expediente.Estado);
        }

        public void EliminarExpediente(int idExpediente)
        {
            using var sw = new StreamWriter(_nombreArch, true);
            List<Expediente> expedientesArchivo = ListarExpedientesSinIncluirTramites();
            Expediente? expedienteEliminar = expedientesArchivo.FirstOrDefault(item => item.Id == idExpediente);
            if (expedienteEliminar != null)
            {
                expedientesArchivo.Remove(expedienteEliminar);
                GuardarExpedientesEnArchivo(expedientesArchivo);
            } else
            {
                throw new RepositorioExcepcion("NO SE ENCUENTRA EL ID DEL EXPEDIENTE A BORRAR");
            }
        }

        public Expediente consultaExpediente(int idExpediente)
        {
            Expediente resultado = new Expediente();
            List<Expediente> expedientesArchivo = ListarExpedientesSinIncluirTramites();
            foreach (Expediente e in expedientesArchivo)
            {
                if (e.Id == idExpediente)
                {
                    resultado = e;
                    break;
                }
            }
            return resultado;
        }

        public void modificarExpediente(int id, Expediente modificado)
        {
            List<Expediente> expedientes = ListarExpedientesSinIncluirTramites();
            for(int i = 0; i < expedientes.Count; i++) 
            {
                if(expedientes[i].Id == id)
                {
                    expedientes[i] = modificado;
                    break;
                }
            }
            GuardarExpedientesEnArchivo(expedientes);     
        }

        public List<Expediente> ListarExpedientesSinIncluirTramites()
        {
            var resultado = new List<Expediente>();
            using var sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                var expediente = new Expediente();
                expediente.Id = int.Parse(sr.ReadLine() ?? "");
                expediente.Caratula = sr.ReadLine() ?? "";
                expediente.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                expediente.FechaActualizacion = DateTime.Parse(sr.ReadLine() ?? "");
                expediente.IdUpdateUser = int.Parse(sr.ReadLine() ?? "");
                expediente.Estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
                resultado.Add(expediente);
            }
            return resultado;
        }

        public void GuardarExpedientesEnArchivo(List<Expediente> lista)
        {
            using var sw = new StreamWriter(_nombreArch);
            foreach(Expediente e in lista)
            {
                sw.WriteLine(e.Id);
                sw.WriteLine(e.Caratula);
                sw.WriteLine(e.FechaCreacion);
                sw.WriteLine(e.FechaActualizacion);
                sw.WriteLine(e.IdUpdateUser);
                sw.WriteLine(e.Estado);
            }
        }

        public void CambiarEstado(EstadoExpediente estado, int idExpediente)
        {
            List<Expediente> listaExpedientes = ListarExpedientesSinIncluirTramites();
            Expediente expedienteOriginal = consultaExpediente(idExpediente);
            Expediente expedienteModificado = expedienteOriginal;
            listaExpedientes.Remove(expedienteOriginal);
            expedienteModificado.Estado = estado;
            listaExpedientes.Add(expedienteModificado);
            GuardarExpedientesEnArchivo(listaExpedientes);
        }


    }
}
