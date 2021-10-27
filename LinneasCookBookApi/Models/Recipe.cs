using System.ComponentModel.DataAnnotations.Schema;

namespace cookBook_api.Models
{
    public class Recipe
    {
        public int Id { get; set; } 
        public string RecipeName { get; set; }
        public int ComplexityId { get; set; }        
        
        [ForeignKey("ComplexityId")]
        public Complexity Complexity {get; set;}
    }
}