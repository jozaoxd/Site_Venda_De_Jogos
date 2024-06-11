using GamesMac.Models;

namespace GamesMac.Repositories.Interfaces
{
    public interface IGamesRepository
    {
        IEnumerable<Games> Games { get; }
        IEnumerable<Games> GamesPreferidos { get; }
        Games GetGameById(int gameId);
    }
}
