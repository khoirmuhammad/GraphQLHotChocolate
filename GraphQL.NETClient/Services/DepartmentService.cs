using GraphQL.Client.Abstractions;
using GraphQL.NETClient.Models;
using GraphQL.NETClient.Types;

namespace GraphQL.NETClient.Services
{
    public class DepartmentService
    {
        private readonly IGraphQLClient _client;

        public DepartmentService(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"query{
                              departments{
                                id,
                                name,
                                employees{
                                  id,
                                  name,
                                  birthDate,
                                  isSingle,
                                  kpiValue
                                }
                              }
                            }"
                };

                var response = await _client.SendQueryAsync<DepartmentListType>(request);

                return response.Data.Departments;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Department> GetById(Guid id)
        {
            try
            {
                var query = new GraphQLRequest
                {
                    Query = @"
                        query ($deptId: UUID!) {
                          department(id: $deptId) {
                                id,
                                name,
                                employees{
                                  id,
                                  name,
                                  birthDate,
                                  isSingle,
                                  kpiValue
                                }
                              }
                        }",
                    Variables = new { deptId = id }
                };

                var response = await _client.SendQueryAsync<DepartmentType>(query);

                return response.Data.Department;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
