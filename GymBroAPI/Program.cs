using EvolveDb;
using GymBroINFRA.Context;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService;
using Microsoft.EntityFrameworkCore;
using Serilog;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.AddScoped<IMeasuresService, MeasuresService>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


        var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

        builder.Services.AddDbContext<MySQLContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        
    }
}