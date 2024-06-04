using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Core.Repositories.Interfaces;
using Infrastructure.Repositories;
using Core.DTOs.Mapping;
using Core.Services.Interfaces;
using Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(sqlConnection)
);

builder.Services.AddAutoMapper(typeof(ActivityTaskDTOMapping));

builder.Services.AddScoped<IActivityTaskRepository, ActivityTaskRepository>();
builder.Services.AddScoped<IActivityTaskService, ActivityTaskService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
