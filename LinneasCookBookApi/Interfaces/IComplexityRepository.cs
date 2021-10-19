using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookBook_api.Models;

namespace cookBook_api.Interfaces
{
    public interface IComplexityRepository
    {
        Task<bool> AddDifficultyAsync(Complexity complexity);
        Task<IList<Complexity>> ListDifficultyAsync();
        Task<Complexity> GetComplexityAsync(string complexity);
    }
}