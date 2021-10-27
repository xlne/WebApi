using System.Collections.Generic;
using System.Threading.Tasks;
using cookBook_api.Models;

namespace cookBook_api.Interfaces
{
    public interface IRecipeRepository
    {
        Task<bool> AddNewRecipeAsync(Recipe recipe);
        bool UpdateRecipe(Recipe recipe);
        bool RemoveRecipe(Recipe recipe);
        Task<IList<Recipe>> ListAllRecipesAsync();
        Task<Recipe> FindRecipeAsync(int id);
        Task<Recipe> FindRecipeByNameAsync(string name);
        
    }
}