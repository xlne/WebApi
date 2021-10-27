using cookBook_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cookBook_api.Data
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes {get; set;}
        public DbSet<Complexity> Complexities {get; set;}
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
            
        }
    }
}