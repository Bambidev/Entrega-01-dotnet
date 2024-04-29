using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SGE.Repositorio
{
    internal class RepositorioExpedienteTXT : IExpedienteRepositorio
    {
        readonly string _nombreArch = "expedientes.txt";

        public void AgregarProducto(Expediente expediente) 
        {
            using var sw = new StreamWriter(_nombreArch, true);
            sw.WriteLine(expediente.Id);
            sw.WriteLine(expediente.Caratula);
            sw.WriteLine(expediente.FechaCreacion);
            sw.WriteLine(expediente.FechaActualizacion);
            sw.WriteLine(expediente.IdUpdateUser);
            sw.WriteLine(expediente.Estado);
        }


        public List<Expediente> ListarExpedientes()
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
