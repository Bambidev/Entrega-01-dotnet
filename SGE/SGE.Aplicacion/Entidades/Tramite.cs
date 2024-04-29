using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Entidades
{
    public class Tramite
    {
        public int IdTramite { get; set; }
        public int IdExpediente { get; set; }
        public EtiquetaTramite Etiqueta { get; set; }
        public String? Contenido { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public DateTime FechaModificacion { get; set; }
        public int idUpdateUser { get; set; }
    }
}
