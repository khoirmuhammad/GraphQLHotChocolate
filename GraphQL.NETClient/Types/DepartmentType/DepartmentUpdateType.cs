using GraphQL.NETClient.Models;

namespace GraphQL.NETClient.Types.DepartmentType
{
    public class DepartmentUpdateType
    {
        // in order to determine "Type" see on schema graphql / depends on method name in mutation (API)
        public Department UpdateDepartment { get; set; }
    }
}
