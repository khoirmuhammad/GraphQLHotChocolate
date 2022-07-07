using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolate.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContextFactory<AppContext> _dbContextFactory;
        public DepartmentRepository(IDbContextFactory<AppContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            using (var _applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    return await applicationDbContext.Departments.ToListAsync();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Department> CreateAsync(Department department)
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    await applicationDbContext.Departments.AddAsync(department);
                    await applicationDbContext.SaveChangesAsync();

                    return department;
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Department?> GetByIdAsync(Guid id)
        {
            try
            {
                using (var applicationDbContext = _dbContextFactory.CreateDbContext())
                {
                    return await applicationDbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
