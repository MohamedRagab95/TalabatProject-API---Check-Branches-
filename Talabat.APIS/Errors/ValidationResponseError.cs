namespace Talabat.APIS.Errors
{
    public class ValidationResponseError :ApiResponseError
    {
        public IEnumerable<string> Errors { get; set; }

        public ValidationResponseError():base(400)
        {
            Errors= new List<string>();
        }

    }
}
