namespace GraphQLHotChocolate.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsSingle { get; set; }  
        public double KpiValue { get; set; }

        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }  
    }
}
