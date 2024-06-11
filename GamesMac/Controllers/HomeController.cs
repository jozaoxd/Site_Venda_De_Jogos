using GamesMac.Models;
using GamesMac.Repositories.Interfaces;
using GamesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesMac.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamesRepository _gameRepository;

        public HomeController(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            var HomeViewModel = new HomeViewModel
            {
                GamesPreferidos = _gameRepository.GamesPreferidos
            };
            return View(HomeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}