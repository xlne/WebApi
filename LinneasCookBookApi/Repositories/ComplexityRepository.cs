using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookBook_api.Data;
using cookBook_api.Interfaces;
using cookBook_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cookBook_api.Repositories
{
    public class ComplexityRepository : IComplexityRepository
    {
        private readonly RecipeContext _context;
        public ComplexityRepository(RecipeContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDifficultyAsync(Complexity complexity)
        {
            try
            {
                 await _context.Complexities.AddAsync(complexity);
                 return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Complexity> GetComplexityAsync(string complexity)
        {
            return await _context.Complexities.FirstOrDefaultAsync(c => c.Difficulty.ToLower().Trim() == complexity.ToLower().Trim());
        }

         public async Task<Complexity> GetDifficultyId(int id)
        {
            return await _context.Complexities.FindAsync(id);
        }

        public async Task<IList<Complexity>> ListDifficultyAsync()
        {
            return await _context.Complexities.ToListAsync();
        }
    }
}