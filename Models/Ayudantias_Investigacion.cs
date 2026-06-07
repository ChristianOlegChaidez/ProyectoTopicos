using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Ayudantias")]
    public class Ayudantias_Investigacion
    {
        public int Clave_Ayudantias { get; set; }
        public string? Programa_Educativo { get; set; }
        public int No_Programa_Educativo { get; set; }
        public string? Plan_Estudios { get; set; }
        public int Matricula { get; set; }
        public string? Nombre_Alumno { get; set; }
        public string? Nombre_de_Ayudantia { get; set; }
        public double Creditos_de_Ayudantia { get; set; }
        public int No_de_Empleado { get; set; }
        public string? Nombre_Empleado { get; set; }
    }
}
