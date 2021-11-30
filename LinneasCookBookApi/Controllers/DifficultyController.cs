using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using cookBook_api.Interfaces;
using cookBook_api.Models;
using cookBook_api.ViewModels.Complexities;
using LinneasCookBookApi.ViewModels.Complexities;
using Microsoft.AspNetCore.Mvc;

namespace cookBook_api.Controllers
{
    [ApiController]
    [Route("api/difficulty")]
    public class DifficultyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DifficultyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<IActionResult> AddDifficulty(PostViewModel model)
        {
            var difficulty = _mapper.Map<Complexity>(model);
            if (await _unitOfWork.ComplexityRepository.AddDifficultyAsync(difficulty))
                if (await _unitOfWork.Complete())
                    return StatusCode(201, difficulty);

            return StatusCode(500, "Could not add difficulty");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDifficulty(int id, [FromBody] PutViewModel complexityModel)
        {            
            var toUpdate = await _unitOfWork.ComplexityRepository.GetDifficultyId(id);
            if(toUpdate == null) return NotFound($"Could not find the difficulty with id: {id}");

            toUpdate.Difficulty = complexityModel.Difficulty;
            
            if (_unitOfWork.ComplexityRepository.UpdateComplexity(toUpdate))
                if (await _unitOfWork.Complete()) return NoContent();

            return StatusCode(500, "Something else went wrong."); 
        }

        [HttpGet()]
        public async Task<IActionResult> GetDifficulties()
        {
            var result = await _unitOfWork.ComplexityRepository.ListDifficultyAsync();
            if(result == null) return NotFound($"Could not find any difficulties in the system.");

            var difficulty = _mapper.Map<List<ViewModel>>(result);
            return Ok(difficulty);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDifficultyId(int id)
        {
            var result = await _unitOfWork.ComplexityRepository.GetDifficultyId(id);
            if(result == null) return NotFound($"Could not find difficulty with id: {id}.");

            var level = _mapper.Map<ViewModel>(result);
            return Ok(level);
        }
        
        [HttpGet("byName/{difficulty}")]
        public async Task<IActionResult> GetDifficulty(string difficulty)
        {
            var result = await _unitOfWork.ComplexityRepository.GetComplexityAsync(difficulty);
            if(result == null) return NotFound($"Could not find difficulty with id {difficulty} for recipes.");

            var level = _mapper.Map<ViewModel>(result);
            return Ok(level);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficulty(int id)
        {
            var toRemove = await _unitOfWork.ComplexityRepository.GetDifficultyId(id);
            if(toRemove == null) return NotFound($"Could not find and remove the difficulty with id: {id}");

            if(_unitOfWork.ComplexityRepository.RemoveComplexity(toRemove))
                if(await _unitOfWork.Complete()) return NoContent();
            
            return StatusCode(500, "Could not remove the recipe.");
        }
    }
}