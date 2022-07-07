using Microsoft.EntityFrameworkCore;
using GraphQLHotChocolate.Models.Configs;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
