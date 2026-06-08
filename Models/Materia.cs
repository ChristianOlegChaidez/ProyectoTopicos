using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Tabla_Materias")]
    public class Materia
    {
        public int ClaveUA { get; set; }
        public int NoPE { get; set; }
        public string? NombrePE { get; set; }
        public string? PlanDeEstudios { get; set; }
        public string? NombreUA { get; set; }
        public double? Creditos { get; set; }
    }
}
