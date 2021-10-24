using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cookBook_api.Interfaces;
using AutoMapper;
using LinneasCookBookApi.ViewModels.Recipes;
using cookBook_api.Models;

namespace cookBook_api.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RecipeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<IActionResult> AddRecipe(PostViewModel model)
        {
            try
            {
                 var recipe = _mapper.Map<Recipe>(model, opt => opt.Items["repo"] = _unitOfWork.Context);
                 if(await _unitOfWork.RecipeRepository.AddNewRecipeAsync(recipe))
                 {
                     if(!await _unitOfWork.Complete())
                     return StatusCode(500, "Could not add a new recipe");

                     var result = _mapper.Map<ViewModel>(recipe);
                     return StatusCode(201, result);
                 }
                 return StatusCode(500, "Could not add a new recipe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] PutViewModel recipe)
        {
            var toUpdate = await _unitOfWork.RecipeRepository.FindRecipeAsync(id);
            if(toUpdate == null) return NotFound($"Could not find the recipe with id: {id}");

            var updatedRecipe = _mapper.Map<ViewModel>(toUpdate);
            return Ok(updatedRecipe);            
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetRecipes()
        {
            var result = await _unitOfWork.RecipeRepository.ListAllRecipesAsync();
            if(result == null) return NotFound($"Could not find any recipes in the system.");

            var recipes = _mapper.Map<List<ViewModel>> (result);
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRecipe(int id)
        {
            var result = await _unitOfWork.RecipeRepository.FindRecipeAsync(id);
            if(result == null) return NotFound($"Could not find the recipe with id: {id}");

            var recipe = _mapper.Map<ViewModel>(result);
            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var toRemove = await _unitOfWork.RecipeRepository.FindRecipeAsync(id);
            if(toRemove == null) return NotFound($"Could not find and remove the recipe with id: {id}");

            if(_unitOfWork.RecipeRepository.RemoveRecipe(toRemove))
                if(await _unitOfWork.Complete()) return NoContent();
            
            return StatusCode(500, "Could not remove the recipe.");
        }
        
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDifficulty(int id, [FromBody] PatchComplexityViewModel recipe)
        {
            var toUpdate = await _unitOfWork.RecipeRepository.FindRecipeAsync(id);
            if(toUpdate == null) return NotFound($"Could not find the recipe with id: {id}");

            var difficulty = _mapper.Map<PatchComplexityViewModel>(toUpdate); 
            return Ok(difficulty);
        }
    }
}



/*
lägga till - addRecipe - POST
lista - getRecipes - GET
söka -  GetOneRecipe - GET
uppdatera - updateRecipe - PUT
uppdatera svårighet - UpdateDifficulty - PATCH
kunna ta bort - DeleteRecipe - DELETE

*/