using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.API.Migrations
{
    /// <inheritdoc />
    public partial class terceiramigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tabelaNutricionals_ProdutoId",
                table: "tabelaNutricionals",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tabelaNutricionals_produtos_ProdutoId",
                table: "tabelaNutricionals",
                column: "ProdutoId",
                principalTable: "produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabelaNutricionals_produtos_ProdutoId",
                table: "tabelaNutricionals");

            migrationBuilder.DropIndex(
                name: "IX_tabelaNutricionals_ProdutoId",
                table: "tabelaNutricionals");
        }
    }
}
