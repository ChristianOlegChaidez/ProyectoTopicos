using Microsoft.EntityFrameworkCore;

public class ProyectoTopicosContext(DbContextOptions<ProyectoTopicosContext> options) : DbContext(options)
{
    public DbSet<ProyectoTopicos.Models.Alumno> Alumno { get; set; } = default!;
}
