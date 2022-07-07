using GraphQLHotChocolate.GraphQL.Resolvers;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Types
{
    public class EmployeeType : ObjectType<Employee>
    {
        protected override void Configure(IObjectTypeDescriptor<Employee> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field(x => x.IsSingle).Type<BooleanType>();
            descriptor.Field(x => x.BirthDate).Type<DateTimeType>();
            descriptor.Field(x => x.KpiValue).Type<FloatType>();

            // call resolver, then will retreive department information for particular employee
            descriptor.Field<DepartmentResolver>(x => x.GetDepartment(default, default));
        }
    }
}
