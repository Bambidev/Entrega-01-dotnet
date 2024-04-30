using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class ValidacionExcepcion : Exception
    {
        public ValidacionExcepcion(String message) : base(message) { }
    }
}
