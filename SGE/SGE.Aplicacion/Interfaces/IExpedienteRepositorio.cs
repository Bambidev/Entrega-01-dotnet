using SGE.Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Interfaces
{
    public interface IExpedienteRepositorio
    {
        public void AgregarProducto(Expediente expediente);
        public List<Expediente> ListarExpedientes();
    }
}
