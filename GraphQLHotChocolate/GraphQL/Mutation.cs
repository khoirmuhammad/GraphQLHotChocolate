using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL
{
    public class Mutation
    {
        private readonly IDepartmentRepository _departmentRepository;
        public Mutation(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> CreateDepartment(Department department)
            => await _departmentRepository.CreateAsync(department);
    }
}
