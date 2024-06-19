using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoModificarUsuario(IUsuarioRepositorio repo, GeneradorHash generador)
    {
        public void Ejecutar(Usuario modificado)
        {
            string hashPass = generador.generarHash(modificado.Contrasenia);
            modificado.Contrasenia = hashPass;
            repo.ModificarUsuario(modificado);
        }
    }
}
