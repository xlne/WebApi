using System.Threading.Tasks;
using cookBook_api.Interfaces;
using cookBook_api.Repositories;

namespace cookBook_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeContext _context;
        public UnitOfWork(RecipeContext context)
        {
            _context = context;
        }

        public IRecipeRepository RecipeRepository => new RecipeRepository(_context);

        public IComplexityRepository ComplexityRepository => new ComplexityRepository(_context);

        public RecipeContext Context => _context;

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}