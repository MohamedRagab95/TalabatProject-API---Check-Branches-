
using Microsoft.EntityFrameworkCore;
using Talabat.APIS.Helpers;
using Talabat.Core.Repository.Contract;
using Talabat.Repository.Data;
using Talabat.Repository.Data.SeedingData;

namespace Talabat.APIS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>
                (
                  options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );

            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));


            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();



            #region Creating  An service through this object of Iserviceprovider

            using var scope = app.Services.CreateScope(); //Creating Scope

            var service = scope.ServiceProvider; // can provide any service through this object of Iserviceprovider


            var _dbcontext = service.GetRequiredService<StoreContext>();
            var loggerfactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbcontext.Database.MigrateAsync();
                await StoreContextSeed.SeedBrandsAsync(_dbcontext);
            }
            catch (Exception ex)
            {

                var logger = loggerfactory.CreateLogger<Program>();

                logger.LogError(ex, "An Error Occured");
            }

            #endregion

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
        }
    }
}
