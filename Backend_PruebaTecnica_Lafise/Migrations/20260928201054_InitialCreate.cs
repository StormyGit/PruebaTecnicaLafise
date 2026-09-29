using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_PruebaTecnica_Lafise.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sexo = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingreso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
