using Microsoft.EntityFrameworkCore;

public class ProyectoTopicosContext(DbContextOptions<ProyectoTopicosContext> options) : DbContext(options)
{
    public DbSet<ProyectoTopicos.Models.Alumno> Alumno { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.Maestro> Maestros { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.Materia> Materias { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.Ayudantias_Investigacion> Ayudantias { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProyectoTopicos.Models.Alumno>().ToTable("Tabla_Alumnos").HasKey(a => a.Matricula);
        modelBuilder.Entity<ProyectoTopicos.Models.Maestro>().ToTable("Tabla_Maestros").HasKey(m => m.Numero_Empleado);
        modelBuilder.Entity<ProyectoTopicos.Models.Materia>().ToTable("Tabla_Materias").HasKey(m => m.ClaveUA);
        modelBuilder.Entity<ProyectoTopicos.Models.Ayudantias_Investigacion>().ToTable("Ayudantias").HasKey(a => a.Clave_Ayudantias);
    }
}