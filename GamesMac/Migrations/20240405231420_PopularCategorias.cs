using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesMac.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " + "VALUES('Ação', 'Jogo de Ação')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" + "VALUES('Aventura', 'Jogo de Aventura')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
