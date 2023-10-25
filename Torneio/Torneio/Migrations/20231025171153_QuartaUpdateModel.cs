using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torneio.Migrations
{
    /// <inheritdoc />
    public partial class QuartaUpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoTorneios_Lutadores_VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoTorneios_VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios");

            migrationBuilder.DropColumn(
                name: "VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios");

            migrationBuilder.AddColumn<double>(
                name: "TaxaDeVitorias",
                schema: "RM87725",
                table: "ResultadoTorneios",
                type: "BINARY_DOUBLE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vencedor",
                schema: "RM87725",
                table: "ResultadoTorneios",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxaDeVitorias",
                schema: "RM87725",
                table: "ResultadoTorneios");

            migrationBuilder.DropColumn(
                name: "Vencedor",
                schema: "RM87725",
                table: "ResultadoTorneios");

            migrationBuilder.AddColumn<int>(
                name: "VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoTorneios_VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios",
                column: "VencedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoTorneios_Lutadores_VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios",
                column: "VencedorId",
                principalSchema: "RM87725",
                principalTable: "Lutadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
