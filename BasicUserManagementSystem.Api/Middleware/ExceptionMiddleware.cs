using System.Net;
using Domain.Exceptions;

namespace BasicUserManagementSystem.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CostumValidationProblemDetails problem = new CostumValidationProblemDetails();

        switch (ex)
        {
            case InvalidUserCredentialsException carNotFoundException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CostumValidationProblemDetails
                {
                    Title = carNotFoundException.Message,
                    Status = (int)statusCode,
                    Detail = carNotFoundException.InnerException?.Message,
                    Type = nameof(InvalidUserCredentialsException)
                };
                break;
            
            case UserAlreadyExistsException companyNotFoundException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CostumValidationProblemDetails
                {
                    Title = companyNotFoundException.Message,
                    Status = (int)statusCode,
                    Detail = companyNotFoundException.InnerException?.Message,
                    Type = nameof(UserAlreadyExistsException)
                };
                break;
            
            case UserNotAvailableException userNotFoundException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CostumValidationProblemDetails
                {
                    Title = userNotFoundException.Message,
                    Status = (int)statusCode,
                    Detail = userNotFoundException.InnerException?.Message,
                    Type = nameof(UserNotAvailableException)
                };
                break;
            default: 
                problem = new CostumValidationProblemDetails
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Detail = ex.StackTrace
                };
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}