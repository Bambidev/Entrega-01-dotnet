using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Utiles;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoRegistrar(IUsuarioRepositorio repoUsers, UsuarioValidador validador, GeneradorHash generador)
    {
        public void Ejecutar(Usuario unUsuario)
        {
            string resultado = "";
            if (validador.validar(unUsuario, out resultado))
            {
                string hashPass = generador.generarHash(unUsuario.Contrasenia);
                unUsuario.Contrasenia = hashPass;
                repoUsers.registrarUsuario(unUsuario); //ya llega al repositorio con el hash aplicado a la pass
            }
            else throw new ValidacionExcepcion(resultado);
        }
    }
}