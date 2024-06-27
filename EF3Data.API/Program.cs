using Core.Interfaces;
using EF3Data.Application.Services;
using EF3Data.Infrastructure;
using EF3Data.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EF3Data.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure DbContext with SQLite
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=database.db"));

            // Register other services
            builder.Services.AddTransient<IDataSeeder, DataSeeder>();
            builder.Services.AddTransient<IPostRepository, PostRepository>();
            builder.Services.AddTransient<PostService>();
            builder.Services.AddTransient<DataSeedService>();

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

            // Seed data
            using (var scope = app.Services.CreateScope())
            {
                var dataSeederService = scope.ServiceProvider.GetRequiredService<DataSeedService>();
                dataSeederService.SeedAsync().Wait();
            }

            app.Run();
        }
    }
}