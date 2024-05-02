using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion(IServicioAutorizacion auth, ITramiteRepositorio repo, TramiteValidador validador, ServicioActualizacionEstado servicio)
    {
        public void Ejecutar(int idTramite, Tramite modificado, int idEjecutor)
        {
            modificado.IdTramite = idTramite;
            modificado.FechaModificacion = DateTime.Now;
            modificado.idUpdateUser = idEjecutor;

            string resultado;
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.TramiteModificacion))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA MODIFICAR EL TRAMITE";
                throw new AutorizacionExcepcion(resultado);
            }
            if (validador.validar(modificado, out resultado))
            {
                repo.modificarTramite(idTramite, modificado);
                servicio.CambiarEstado(modificado.IdExpediente);
            } else throw new ValidacionExcepcion(resultado);
        }
    }
}
