using AutoMapper;
using cookBook_api.Models;

namespace LinneasCookBookApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //DIFFICULTY mapping
            //Maps between difficultys, from Model to ViewModel - GET-method
            CreateMap<Complexity, ViewModels.Complexities.ViewModel>();

            //Maps from PostViewModel to ComplexityModel -  POST-method
            CreateMap<ViewModels.Complexities.PostViewModel, Complexity>();

            //RECIPES
            //Maps from PostViewModel to RecipeModel, add new recipe - POST-method
            CreateMap<ViewModels.Recipes.PostViewModel, Recipe>().ForMember(dest => dest.Complexity, opt => opt.MapFrom<AddRecipeResolver>());

            //PUT-method to update the recipes
            CreateMap<Recipe, Recipe>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.ComplexityId, opt => opt.Ignore());
            
            //Maps from RecipeModel to ViewModel - GET-method
            CreateMap<Recipe, ViewModels.Recipes.ViewModel>().ForMember(dest => dest.Difficulty, opt => opt.MapFrom(source => source.Complexity.Difficulty));
        }
    }
}