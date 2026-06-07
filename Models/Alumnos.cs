using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Tabla_Alumnos")]
    public class Alumno
    {
        [Key]
        public int Matricula { get; set; }
        public string? Nombre { get; set; }
        public string? Puntos { get; set; }
        public string? Promedio { get; set; }
        public string? Creditos { get; set; }
    }
}
