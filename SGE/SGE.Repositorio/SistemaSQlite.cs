using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorio
{
    public class SistemaSQlite
    {
        public static void Inicializar()
        {
            using var context = new SistemaContext();
            {
                context.Database.EnsureCreated();
                var connection = context.Database.GetDbConnection();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA journal_mode=DELETE;";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
