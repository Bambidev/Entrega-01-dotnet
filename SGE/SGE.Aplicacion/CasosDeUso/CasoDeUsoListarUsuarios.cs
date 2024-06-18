using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repo)
    {
        public List<Usuario> Ejecutar()
        {
            return repo.ListarUsuarios();
        }
    }
}
