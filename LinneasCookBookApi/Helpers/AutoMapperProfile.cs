using AutoMapper;
using cookBook_api.Models;
using LinneasCookBookApi.ViewModels.Recipes;

namespace LinneasCookBookApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mappar mellan svårighetsgrad mellan Models och ViewModel
            CreateMap<Complexity, ViewModels.Recipes.ViewModel>();
            //.ForMember(dest => dest.Complexity, opt => opt.MapFrom(src => src.Difficulty));

            //

        }
    }
}