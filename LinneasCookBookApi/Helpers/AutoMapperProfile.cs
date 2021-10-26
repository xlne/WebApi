using AutoMapper;
using cookBook_api.Models;
using LinneasCookBookApi.ViewModels.Recipes;

namespace LinneasCookBookApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //DIFFICULTY
            //Mappar mellan svårighetsgrad, Från model till ViewModel - GET 
            CreateMap<Complexity, ViewModels.Complexities.ViewModel>();

            //-----POSTViewModel istället för bara ViewModel???-----  POST för svårighetsgrad
            CreateMap<ViewModels.Complexities.PostViewModel, Complexity>();

            //RECIPES
            //POST för lägga till nytt recept. POST
            CreateMap<ViewModels.Recipes.PostViewModel, Recipe>().ForMember(dest => dest.Complexity, opt => opt.MapFrom<AddRecipeResolver>());

            //PUT
            CreateMap<Recipe, Recipe>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.ComplexityId, opt => opt.Ignore());
            
            CreateMap<Recipe, ViewModels.Recipes.ViewModel>().ForMember(dest => dest.Difficulty, opt => opt.MapFrom(source => source.Complexity.Difficulty));


            

            //.ForMember(dest => dest.Complexity, opt => opt.MapFrom(src => src.Difficulty));

            //DIFFICULTY
            //Kunna lägga till: FRÅN diff.PostViewModel => diff.Model
            //Kunna hämta/visa: från diff.Model => diff.PostViewModel


            //RECIPE
            //Kunna lägga till: FRÅN rec.PostViewModel => rec.Model
            //Kunna hämta/visa: från rec.Model => rec.PostViewModel
            /*

            */


        }
    }
}