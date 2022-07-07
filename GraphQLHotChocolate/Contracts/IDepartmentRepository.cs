using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.Contracts
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(Guid id);
        Task<Department> CreateAsync(Department department);
    }
}
