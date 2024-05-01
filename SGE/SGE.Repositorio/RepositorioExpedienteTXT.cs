using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
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
            else throw new Exception("EL ARCHIVO DE EXPEDIENTES NO EXISTE.");
        }

        public Expediente consultaExpediente(int idExpediente)
        {
            Expediente resultado = new Expediente();
            List<Expediente> expedientesArchivo = ListarExpedientesSinIncluirTramites();
            foreach(Expediente e in expedientesArchivo)
            {
                if(e.Id == idExpediente) 
                {
                    resultado = e;
                    break;
                }
            }
            return resultado;

        }
        public void AgregarProducto(Expediente expediente) 
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


    }
}
