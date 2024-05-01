using SGE.Aplicacion.Entidades;

public class InfoExpediente{
    public Expediente expediente {get; set;}
    public List<Tramite> tramitesExpediente{get; set;}

    public InfoExpediente(Expediente expediente, List<Tramite> tramitesExpediente)
    {
        this.expediente = expediente;
        this.tramitesExpediente=tramitesExpediente;
    }
}