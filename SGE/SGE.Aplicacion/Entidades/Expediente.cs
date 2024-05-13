using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Entidades
{
    public class Expediente
    {
        public Expediente()
        {
            
        }
        public Expediente(string caratula, EstadoExpediente estado)
        {
            Caratula = caratula;
            Estado = estado;
        }
        
        public int Id { get; set; }
        public string? Caratula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdUpdateUser { get; set; }
        public EstadoExpediente Estado { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Caratula: {Caratula}, Fecha de Creación: {FechaCreacion}, Fecha de Actualización: {FechaActualizacion}, Id Usuario Actualización: {IdUpdateUser}, Estado: {Estado}";
        }

    

    }
}
