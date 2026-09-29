using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_PruebaTecnica_Lafise.Migrations
{
    /// <inheritdoc />
    public partial class EliminarSaldoCuentaBancaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "CuentasBancarias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Saldo",
                table: "CuentasBancarias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
