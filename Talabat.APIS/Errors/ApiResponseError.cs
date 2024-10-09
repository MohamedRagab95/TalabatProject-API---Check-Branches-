
namespace Talabat.APIS.Errors
{
    public class ApiResponseError
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponseError(int statuscode ,string? massage =null)
        {
            StatusCode = statuscode;

            Message = massage?? GetMassageOfError(statuscode);
        }

        private string? GetMassageOfError(int statuscode)
        {
            return statuscode switch
            {
                400 => "Bad Request , You Have Made",
                401 => "You aren't authorized",
                404 => "Resource is not found",
                500 => "Server Error",
                _ => null

            };

        }
    }
}
