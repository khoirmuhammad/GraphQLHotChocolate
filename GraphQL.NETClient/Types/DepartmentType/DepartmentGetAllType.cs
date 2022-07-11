using GraphQL.NETClient.Models;

namespace GraphQL.NETClient.Types.DepartmentType
{
    public class DepartmentGetAllType
    {
        // in order to determine "Type" see on schema graphql / depends on method name in query (API)
        public List<Department> Departments { get; set; }
    }
}
