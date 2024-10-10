namespace Talabat.APIS.Errors
{
    public class ServerResponseError :ApiResponseError
    {
        public string? Details { get; set; }
        public ServerResponseError(int statuscode,string? massage=null,string? details=null):base(statuscode,massage)
        {
            Details=details;
        }
    }
}
