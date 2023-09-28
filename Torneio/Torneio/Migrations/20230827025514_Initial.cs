using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torneio.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM87725");

            migrationBuilder.CreateTable(
                name: "Lutadores",
                schema: "RM87725",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Idade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ArtesMarciais = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalLutas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Derrotas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Vitorias = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lutador", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lutadores",
                schema: "RM87725");
        }
    }
}
