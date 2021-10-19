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
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _context;
        public RecipeRepository(RecipeContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewRecipeAsync(Recipe recipe)
        {
            try
            {
                await _context.Recipes.AddAsync(recipe);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<Recipe> FindRecipeAsync(int id)
        {
            return await _context.Recipes
            .Include(c => c.Complexity)
            .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Recipe> FindRecipeByNameAsync(string name)
        {
            return await _context.Recipes.Where(c => c.RecipeName.Trim().ToLower() == .ToLower().Trim()).ToListAsync();
            // var result = await _context.Recipes
            // .Include(c => c.Complexity)
            // .Where(c => c.Complexity.Difficulty.Trim().ToLower() == )

            // return result;
        }

        public Task<IList<Recipe>> ListAllRecipesAsync()
        {
            throw new NotImplementedException();
        }

        public bool RemoveRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}