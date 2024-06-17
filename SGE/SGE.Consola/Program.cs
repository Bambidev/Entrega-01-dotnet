using SGE.Repositorio;

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
}