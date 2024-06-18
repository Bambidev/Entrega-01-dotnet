using System.Security.Cryptography;
using System.Text;

namespace SGE.Aplicacion.Utiles
{
    public class GeneradorHash
    {
        public string generarHash(string pass)
        {
            using (SHA256 generador = SHA256.Create())
            {
                byte[] bytes = generador.ComputeHash(Encoding.UTF8.GetBytes(pass));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2")); //hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}