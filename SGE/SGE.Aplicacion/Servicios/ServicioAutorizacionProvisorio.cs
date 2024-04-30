using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioAutorizacionProvisorio : IServicioAutorizacion
    {
        public bool PoseeElPermiso(int idUsuario, Permiso permiso)
        {
            if (idUsuario == 1) return true;
            else return false;
        }
    }
}
