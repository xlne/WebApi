using AutoMapper;
using cookBook_api.Models;
using LinneasCookBookApi.ViewModels.Recipes;

namespace LinneasCookBookApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mappar mellan svårighetsgrad, Från model till ViewModel - GET (?)
            CreateMap<Complexity, ViewModels.Complexities.ViewModel>();

            //Från ViewModel till Model - så att vi kan ändra värdet i modellen
            CreateMap<ViewModels.Complexities.ViewModel, Complexity>();

            //-----POSTViewModel istället för bara ViewModel???-----
            CreateMap<ViewModels.Complexities.PostViewModel, Complexity>();

            CreateMap<ViewModels.Recipes.PostViewModel, Complexity>()
            .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Complexity));
            
            CreateMap<Recipe, ViewModels.Recipes.ViewModel>();            




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