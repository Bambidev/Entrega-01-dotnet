using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Validadores
{
    public class ExpedienteValidador
    {
        public bool validar(Expediente expediente, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(expediente.Caratula))
            {
                error += "LA CARATULA NO PUEDE ESTAR VACIA.\n";
            }
            return error == "";
        }
    }
}
    

