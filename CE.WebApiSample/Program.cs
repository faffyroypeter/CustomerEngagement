using CE.WebApiSample.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1.nuget -> Microoft.EntityFramework.Core
// 2.nuget -> Microsoft.Frameworkcore.ImMemory -> Package 

//builder.Services.AddDbContext<EmployeeDBContext>(options => options.UseInMemoryDatabase("EmployeeDB"));
builder.Services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("NafTeam2ConnString"))

);

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
