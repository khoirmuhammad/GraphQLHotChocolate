using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.Models;
using HotChocolate.Resolvers;

namespace GraphQLHotChocolate.GraphQL.Resolvers
{
    public class DepartmentResolver
    {
        private readonly IDepartmentRepository _department;

        public DepartmentResolver([Service] IDepartmentRepository department)
        {
            _department = department;
        }

        /*
         * Definition : Thise resolver will be included to Employee Type
         * Objectives : When we try to get employee by id, then we able find department of the employee
         * 
         * Parameter : Object from parent, in this case Employee is parent data
         * Relation : One to Many (one department can contain many employees)
         */
        public async Task<Department?> GetDepartment([Parent] Employee employee, IResolverContext ctx)
        {
            return await _department.GetByIdAsync(employee.DepartmentId);
        }
    }
}
