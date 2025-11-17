using System;

namespace TaskiePet.WebApi.Models.Response;

public class ApiResponse<T> where T : class
{
    public bool IsSuccess { get; set; } = true;
    public string? Message { get; set; }
    public T? Data { get; set; }
}
