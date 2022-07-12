using GraphQL.Client.Abstractions;
using GraphQL.NETClient.Models;
using GraphQL.NETClient.Types;
using GraphQL.NETClient.Types.DepartmentType;

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
                            }",
                    Variables = null
                };

                // in order to determine "Type" see on schema graphql / depends on method name in query (API)
                var response = await _client.SendQueryAsync<DepartmentGetAllType>(request);

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
                var request = new GraphQLRequest
                {
                    // In order to set variable and its type, see on schema graphql
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

                // in order to determine "Type" see on schema graphql / depends on method name in query (API)
                var response = await _client.SendQueryAsync<DepartmentGetByIdType>(request);

                return response.Data.Department;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Department> CreateDepartment(InsertDepartmentModel input)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    // In order to set variable and its type, see on schema graphql
                    Query = @"
                        mutation($department: InsertDepartmentModelInput!){
                          createDepartment(input: $department){
                            id,
                            name
                          }
                        }",
                    Variables = new { department = input }
                };

                // in order to determine "Type" see on schema graphql / depends on method name in mutation (API)
                var response = await _client.SendMutationAsync<DepartmentCreateType>(request);
                return response.Data.CreateDepartment;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Department> UpdateDepartment(Guid id, UpdateDepartmentModel input)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    // In order to set variable and its type, see on schema graphql
                    Query = @"
                        mutation($deptId: UUID!, $department: UpdateDepartmentModelInput!){
                          updateDepartment(
                              id: $deptId,
                              input: $department
                            ) {
                                id,
                                name
                            }
                        }",
                    Variables = new { deptId = id, department = input }
                };

                // in order to determine "Type" see on schema graphql / depends on method name in mutation (API)
                var response = await _client.SendMutationAsync<DepartmentUpdateType>(request);
                return response.Data.UpdateDepartment;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteDepartment(Guid id)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    // In order to set variable and its type, see on schema graphql
                    Query = @"
                        mutation($deptId: UUID!){
                            deleteDepartment(id: $deptId)   
                    }",
                    Variables = new { deptId = id }
                };

                // in order to determine "Type" see on schema graphql / depends on method name in mutation (API)
                var response = await _client.SendMutationAsync<DepartmentDeleteType>(request);
                return response.Data.DeleteDepartment;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
