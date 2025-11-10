using System;

namespace TaskiePet.WebApi.DTOs;

public class ApiResponse
{
    public bool IsSuccess { get; set; } = true;
    public string? Message { get; set; }
    public object? Data { get; set; }
}
