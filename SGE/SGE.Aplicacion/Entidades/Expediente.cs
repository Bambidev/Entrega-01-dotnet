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
        public int Id { get; set; }
        public string? Caratula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdUpdateUser { get; set; }
        public EstadoExpediente Estado { get; set; }

    }
}
