using System.Collections.Generic;
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
            return await _context.Recipes
            .Include(c => c.RecipeName)            
            .FirstOrDefaultAsync(c => c.RecipeName.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<IList<Recipe>> ListAllRecipesAsync()
        {
            return await _context.Recipes.Include(c => c.Complexity).ToListAsync();
        }

        public bool RemoveRecipe(Recipe recipe)
        {
            try
            {
                 _context.Recipes.Remove(recipe);
                 return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            try
            {
                 _context.Recipes.Update(recipe);
                 return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}