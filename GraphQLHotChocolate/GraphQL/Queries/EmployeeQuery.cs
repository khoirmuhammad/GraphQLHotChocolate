using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class EmployeeQuery
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Employees()
            => await _employeeRepository.GetAllAsync();

        public async Task<Employee?> Employee(Guid id)
            => await _employeeRepository.GetByIdAsync(id);
    }
}
