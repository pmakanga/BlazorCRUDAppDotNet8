using BlazorCRUDAppDotNet8.Data;
using BlazorCRUDAppDotNet8.Shared.Models;
using BlazorCRUDAppDotNet8.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDAppDotNet8.Implementations
{
    public class DevelopersRepository : IDevelopersRepository
    {
        private readonly IDbContextFactory<DataContext> dbContextFactory;

        public DevelopersRepository(IDbContextFactory<DataContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task<Developer> AddDeveloper(Developer entity)
        {
            using var context = dbContextFactory.CreateDbContext();
            var dev = context.Developers.Add(entity).Entity;
            await context.SaveChangesAsync();
            return dev;
        }

        public async Task<Developer> DeleteDeveloper(Guid Id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var Deletedev = await dbContext.Developers.FirstOrDefaultAsync(_ => _.Id == Id);
            if (Deletedev is null) return null!;
            dbContext.Developers.Remove(Deletedev);
            dbContext.SaveChanges();
            return Deletedev;
                
        }

        public async Task<List<Developer>> GetAllDevelopers()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var devs = await dbContext.Developers.ToListAsync();
            return devs;

        }

        public async Task<Developer> GetDeveloperById(Guid Id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var dev = await dbContext.Developers.FirstOrDefaultAsync(_=>_.Id == Id);
            if (dev is null) return null!;
            return dev;
            
        }
        
        public async Task<Developer> UpdateDeveloper(Developer entity)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var dev = await dbContext.Developers.FirstOrDefaultAsync(_ => _.Id == entity.Id);
            if (dev is null) return null!;
            dev.FirstName = entity.FirstName;
            dev.LastName = entity.LastName;
            dev.Email = entity.Email;
            dev.Experience = entity.Experience;
            await dbContext.SaveChangesAsync();
            return await dbContext.Developers.FirstOrDefaultAsync(_ => _.Id ==entity.Id);
        }
    }
}
