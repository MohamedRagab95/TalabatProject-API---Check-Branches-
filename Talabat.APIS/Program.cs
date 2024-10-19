
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIS.Errors;
using Talabat.APIS.Helpers;
using Talabat.APIS.MiddleWares;
using Talabat.APIS.ServicesExtensions;
using Talabat.Core.Entities.IdentityEntities;
using Talabat.Core.Repository.Contract;
using Talabat.Repository.Data;
using Talabat.Repository.Data.IdentityDbContext;
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

            builder.Services.AddDbContext<AppIdentityContext>
              (
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"))

              );

            builder.Services.AddSingleton<IConnectionMultiplexer>
             (o=>
                  
                {
                    var connection = builder.Configuration.GetConnectionString("Redis");
                
                    return ConnectionMultiplexer.Connect(connection);
                }
                
             );



            builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();


            builder.Services.AddScoped(typeof(IBasketRepository),typeof(BasketRepository));

            builder.Services.AddServicesExtensions();

            var app = builder.Build();



            #region Creating  An service through this object of Iserviceprovider


            using var scope = app.Services.CreateScope(); //Creating Scope

            var service = scope.ServiceProvider; // can provide any service through this object of Iserviceprovider


            var _dbcontext = service.GetRequiredService<StoreContext>();

            var _identitycontext= service.GetRequiredService<AppIdentityContext>();
            var _usermanager=service.GetRequiredService<UserManager<AppUser>>();

            var loggerfactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbcontext.Database.MigrateAsync();
                await _identitycontext.Database.MigrateAsync();

                await UserSeeding.UserSeedAsync(_usermanager);
                await StoreContextSeed.SeedBrandsAsync(_dbcontext);
            }
            catch (Exception ex)
            {

                var logger = loggerfactory.CreateLogger<Program>();

                logger.LogError(ex, "An Error Occured");
            }

            #endregion

            // Configure the HTTP request pipeline.

            app.UseMiddleware<ServerErrorHandlingMiddleWare>();



            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
