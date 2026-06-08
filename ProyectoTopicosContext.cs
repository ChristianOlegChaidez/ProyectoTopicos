using Microsoft.EntityFrameworkCore;

public class ProyectoTopicosContext(DbContextOptions<ProyectoTopicosContext> options) : DbContext(options)
{
    // Compartidas
    public DbSet<ProyectoTopicos.Models.Alumno> Alumno { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.Maestro> Maestros { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.Materia> Materias { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.Ayudantias_Investigacion> Ayudantias { get; set; } = default!;

    // Tu código agregado
    public DbSet<ProyectoTopicos.Models.Ejercicios_investigativos> Ejercicios_investigativos { get; set; } = default!;

    // Del suyo
    public DbSet<ProyectoTopicos.Models.Ayudantias_Laboratorio> Ayudantias_Laboratorio { get; set; } = default!;

    // Del nuestro
    public DbSet<ProyectoTopicos.Models.EstudiosIndependientes> EstudiosIndependientes { get; set; } = default!;
    public DbSet<ProyectoTopicos.Models.UnidadAprendizajeAsesoria> Unidad_aprendizaje_asesoria { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Compartidas
        modelBuilder.Entity<ProyectoTopicos.Models.Alumno>().ToTable("Tabla_Alumnos").HasKey(a => a.Matricula);
        modelBuilder.Entity<ProyectoTopicos.Models.Maestro>().ToTable("Tabla_Maestros").HasKey(m => m.Numero_Empleado);
        modelBuilder.Entity<ProyectoTopicos.Models.Materia>().ToTable("Tabla_Materias").HasKey(m => m.ClaveUA);
        modelBuilder.Entity<ProyectoTopicos.Models.Ayudantias_Investigacion>().ToTable("Ayudantias").HasKey(a => a.Clave_Ayudantias);

        // Tu código agregado
        modelBuilder.Entity<ProyectoTopicos.Models.Ejercicios_investigativos>().ToTable("Ejercicios_investigativos").HasKey(e => e.No_de_programa_educativo);

        // Del suyo
        modelBuilder.Entity<ProyectoTopicos.Models.Ayudantias_Laboratorio>().ToTable("Ayudantias_Laboratorio").HasKey(a => a.id);

        // Del nuestro
        modelBuilder.Entity<ProyectoTopicos.Models.EstudiosIndependientes>().ToTable("Estudios_Independiente").HasKey(e => e.Clave_Estudio_Independiente);
        modelBuilder.Entity<ProyectoTopicos.Models.UnidadAprendizajeAsesoria>().ToTable("Unidad_aprendizaje_asesoria").HasKey(u => u.No);
    }
}