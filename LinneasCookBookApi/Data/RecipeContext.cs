using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookBook_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cookBook_api.Data
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes {get; set;}
        public DbSet<Complexity> Complexities {get; set;}
        public RecipeContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}