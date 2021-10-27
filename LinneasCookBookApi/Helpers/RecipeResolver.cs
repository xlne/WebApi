using System;
using System.Linq;
using AutoMapper;
using cookBook_api.Data;
using cookBook_api.Models;
using LinneasCookBookApi.ViewModels.Recipes;

namespace LinneasCookBookApi.Helpers
{
    public class AddRecipeResolver : IValueResolver<PostViewModel, Recipe, Complexity>
    {
        //Resolver for the difficulty string to a difficulty object
        public Complexity Resolve(PostViewModel source, Recipe destination, Complexity destMember, ResolutionContext context)
        {
            var repo = context.Items["repo"] as RecipeContext;
            var result = repo.Complexities.FirstOrDefault(c => c.Difficulty.ToLower().Trim() == source.Difficulty.ToLower().Trim());

            if(result == null) throw new Exception($"Could not find any difficulty with name: {source.Difficulty}");
            return result;
        }
    }
}