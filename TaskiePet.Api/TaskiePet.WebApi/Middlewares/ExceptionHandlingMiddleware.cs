using System;
using System.Data;
using System.Net;
using System.Text.Json;
using TaskiePet.Application.Constants;
using TaskiePet.WebApi.DTOs;

namespace TaskiePet.WebApi.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate _next,
    ILogger<ExceptionHandlingMiddleware> _logger
)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode; // default 500 error
        string errMessage = ex.Message;

        if (ex is UnauthorizedAccessException) statusCode = HttpStatusCode.Unauthorized; // 401 error
        else if (ex is DuplicateNameException) statusCode = HttpStatusCode.Conflict; // 409 error
        else if (ex is KeyNotFoundException) statusCode = HttpStatusCode.NotFound;
        else if (ex is ArgumentException) statusCode = HttpStatusCode.BadRequest; // 400 error
        else
        {   // default 500 error
            statusCode = HttpStatusCode.InternalServerError;
            errMessage = ErrorMessages.UnexpectedError(ex.Message);
        }

        var apiResponse = new ApiResponse
        {
            IsSuccess = false,
            Message = errMessage
        };

        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var result = JsonSerializer.Serialize(apiResponse, serializeOptions);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}
