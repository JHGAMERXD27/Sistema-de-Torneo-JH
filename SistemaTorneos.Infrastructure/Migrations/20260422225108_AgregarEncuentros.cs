using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTorneos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEncuentros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encuentros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorneoId = table.Column<int>(type: "int", nullable: false),
                    JugadorA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JugadorB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ganador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ronda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuentros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encuentros");
        }
    }
}
