namespace GameApi.Exceptions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public string? ExceptionMessage { get; set; }
    }
}