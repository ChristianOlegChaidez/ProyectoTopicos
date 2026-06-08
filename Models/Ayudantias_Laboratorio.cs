using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Ayudantias_Laboratorio")]
    public class Ayudantias_Laboratorio
    {
        [Key]
        public int id { get; set; }
        public int? no_programa { get; set; }
        public string? programa_educativo { get; set; }
        public string? plan_de_estudios { get; set; }
        public string? Matricula { get; set; }
        public string? Nombre_alumno { get; set; }
        public string? clave_ayudantia { get; set; }
        public string? nombre_ayudantia_lab { get; set; }
        public int? creditos_ayudantia { get; set; }
        public string? nombre_empleado { get; set; }
        public string? nombre_profesor { get; set; }
    }
}