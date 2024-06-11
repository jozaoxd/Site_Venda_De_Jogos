using GamesMac.Context;
using GamesMac.Models;
using GamesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesMac.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly AppDbContext _context;
        public GamesRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Games> Games => _context.Games.Include(c => c.Categoria);

        public IEnumerable<Games> GamesPreferidos => _context.Games.Where(g => g.IsGamePreferido)
                                                                   .Include(c => c.Categoria);
        public Games GetGameById(int gameId)
        {
            return _context.Games.FirstOrDefault(g => g.GameId == gameId);
        }
    }
}
