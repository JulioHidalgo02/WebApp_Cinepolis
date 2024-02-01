using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Cinepolis.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "combos",
                columns: table => new
                {
                    idCombo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combos", x => x.idCombo);
                });

            migrationBuilder.CreateTable(
                name: "salas",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacidadPersonas = table.Column<int>(type: "int", nullable: false),
                    IdCine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salas", x => x.IdSala);
                    table.ForeignKey(
                        name: "FK_salas_cines_IdCine",
                        column: x => x.IdCine,
                        principalTable: "cines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCombo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_combos_IdCombo",
                        column: x => x.IdCombo,
                        principalTable: "combos",
                        principalColumn: "idCombo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "peliculas",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peliculas", x => x.IdPelicula);
                    table.ForeignKey(
                        name: "FK_peliculas_salas_IdSala",
                        column: x => x.IdSala,
                        principalTable: "salas",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPelicula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_horarios_peliculas_IdPelicula",
                        column: x => x.IdPelicula,
                        principalTable: "peliculas",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_horarios_IdPelicula",
                table: "horarios",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_IdSala",
                table: "peliculas",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCombo",
                table: "Producto",
                column: "IdCombo");

            migrationBuilder.CreateIndex(
                name: "IX_salas_IdCine",
                table: "salas",
                column: "IdCine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "peliculas");

            migrationBuilder.DropTable(
                name: "combos");

            migrationBuilder.DropTable(
                name: "salas");

            migrationBuilder.DropTable(
                name: "cines");
        }
    }
}
