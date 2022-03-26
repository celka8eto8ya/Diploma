using Microsoft.EntityFrameworkCore;
using Onion.AppCore.Entities;

namespace Onion.Infrastructure.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();  // миграция
        }

    }
}
