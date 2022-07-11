using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class EmployeeMutation
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeMutation(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public record InsertEmployeeModel(
            string name, DateTime birthDate, bool isSingle, double kpiValue, Guid departmentId
        );

        public record UpdateEmployeeModel(
            bool isSingle, double kpiValue, Guid departmentId
        );

        public async Task<Employee> CreateEmployee(InsertEmployeeModel input)
        { 
            return await _employeeRepository.CreateAsync(new Employee()
            {
                Id = Guid.NewGuid(),
                Name = input.name,
                BirthDate = input.birthDate,
                IsSingle = input.isSingle,
                KpiValue = input.kpiValue,
                DepartmentId = input.departmentId
            });
        } 

        public async Task<Employee> UpdateEmployee(Guid id, UpdateEmployeeModel input)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);
            employee.IsSingle = input.isSingle;
            employee.KpiValue = input.kpiValue;
            employee.DepartmentId = input.departmentId;

            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            return await _employeeRepository.DeleteAsync(id);
        }
    }
}
