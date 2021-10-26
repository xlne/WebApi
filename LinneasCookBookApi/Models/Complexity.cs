using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookBook_api.Models
{
    public class Complexity
    {
        public int Id { get; set; }
        public string Difficulty { get; set; }
        public ICollection<Recipe> Recipes {get; set;}
    }
}