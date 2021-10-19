using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookBook_api.Models
{
    public class Recipe
    {
        public int Id { get; set; } 
        public string RecipeName { get; set; }
        public int Complexity { get; set; }
        public string Ingredients { get; set; }
    }
}