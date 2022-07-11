using GraphQL.NETClient.Models;

namespace GraphQL.NETClient.Types.DepartmentType
{
    public class DepartmentGetByIdType
    {
        // in order to determine "Type" see on schema graphql / depends on method name in query (API)
        public Department Department { get; set; }
    }
}
