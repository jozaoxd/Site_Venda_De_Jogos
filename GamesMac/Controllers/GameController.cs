using GamesMac.Models;
using GamesMac.Repositories.Interfaces;
using GamesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GamesMac.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamesRepository _gameRepository;

        public GameController(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult List(string categoria)
        {
            IEnumerable<Games> games;
            string categoriaAtual = string.Empty;
            if(string.IsNullOrEmpty(categoria))
            {
                games = _gameRepository.Games.OrderBy(g => g.GameId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                //(string.Equals("Ação", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //  games = _gameRepository.Games
                //        .Where(g => g.Categoria.CategoriaNome.Equals("Ação"))
                //      .OrderBy(g => g.Nome);
                //}
                //else
                //{
                //    games = _gameRepository.Games
                //            .Where(g => g.Categoria.CategoriaNome.Equals("Aventura"))
                //            .OrderBy(g => g.Nome);
                //}
                games = _gameRepository.Games
                        .Where(g => g.Categoria.CategoriaNome.Equals(categoria))
                        .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }
            var gameListViewModel = new GameListViewModel
            {
                Games = games,
                CategoriaAtual = categoriaAtual
            };

            return View(gameListViewModel);
        }
        public IActionResult Details(int gameId)
        {
            var game = _gameRepository.Games.FirstOrDefault(g => g.GameId == gameId);
            return View(game);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Games> games;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                games = _gameRepository.Games.OrderBy(p => p.GameId);
                categoriaAtual = "Todos os Jogos";
            }
            else
            {
                games = _gameRepository.Games
                        .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (games.Any())
                    categoriaAtual = "Games";
                else
                    categoriaAtual = "Nenhum jogo foi encontrado";
            }

            return View("~/Views/Game/List.cshtml", new GameListViewModel
            {
                Games = games,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
