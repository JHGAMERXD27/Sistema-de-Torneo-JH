using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTorneos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTorneoRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstaActivo",
                table: "Torneos",
                newName: "EstaFinalizado");

            migrationBuilder.AddColumn<int>(
                name: "TorneoId",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_TorneoId",
                table: "Jugadores",
                column: "TorneoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Torneos_TorneoId",
                table: "Jugadores",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Torneos_TorneoId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_TorneoId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "TorneoId",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "EstaFinalizado",
                table: "Torneos",
                newName: "EstaActivo");
        }
    }
}
