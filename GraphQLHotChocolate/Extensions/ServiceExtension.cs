using GraphQLHotChocolate.Contracts;
using GraphQLHotChocolate.GraphQL;
using GraphQLHotChocolate.GraphQL.Mutations;
using GraphQLHotChocolate.GraphQL.Queries;
using GraphQLHotChocolate.GraphQL.Types;
using GraphQLHotChocolate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolate.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AppContext>(
                a => a.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void ConfigureGraphQL(this IServiceCollection services)
        {
            services
            .AddGraphQLServer()
                .AddType<DepartmentType>()
                .AddType<EmployeeType>()
                    .AddQueryType(d => d.Name("Query"))
                        .AddTypeExtension<DepartmentQuery>()
                        .AddTypeExtension<EmployeeQuery>()
                    .AddMutationType(d => d.Name("Mutation"))
                        .AddTypeExtension<DepartmentMutation>()
                        .AddTypeExtension<EmployeeMutation>();
        }
    }
}
