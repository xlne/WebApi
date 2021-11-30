using System.Collections.Generic;

namespace cookBook_api.Models
{
    public class Complexity
    {
        public int Id { get; set; }
        public string Difficulty { get; set; }
        public ICollection<Recipe> Recipes {get; set;} //= new List<Recipe>();
    }
}