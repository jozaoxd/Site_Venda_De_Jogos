using GamesMac.Models;
using GamesMac.Repositories.Interfaces;
using GamesMac.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IGamesRepository _gameRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IGamesRepository gameRepository, CarrinhoCompra carrinhoCompra)
        {
            _gameRepository = gameRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            //o controlador está procurando por uma view com o mesmo nome do controlado pois eu não especifiquei no return view
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int gameId)
        {
            var gameSelecionado = _gameRepository.Games.FirstOrDefault(p => p.GameId == gameId);
            if(gameSelecionado != null) 
            {
                _carrinhoCompra.AdicionarAoCarrinho(gameSelecionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int gameId)
        {
            var gameSelecionado = _gameRepository.Games.FirstOrDefault(p => p.GameId == gameId);
            if (gameSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(gameSelecionado);
            }
            return RedirectToAction("Index");
        }




    }
}
