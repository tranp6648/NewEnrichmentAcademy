using EnrichmentAcademy.Midlewares;
using EnrichmentAcademy.Models;
using EnrichmentAcademy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow requests from http://localhost:5173
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Configure database context
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnect"];
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));

// Register your AccountService implementation
builder.Services.AddScoped<AccoutService, AccountServiceImpl>();
builder.Services.AddScoped<FacultyServiece, FacultyServiceImpl>();

var app = builder.Build();
app.UseMiddleware<CheckOTPMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS middleware
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
