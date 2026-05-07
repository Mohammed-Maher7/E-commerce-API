
namespace E_commerce.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode {  get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message) 
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultErrorMessageForStatusCode(statusCode);
        }

        private string? GetDefaultErrorMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "bad request",
                401 => "unauthorized",
                404 => "not found",
                500 => "server error",
                _ => null
            };
        }
    }
}
