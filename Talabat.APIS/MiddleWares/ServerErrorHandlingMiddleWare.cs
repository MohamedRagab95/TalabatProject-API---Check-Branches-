using System.Text.Json;
using Talabat.APIS.Errors;

namespace Talabat.APIS.MiddleWares
{
    public class ServerErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ServerErrorHandlingMiddleWare> _logger;
        private readonly IWebHostEnvironment _env;

        public ServerErrorHandlingMiddleWare(RequestDelegate next , ILogger<ServerErrorHandlingMiddleWare> logger,IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex )
            {

                _logger.LogError(ex, ex.Message);

                #region Header

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode =(int) StatusCodes.Status500InternalServerError;

                #endregion


                var response = _env.IsDevelopment() ?
                                new ServerResponseError((int)StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace.ToString())
                                : new ServerResponseError((int)StatusCodes.Status500InternalServerError);

                var option = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                


                var json = JsonSerializer.Serialize(response,option);


                 await httpContext.Response.WriteAsync(json);

            }






        }






    }
}
