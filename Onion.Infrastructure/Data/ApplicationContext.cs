using Microsoft.EntityFrameworkCore;
using Onion.AppCore.Entities;

namespace Onion.Infrastructure.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DepartmentType> DepartmentTypes { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Team> Teams { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            Database.Migrate();  
        }

    }
}
