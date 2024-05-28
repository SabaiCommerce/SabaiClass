using Microsoft.EntityFrameworkCore;
using WebApplication1.Config;
using WebApplication1.Entities;
using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<SabaiClassContext>(options =>
{
    options.UseMySQL(cs);
});

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

// app.MapStudentEndpoints();

app.Run();
