using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Repositorio;
using SGE.Aplicacion.Enumerativos;

SistemaSQlite.Inicializar();


using (var context = new SistemaContext())
{
    Console.WriteLine("-- Tabla Usuarios --");
    foreach (var a in context.Usuarios)
    {
        Console.WriteLine($"{a.Id} {a.Nombre}");
    }

    Console.WriteLine("-- Tabla Expedientes --");
    foreach (var ex in context.Expedientes)
    {
        Console.WriteLine($"{ex.Id} {ex.Caratula}");
    }

    Expediente nuevo = new Expediente("EXPEDIENTE 1", EstadoExpediente.RecienIniciado);
    Tramite tram1 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido");
    Tramite tram2 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido2");
    Tramite tram3 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido3");
    List<Tramite> listatemp = new List<Tramite>();
    listatemp.Add(tram1); listatemp.Add(tram2); listatemp.Add(tram3);
    nuevo.listaTramites = listatemp;
    context.Add(nuevo);

    Expediente nuevo2 = new Expediente("EXPEDIENTE 2", EstadoExpediente.Finalizado);
    listatemp = new List<Tramite>();
    listatemp.Add(tram2); listatemp.Add(tram3);
    nuevo2.listaTramites = listatemp;
    context.Add(nuevo2);
    context.SaveChanges();

    foreach (Expediente e in context.Expedientes.Include(e => e.listaTramites))
    {
        Console.WriteLine(e.Caratula);
        e.listaTramites?.ToList().ForEach(tram => Console.WriteLine($" - {tram.Etiqueta} {tram.Contenido}"));
    }
    
}