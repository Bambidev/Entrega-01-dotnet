using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Utiles;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoModificarUsuario(IUsuarioRepositorio repo, GeneradorHash generador, UsuarioValidador validador)
    {
        public void Ejecutar(Usuario modificado)
        {
            string resultado = "";
            if (validador.validar(modificado, out resultado))
            {
                int idCorreoExistente = repo.RecuperarIdCorreo(modificado.Correo);
                if(idCorreoExistente == -1 || idCorreoExistente == modificado.Id)
                {
                    string hashPass = generador.generarHash(modificado.Contrasenia);
                    modificado.Contrasenia = hashPass;
                    repo.ModificarUsuario(modificado);
                }
                else
                {
                    resultado += " EL CORREO INGRESADO YA ESTA UTILIZADO ";
                    throw new ValidacionExcepcion(resultado);
                }
            }
            else throw new ValidacionExcepcion(resultado);
        }
    }
}
