using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTopicos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayudantias",
                columns: table => new
                {
                    Clave_Ayudantias = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Programa_Educativo = table.Column<string>(type: "TEXT", nullable: true),
                    No_Programa_Educativo = table.Column<int>(type: "INTEGER", nullable: false),
                    Plan_Estudios = table.Column<string>(type: "TEXT", nullable: true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre_Alumno = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre_de_Ayudantia = table.Column<string>(type: "TEXT", nullable: true),
                    Creditos_de_Ayudantia = table.Column<double>(type: "REAL", nullable: false),
                    No_de_Empleado = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre_Empleado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayudantias", x => x.Clave_Ayudantias);
                });

            migrationBuilder.CreateTable(
                name: "Ayudantias_Laboratorios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    no_programa = table.Column<int>(type: "INTEGER", nullable: true),
                    programa_educativo = table.Column<string>(type: "TEXT", nullable: true),
                    plan_de_estudios = table.Column<string>(type: "TEXT", nullable: true),
                    Matricula = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre_alumno = table.Column<string>(type: "TEXT", nullable: true),
                    clave_ayudantia = table.Column<string>(type: "TEXT", nullable: true),
                    nombre_ayudantia_lab = table.Column<string>(type: "TEXT", nullable: true),
                    creditos_ayudantia = table.Column<int>(type: "INTEGER", nullable: true),
                    nombre_empleado = table.Column<string>(type: "TEXT", nullable: true),
                    nombre_profesor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayudantias_Laboratorios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Alumnos",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Puntos = table.Column<string>(type: "TEXT", nullable: true),
                    Promedio = table.Column<string>(type: "TEXT", nullable: true),
                    Creditos = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Alumnos", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Maestros",
                columns: table => new
                {
                    Numero_Empleado = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Maestros", x => x.Numero_Empleado);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Materias",
                columns: table => new
                {
                    ClaveUA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoPE = table.Column<int>(type: "INTEGER", nullable: false),
                    NombrePE = table.Column<string>(type: "TEXT", nullable: true),
                    PlanDeEstudios = table.Column<string>(type: "TEXT", nullable: true),
                    NombreUA = table.Column<string>(type: "TEXT", nullable: true),
                    Creditos = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Materias", x => x.ClaveUA);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayudantias");

            migrationBuilder.DropTable(
                name: "Ayudantias_Laboratorios");

            migrationBuilder.DropTable(
                name: "Tabla_Alumnos");

            migrationBuilder.DropTable(
                name: "Tabla_Maestros");

            migrationBuilder.DropTable(
                name: "Tabla_Materias");
        }
    }
}
