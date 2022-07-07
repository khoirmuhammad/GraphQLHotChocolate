using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;
using HotChocolate.Resolvers;

namespace GraphQLHotChocolate.GraphQL.Resolvers
{
    public class EmployeeResolver
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeResolver([Service] IEmployeeRepository employee)
        {
            _employee = employee;
        }

        /*
         * Definition : Thise resolver will be included to Department Type
         * Objectives : When we try to get department by id (for example : IT Department), then we able find all employees under IT department
         *  
         *  Parameter : Object from parent, in this case Department is parent data
         *  Relation : One to Many (one department can contain many employees)
         */
        public async Task<IEnumerable<Employee>> GetEmployees([Parent] Department department, IResolverContext ctx)
        {
            var data = await _employee.GetAllAsync();

            return data.Where(x => x.DepartmentId.Equals(department.Id));
        }
    }
}
