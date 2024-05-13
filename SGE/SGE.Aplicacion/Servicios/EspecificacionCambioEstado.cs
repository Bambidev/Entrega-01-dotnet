using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Servicios
{
    public class EspecificacionCambioEstado(IExpedienteRepositorio repo)
    {
        public void realizarCambio(EtiquetaTramite etiqueta,int idExpediente) 
        {
            if (etiqueta == EtiquetaTramite.Resolucion) 
            {
                repo.CambiarEstado(EstadoExpediente.ConResolucion, idExpediente);
            }
            if (etiqueta == EtiquetaTramite.PaseAEstudio)
            {
                repo.CambiarEstado(EstadoExpediente.ParaResolver, idExpediente);
            }
            if (etiqueta == EtiquetaTramite.PaseAlArchivo)
            {
                repo.CambiarEstado(EstadoExpediente.Finalizado, idExpediente);
            }
        }
    }
}
