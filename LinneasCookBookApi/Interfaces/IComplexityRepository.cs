using System.Collections.Generic;
using System.Threading.Tasks;
using cookBook_api.Models;

namespace cookBook_api.Interfaces
{
    public interface IComplexityRepository
    {
        Task<bool> AddDifficultyAsync(Complexity complexity);
        bool UpdateComplexity(Complexity complexity);
        bool RemoveComplexity(Complexity complexity);
        Task<IList<Complexity>> ListDifficultyAsync();
        Task<Complexity> GetDifficultyId(int id);
        Task<Complexity> GetComplexityAsync(string complexity);
    }
}