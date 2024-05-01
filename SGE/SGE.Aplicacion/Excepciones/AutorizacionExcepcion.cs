using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class AutorizacionExcepcion : Exception
    {
        public AutorizacionExcepcion(String message) : base(message) { }
    }
}
