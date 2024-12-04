using Carter;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application;
using MinimalApi.Application.RepositoryInterfaces.Students;
using MinimalApi.Application.ServiceInterfaces.Students;
using MinimalApi.Infrastructure;
using MinimalApi.Infrastructure.Persistence;
using MinimalApi.Infrastructure.RepositoryImplementations.Students;
using MinimalApi.Infrastructure.ServiceImplementations.Students;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddCarter();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddDbContext<RndDbContext>(options =>
options.UseNpgsql(configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly(typeof(RndDbContext).Assembly.FullName)));

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

app.MapCarter();

app.Run();
