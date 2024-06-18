﻿using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioActualizacionEstado(IExpedienteRepositorio repo, ITramiteRepositorio repoTrams, EspecificacionCambioEstado especificacion)
    {
        public void CambiarEstado(int idExpediente)
        {
            Expediente expediente = repo.consultaExpediente(idExpediente); //consulta verifica si existe
            expediente.listaTramites = repoTrams.obtenerTramitesExpediente(idExpediente); //actualiza la lista interna del objeto
            Tramite ultimoTramite = expediente.listaTramites.Last();
            especificacion.realizarCambio(ultimoTramite.Etiqueta, idExpediente); // manda la etiqueta y realiza el cambio
        }
    }
}
