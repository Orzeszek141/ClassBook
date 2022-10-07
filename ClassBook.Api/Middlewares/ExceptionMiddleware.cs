using ClassBook.BLL.Exceptions;

namespace ClassBook.Api.Middlewares
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleExceptionAsync(exception, context);
            }
        }

        private static async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
        {
            var (statusCode, error) = exception switch
            {
                CustomException => (StatusCodes.Status400BadRequest,
                    new ErrorDto(StatusCodes.Status400BadRequest.ToString(), exception.Message)),
                _ => (StatusCodes.Status500InternalServerError, new ErrorDto(StatusCodes.Status500InternalServerError.ToString(), "Internal Server error."))
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(error);
        }

        private record ErrorDto(string StatusCode, string Description);
    }
}
