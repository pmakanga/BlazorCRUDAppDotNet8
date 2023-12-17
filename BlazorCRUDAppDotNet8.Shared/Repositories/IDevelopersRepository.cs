using BlazorCRUDAppDotNet8.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDAppDotNet8.Shared.Repositories
{
    public interface IDevelopersRepository
    {
        Task<Developer> AddDeveloper(Developer entity);
        Task<Developer> UpdateDeveloper(Developer entity);
        Task <Developer> DeleteDeveloper(Guid Id);
        Task<List<Developer>> GetAllDevelopers();
        Task<Developer>GetDeveloperById(Guid Id);
    }
}
