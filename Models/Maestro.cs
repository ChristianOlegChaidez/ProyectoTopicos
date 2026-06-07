using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTopicos.Models
{
    [Table("Tabla_Maestros")]
    public class Maestro
    {
        public string? Numero_Empleado { get; set; }
        public string? Nombre { get; set; }
    }
}
