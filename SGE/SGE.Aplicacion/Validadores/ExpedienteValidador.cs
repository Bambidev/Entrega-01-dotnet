using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Validadores
{
    public class ExpedienteValidador
    {
        public bool validar(Expediente expediente, out string error){
            error = "";
            if (string.IsNullOrWhiteSpace(expediente.Caratula)) error += "LA CARATULA NO PUEDE ESTAR VACIA.\n";
            if(expediente.IdUpdateUser <= 0) error += "EL ID DEBE SER MAYOR A 0.\n";
            return error == "";
        }
    }
}
    

