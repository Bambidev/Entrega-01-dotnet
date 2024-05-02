using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteBaja(IServicioAutorizacion auth, ITramiteRepositorio repo)
    {
        public void Ejecutar(int idBorrar, int idEjecutor)
        {
            string resultado;
            //si tiene permiso para borrar expedientes tambien para borrar tramites
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.TramiteBaja) && !auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.ExpedienteBaja))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA DAR DE BAJA EL TRAMITE";
                throw new AutorizacionExcepcion(resultado);
            }
            else
            {
                repo.ElimitarTramiteID(idBorrar);
            }
        }
    }
}
