using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Estudios_Independientes")]
    public class EstudiosIndependientes
    {
        public double No { get; set; }
        public int No_Programa_Educativo { get; set; }
        public string Programa_Educativo { get; set; }
        public string Plan_de_Estudios { get; set; }
        public int Matricula { get; set; }
        public string Nombre_Alumno { get; set; }
     
        [Key]
        public int Clave_Estudio_Independiente { get; set; }
        public string Nombre_Estudio_Independiente { get; set; }
        public double Creditos_Estudio_Independiente { get; set; }
        public int No_Empleado { get; set; }
        public string Nombre_Profesor_Tutor_Investigar { get; set; }
    }
}
