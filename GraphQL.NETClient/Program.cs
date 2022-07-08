using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.NETClient.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string graphQLURI = builder.Configuration["GraphQLURI"];

builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(graphQLURI, new NewtonsoftJsonSerializer()));

builder.Services.AddScoped<DepartmentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
