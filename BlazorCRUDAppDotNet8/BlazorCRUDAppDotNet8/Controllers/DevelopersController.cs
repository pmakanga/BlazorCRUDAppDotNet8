using BlazorCRUDAppDotNet8.Shared.Models;
using BlazorCRUDAppDotNet8.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDAppDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopersRepository developersRepository;

        public DevelopersController(IDevelopersRepository developersRepository)
        {
            this.developersRepository = developersRepository;
        }

        [HttpGet("AllDevelopers")]
        public async Task<ActionResult<List<Developer>>> GetAllDevelopers()
        {
            var developers = await developersRepository.GetAllDevelopers();
            return Ok(developers);
        }

        [HttpGet("DeveloperById")]
        public async Task<ActionResult<List<Developer>>> GetSingleDeveloper(Guid id)
        {
            var developer = await developersRepository.GetDeveloperById(id);
            return Ok(developer);
        }

        [HttpPost("AddDeveloper")]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer model)
        {
            var developer = await developersRepository.AddDeveloper(model);
            return Ok(developer);
        }

        [HttpPut("UpdateDeveloper")]
        public async Task<ActionResult<Developer>> UpdateDeveloper(Developer model)
        {
            var developer = await developersRepository.UpdateDeveloper(model);
            return Ok(developer);
        }

        [HttpDelete("DeleteDeveloper/{id}")]
        public async Task<ActionResult<Developer>> DeleteDeveloper(Guid id)
        {
            var developer = await developersRepository.DeleteDeveloper(id);
            return Ok(developer);
        }
    }
}
