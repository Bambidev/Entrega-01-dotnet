using SGE.Aplicacion.Enumerativos;
using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacion.Entidades
{
    public class Tramite
    {
        public Tramite()
        {
   
        }
        public Tramite(int idExpediente, EtiquetaTramite etiqueta, String contenido)
        {
            IdExpediente = idExpediente;
            Etiqueta = etiqueta;
            Contenido = contenido;
        }
        [Key]
        public int IdTramite { get; set; }
        public int IdExpediente { get; set; }
        public Expediente? Expediente { get; set; } //prop navegacion BD
        public EtiquetaTramite Etiqueta { get; set; }
        public String? Contenido { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public DateTime FechaModificacion { get; set; }
        public int idUpdateUser { get; set; }

        public override string ToString()
        {
            return $"Id Trámite: {IdTramite}, Id Expediente: {IdExpediente}, Etiqueta: {Etiqueta}, Contenido: {Contenido}, Fecha de Creación: {FechaCreacion}, Fecha de Modificación: {FechaModificacion}, Id Usuario Actualización: {idUpdateUser}";
        }
    }
}
