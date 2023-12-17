using BlazorCRUDAppDotNet8.Shared.Models;
using BlazorCRUDAppDotNet8.Shared.Repositories;
using System.Net.Http.Json;

namespace BlazorCRUDAppDotNet8.Client.Services
{
    public class DeveloperService : IDevelopersRepository
    {
        private readonly HttpClient httpClient;

        public DeveloperService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Developer> AddDeveloper(Developer entity)
        {
            var developer = await httpClient.PostAsJsonAsync("api/Developers/AddDeveloper", entity);
            var response = await developer.Content.ReadFromJsonAsync<Developer>();
            return response!;
        }

        public async Task<Developer> DeleteDeveloper(Guid Id)
        {
            var developer = await httpClient.DeleteAsync($"api/Developers/DeleteDeveloper/{Id}");
            var response = await developer.Content.ReadFromJsonAsync<Developer>();
            return response!;
        }



        public async Task<List<Developer>> GetAllDevelopers()
        {
            var developers = await httpClient.GetAsync("api/Developers/AllDevelopers");
            var response = await developers.Content.ReadFromJsonAsync<List<Developer>>();
            return response!;
        }

        public async Task<IQueryable<Developer>> GetAllDevsForQuickGrid()
        {
            var developers = await httpClient.GetAsync("api/Developers/AllDevelopers");
            var response = await developers.Content.ReadFromJsonAsync<IQueryable<Developer>>();
            return response!;
        }

        public async Task<Developer> GetDeveloperById(Guid Id)
        {
            var developer = await httpClient.GetAsync($"api/Developers/DeveloperById/{Id}");
            var response = await developer.Content.ReadFromJsonAsync<Developer>();
            return response!;
        }

      

        public async Task<Developer> UpdateDeveloper(Developer entity)
        {
            var developer = await httpClient.PutAsJsonAsync("api/Developers/UpdateDeveloper", entity);
            var response = await developer.Content.ReadFromJsonAsync<Developer>();
            return response!;
        }
    }
}
