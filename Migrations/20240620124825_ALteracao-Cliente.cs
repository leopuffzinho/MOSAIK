using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOSAIK.Migrations
{
    /// <inheritdoc />
    public partial class ALteracaoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SexoCliente",
                table: "Cliente",
                newName: "SenhaCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenhaCliente",
                table: "Cliente",
                newName: "SexoCliente");
        }
    }
}
