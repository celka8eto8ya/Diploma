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
        public DbSet<PersonalFile> PersonalFiles { get; set; }
        public DbSet<DashBoard> DashBoards { get; set; }
        public DbSet<ReviewStage> ReviewStages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Operation> Operations { get; set;}
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Effect> Effects { get; set; }




        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            Database.Migrate();  
        }

    }
}
