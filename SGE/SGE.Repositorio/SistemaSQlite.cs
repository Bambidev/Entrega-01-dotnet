using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Repositorio
{
    public class SistemaSQlite
    {
        public static void Inicializar()
        {
            using var context = new SistemaContext();
            if (context.Database.EnsureCreated())
            {
                Console.WriteLine("Se creó base de datos");
            }
        }
    }
}
