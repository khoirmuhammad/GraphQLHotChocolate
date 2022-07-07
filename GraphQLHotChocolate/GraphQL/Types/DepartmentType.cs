using GraphQLHotChocolate.GraphQL.Resolvers;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Types
{
    public class DepartmentType : ObjectType<Department>
    {
        protected override void Configure(IObjectTypeDescriptor<Department> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.Name).Type<StringType>();

            // call resolver, then will retreive all employees within particular department
            descriptor.Field<EmployeeResolver>(x => x.GetEmployees(default, default));
        }
    }
}
