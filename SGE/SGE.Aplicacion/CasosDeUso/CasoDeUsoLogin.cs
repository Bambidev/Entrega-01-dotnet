using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Utiles;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoLogin(IUsuarioRepositorio repoUsers, GeneradorHash generador)
    {
        public bool Ejecutar(string mail, string pass)
        {
            string hash = generador.generarHash(pass);
            return repoUsers.loginUsuario(mail, hash); //retorna true si credenciales son validas
        }
    }
}