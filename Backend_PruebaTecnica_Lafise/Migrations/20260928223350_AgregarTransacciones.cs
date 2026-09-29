using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_PruebaTecnica_Lafise.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTransacciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Saldo",
                table: "CuentasBancarias",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CuentaBancariaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<long>(type: "INTEGER", nullable: false),
                    Saldo = table.Column<long>(type: "INTEGER", nullable: false),
                    IsAprobado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_CuentasBancarias_CuentaBancariaId",
                        column: x => x.CuentaBancariaId,
                        principalTable: "CuentasBancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CuentaBancariaId",
                table: "Transacciones",
                column: "CuentaBancariaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "CuentasBancarias",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }
    }
}
