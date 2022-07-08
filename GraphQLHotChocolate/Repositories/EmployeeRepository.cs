using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolate.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContextFactory<AppContext> _dbContextFactory;
        public EmployeeRepository(IDbContextFactory<AppContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            using (var _applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    await applicationDbContext.Employees.AddAsync(employee);
                    await applicationDbContext.SaveChangesAsync();

                    return employee;
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    Employee employee = await this.GetByIdAsync(id);

                    applicationDbContext.Remove(employee);
                    await applicationDbContext.SaveChangesAsync();

                    return true;
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    return await applicationDbContext.Employees.ToListAsync();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    return await applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    applicationDbContext.Employees.Update(employee);
                    await applicationDbContext.SaveChangesAsync();

                    return employee;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
