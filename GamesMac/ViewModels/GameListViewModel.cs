using GamesMac.Models;

namespace GamesMac.ViewModels
{
    public class GameListViewModel
    {
        public IEnumerable<Games> Games { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
