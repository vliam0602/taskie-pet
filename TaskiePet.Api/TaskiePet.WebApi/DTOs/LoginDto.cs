using System;
using System.ComponentModel.DataAnnotations;

namespace TaskiePet.WebApi.DTOs;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = string.Empty;
}