﻿using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;


namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoConsultaExpediente(IExpedienteRepositorio repoExps)
    {
        public Expediente Ejecutar(int idExpediente)
        {
            Expediente buscado = repoExps.consultaExpediente(idExpediente); //verifica si existe o no
            return buscado;
        }

    }
}
