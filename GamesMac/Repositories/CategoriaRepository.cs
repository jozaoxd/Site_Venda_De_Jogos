using GamesMac.Context;
using GamesMac.Models;
using GamesMac.Repositories.Interfaces;

namespace GamesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    
    }
}
