using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class DepartmentMutation
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentMutation(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #region Records
        public record InsertDepartmentModel(Guid id, string name);
        public record UpdateDepartmentModel(string name);
        #endregion


        #region Mutation Methods
        public async Task<Department> CreateDepartment(InsertDepartmentModel input)
        {
            return await _departmentRepository.CreateAsync(new Department
            {
                Id = input.id,
                Name = input.name
            });
        }

        public async Task<Department> UpdateDepartment(Guid id, UpdateDepartmentModel input)
        {
            Department department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
                throw new Exception();

            department.Name = input.name;

            return await _departmentRepository.UpdateAsync(department);
        }

        public async Task<bool> DeleteDepartment(Guid id)
        {
            return await _departmentRepository.DeleteAsync(id);
        }
        #endregion
    }
}
