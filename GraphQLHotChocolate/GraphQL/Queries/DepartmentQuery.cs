using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class DepartmentQuery
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentQuery(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> Departments()
            => await _departmentRepository.GetAllAsync();

        public async Task<Department?> Department(Guid id)
            => await _departmentRepository.GetByIdAsync(id);
    }
}
