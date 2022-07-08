namespace GraphQLHotChocolate.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public IList<Employee> Employees { get; set; } = new List<Employee>();
    }
}
