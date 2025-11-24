using Application.BusinessLogics;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories.Class;
using Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace CXS_WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ===============================
        // Database Configuration (PostgreSQL - Neon)
        // ===============================
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // ===============================
        // Dependency Injection Setup
        // ===============================
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IQuestionService, QuestionService>();

        // ===============================
        // Add Core Services
        // ===============================
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.Run();
    }
}