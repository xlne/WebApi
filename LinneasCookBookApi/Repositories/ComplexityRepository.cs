using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookBook_api.Data;
using cookBook_api.Interfaces;
using cookBook_api.Models;

namespace cookBook_api.Repositories
{
    public class ComplexityRepository : IComplexityRepository
    {
        private readonly RecipeContext _context;
        public ComplexityRepository(RecipeContext context)
        {
            _context = context;
        }

        public Task<bool> AddDifficultyAsync(Complexity complexity)
        {
            throw new NotImplementedException();
        }

        public Task<Complexity> GetComplexityAsync(string complexity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Complexity>> ListDifficultyAsync()
        {
            throw new NotImplementedException();
        }
    }
}