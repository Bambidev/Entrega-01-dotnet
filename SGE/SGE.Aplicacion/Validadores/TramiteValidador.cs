using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Validadores
{
    public class TramiteValidador
    {
        public bool validar(Tramite tramite, out string error){
            error = "";
            if (string.IsNullOrWhiteSpace(tramite.Contenido)) error += "EL CONTENIDO NO PUEDE ESTAR VACIO.\n";
            if(tramite.idUpdateUser <= 0) error += "EL ID DEBE SER MAYOR A 0.\n";
            return error == "";
        }    
    }
}
