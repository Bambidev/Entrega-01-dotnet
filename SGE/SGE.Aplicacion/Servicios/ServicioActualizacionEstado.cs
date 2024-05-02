using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioActualizacionEstado(ITramiteRepositorio repo, EspecificacionCambioEstado especificacion)
    {
        public void CambiarEstado(int idExpediente)
        {
            EtiquetaTramite etiqueta = repo.recuperarEtiqueta(idExpediente); // me retorna la etiqueta del ultimo tramite de este expediente
            especificacion.realizarCambio(etiqueta, idExpediente); // manda la etiqueta y realiza el cambio
        }
    }
}
