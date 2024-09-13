using EvolveDb;
using GymBroINFRA.Context;
using GymBroINFRA.Repository;

using Microsoft.EntityFrameworkCore;
using Serilog;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

       // builder.Services.AddScoped<IMeasuresService, MeasuresServiceImplementation>();

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        builder.Services.AddDbContext<MySQLContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)));

            if (builder.Environment.IsDevelopment())
            {
                MigrateDatabase(connectionString);
            }
        });




        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        void MigrateDatabase(string connectionString)
        {
            try
            {
                // Corrigido: instancia um objeto da classe MySqlConnection
                using (var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    // Abre a conexão
                    evolveConnection.Open();

                    // Instancia Evolve e define suas propriedades
                    var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                    {
                        Locations = new List<string>() { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    // Executa a migração
                    evolve.Migrate();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }

        }
    }
}