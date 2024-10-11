using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.Errors;
using Talabat.APIS.Helpers;
using Talabat.Core.Repository.Contract;
using Talabat.Repository.Data;

namespace Talabat.APIS.ServicesExtensions
{
    public static class AddServicesExtension
    {

        public static IServiceCollection AddServicesExtensions (this IServiceCollection services)
        {

           services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
           services.AddAutoMapper(typeof(MappingProfile));
          
           services.Configure<ApiBehaviorOptions>(options =>

                options.InvalidModelStateResponseFactory = (ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(p => p.Value.Errors.Count() > 0).
                                             SelectMany(p => p.Value.Errors).
                                             Select(e => e.ErrorMessage).ToList();

                    var validation = new ValidationResponseError() { Errors = errors };

                    return new BadRequestObjectResult(validation);
                }

            );


            return services;
        }

    }
}
