using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Repositorio;
using SGE.Aplicacion.Enumerativos;

SistemaSQlite.Inicializar();


using (var context = new SistemaContext())
{
    /*Console.WriteLine("-- Tabla Usuarios --");
    foreach (var a in context.Usuarios)
    {
        Console.WriteLine($"{a.Id} {a.Nombre}");
    }

    Console.WriteLine("-- Tabla Expedientes --");
    foreach (var ex in context.Expedientes)
    {
        Console.WriteLine($"{ex.Id} {ex.Caratula}");
    }*/

    /*Tramite tram1 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido");
    Tramite tram2 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido2");
    Tramite tram3 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido3");
    Tramite tram4 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido3");
    Tramite tram5 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido3");
    Tramite tram6 = new Tramite(1, EtiquetaTramite.EscritoPresentado, "un contenido3");


    Expediente nuevo = new Expediente("EXPEDIENTE 1", EstadoExpediente.RecienIniciado);
    List<Tramite> ListaExp1 = new List<Tramite>();
    ListaExp1.Add(tram1);
    ListaExp1.Add(tram2);
    ListaExp1.Add(tram3);
    ListaExp1.Add(tram4);
    nuevo.listaTramites = ListaExp1;
    context.Add(nuevo);

    Expediente nuevo2 = new Expediente("EXPEDIENTE 2", EstadoExpediente.Finalizado);
    List<Tramite> ListaExp2 = new List<Tramite>();
    ListaExp2.Add(tram5);
    ListaExp2.Add(tram6);

    nuevo2.listaTramites = ListaExp2;
    context.Add(nuevo2);

    context.SaveChanges();*/

    /*foreach (Expediente e in context.Expedientes.Include(e => e.listaTramites))
    {
        Console.WriteLine(e.Caratula);
        e.listaTramites?.ToList().ForEach(tram => Console.WriteLine($" - {tram.Etiqueta} {tram.Contenido}"));
    }*/
    
}