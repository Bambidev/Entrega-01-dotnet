using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteModificacion(IServicioAutorizacion auth, IExpedienteRepositorio repo, ExpedienteValidador validador)
    { 
        public void Ejecutar(int idExpediente, Expediente modificado, int idEjecutor)
        {
            modificado.FechaActualizacion = DateTime.Now;
            modificado.IdUpdateUser = idEjecutor;
            string resultado;
            if (!auth.PoseeElPermiso(idEjecutor, Enumerativos.Permiso.ExpedienteModificacion))
            {
                resultado = "NO CUENTA CON EL PERMISO PARA MODIFICAR EL EXPEDIENTE";
                throw new AutorizacionExcepcion(resultado);
            }
            if(validador.validar(modificado, out resultado)) repo.modificarExpediente(idExpediente, modificado);
            else throw new ValidacionExcepcion(resultado);
        }
    }
}
