using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookBook_api.Data;

namespace cookBook_api.Interfaces
{
    public interface IUnitOfWork
    {
        IRecipeRepository RecipeRepository{get;}
        IComplexityRepository ComplexityRepository {get;}
        RecipeContext Context {get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}