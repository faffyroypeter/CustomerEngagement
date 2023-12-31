using CE.CustomerEngagementApi.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecting DbContext with InMemoryDB with DB Name
//builder.Services.AddDbContext<CustomerDBContext>(options => options.UseInMemoryDatabase("CustomerEnagementDB"));
builder.Services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("sqlConn")));

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
