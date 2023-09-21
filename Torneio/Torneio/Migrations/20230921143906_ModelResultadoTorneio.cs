using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torneio.Migrations
{
    /// <inheritdoc />
    public partial class ModelResultadoTorneio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultadoTorneios",
                schema: "RM87725",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VencedorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoTorneios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadoTorneios_Lutadores_VencedorId",
                        column: x => x.VencedorId,
                        principalSchema: "RM87725",
                        principalTable: "Lutadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoTorneios_VencedorId",
                schema: "RM87725",
                table: "ResultadoTorneios",
                column: "VencedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultadoTorneios",
                schema: "RM87725");
        }
    }
}
