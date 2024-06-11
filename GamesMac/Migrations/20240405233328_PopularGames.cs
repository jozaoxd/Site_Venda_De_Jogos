using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesMac.Migrations
{
    public partial class PopularGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Games(CategoriaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsGamePreferido,EmEstoque) " +
                "VALUES(2,'Detroit:Become Human','Game de Aventura','Jogo focado em narrativa em um futuro robótico',300.00," +
                "'http://i.pinimg.com/originals/fe/23/b3/fe23b3c30ca165feacc87eb5f9dfcb6c.png','http://i.pinimg.com/originals/fe/23/b3/fe23b3c30ca165feacc87eb5f9dfcb6c.png',1,1)");
           
            migrationBuilder.Sql("INSERT INTO Games(CategoriaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsGamePreferido,EmEstoque) " +
                "VALUES(1,'Resident Evil 4','Game de Ação','Jogo focado em matar zumbis',250.00," +
                "'http://i.pinimg.com/474x/52/2c/d9/522cd91e10f58980b35998afa556348e.jpg','http://i.pinimg.com/474x/52/2c/d9/522cd91e10f58980b35998afa556348e.jpg',0,1)");

            migrationBuilder.Sql("INSERT INTO Games(CategoriaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsGamePreferido,EmEstoque) " +
                "VALUES(2,'Bloodborne','Game de Aventura','Junte-se a caçada, caçador.',250.00," +
                "'http://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRtKXw2H8Vu1do3PNeqv0zdSeSDUSZkAZ_6VS88xostGg&s','http://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRtKXw2H8Vu1do3PNeqv0zdSeSDUSZkAZ_6VS88xostGg&s',0,1)");

            migrationBuilder.Sql("INSERT INTO Games(CategoriaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsGamePreferido,EmEstoque) " +
                "VALUES(1,'The Last Of Us','Game de Ação','Explore a cidade em meio a infecção.',150.00," +
                "'http://rootjogos.net/wp-content/uploads/2018/06/3max.jpg','http://rootjogos.net/wp-content/uploads/2018/06/3max.jpg',0,1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Games");
        }
    }
}
