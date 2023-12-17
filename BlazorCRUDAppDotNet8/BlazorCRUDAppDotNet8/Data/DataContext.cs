using BlazorCRUDAppDotNet8.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDAppDotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }

        public DbSet<Developer> Developers { get; set; }
    }
}
