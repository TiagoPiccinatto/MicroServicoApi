using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.API.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "tabelaNutricionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calorias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carboidratos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proteínas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GordurasTotais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GordurasSaturadas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FibraAlimentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sodio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabelaNutricionals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "tabelaNutricionals");
        }
    }
}
