﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class RepositorioExcepcion : Exception
    {
        public RepositorioExcepcion(String message) : base(message) { }
    }
}
