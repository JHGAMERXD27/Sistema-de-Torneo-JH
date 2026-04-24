using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTorneos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HerenciaPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "PartidasGanadas",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "PuntosRanking",
                table: "Jugadores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Jugadores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PartidasGanadas",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuntosRanking",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
