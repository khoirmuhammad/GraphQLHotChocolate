using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLHotChocolate.Models.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.IsSingle).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.KpiValue).IsRequired();

            builder.HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(p => p.DepartmentId);
        }
    }
}
