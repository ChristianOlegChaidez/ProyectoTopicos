using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Unidad_aprendizaje_asesoria")]
    public class UnidadAprendizajeAsesoria
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "No.")]
        public double No { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "No. de programa educativo")]
        public int No_de_programa_Educativo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Programa educativo")]
        public string? Programa_Educativo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Plan de estudios")]
        public string? Plan_de_estudios { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Matricula del alumno")]
        public int Matricula_del_Alumno { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre del alumno")]
        public string? Nombre_del_Alumno { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Clave de la materia")]
        public int Clave_de_la_materia { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre de la unidad de aprendizaje por asesoria academica")]
        public string? Nombre_de_la_Unidad_de_Aprendizaje_por_asesoria_Academica { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Creditos de la unidad de aprendizaje")]
        public double Creditos_de_la_Unidad_de_Aprendizaje { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "No. de empleado")]
        public int No_de_empleado { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre del profesor")]
        public string? Nombre_del_profesor { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Grupo")]
        public string? Grupo { get; set; }

        [Display(Name = "Capturado")]
        public bool? CAPTURADO { get; set; }

    }
}
