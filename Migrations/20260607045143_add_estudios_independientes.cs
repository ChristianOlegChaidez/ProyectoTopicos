using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTopicos.Migrations
{
    /// <inheritdoc />
    public partial class add_estudios_independientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios_Independiente",
                columns: table => new
                {
                    Clave_Estudio_Independiente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    No = table.Column<double>(type: "REAL", nullable: false),
                    No_Programa_Educativo = table.Column<int>(type: "INTEGER", nullable: false),
                    Programa_Educativo = table.Column<string>(type: "TEXT", nullable: false),
                    Plan_de_Estudios = table.Column<string>(type: "TEXT", nullable: false),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre_Alumno = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre_Estudio_Independiente = table.Column<string>(type: "TEXT", nullable: false),
                    Creditos_Estudio_Independiente = table.Column<double>(type: "REAL", nullable: false),
                    No_Empleado = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre_Profesor_Tutor_Investigar = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios_Independiente", x => x.Clave_Estudio_Independiente);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudios_Independiente");

        }
    }
}
