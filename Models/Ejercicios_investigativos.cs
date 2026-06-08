using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Ejercicios_investigativos")]
    public class Ejercicios_investigativos
    {

        public int No_de_programa_educativo { get; set; }
        public string? Programa_educativo { get; set; }
        public string? Plan_de_estudio { get; set; }
        public int Matricula { get; set; }
        public string? Nombre_del_alumno { get; set; }
        public int Clave_del_ejercicio_investigativo { get; set; }
        public string? Nombre_del_ejercicio_investigativo { get; set; }
        public int Creditos_del_ejercicio_investigativo { get; set; }
        public int No_de_empleado { get; set; }
        public string? Nombre_del_profesor_tutor_o_investigador { get; set; }
        public string? Grupo { get; set; }
        public string? Capturado { get; set; }
    }
}
