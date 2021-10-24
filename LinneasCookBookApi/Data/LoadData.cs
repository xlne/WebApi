using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cookBook_api.Models;

namespace cookBook_api.Data
{
    public class LoadData
    {
        public static async Task LoadRecipes(RecipeContext context)
        {
            if (await context.Recipes.AnyAsync()) return;
            //context.Recipe.AnyAsync()) return;
            var data = await File.ReadAllTextAsync("Data/recipes.json");
            var recipes = JsonSerializer.Deserialize<List<Recipe>>(data);
        }
    }
}