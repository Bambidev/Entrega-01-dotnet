﻿using SGE.Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Interfaces
{
    public interface IExpedienteRepositorio
    {
        public void AgregarExpediente(Expediente expediente);
        public void EliminarExpediente(int idExpediente);
        public Expediente consultaExpediente(int idExpediente);
        public List<Expediente> ListarExpedientesSinIncluirTramites();
      
    }
}
