using BackEnd.Middleware;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Connection String
builder.Services.AddDbContext<NorthWindContext>(options =>
                        options.UseSqlServer(
                            builder
                            .Configuration
                            .GetConnectionString("DefaultConnection")));

string connString = builder
                            .Configuration
                            .GetConnectionString("DefaultConnection");

Util.ConnectionString = connString;

#endregion


// Add services to the container.

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
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
