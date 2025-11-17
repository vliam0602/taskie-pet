using System;
using System.ComponentModel.DataAnnotations;

namespace TaskiePet.WebApi.Models.Request;

public class LoginRequest
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = default!;

	[Required]
	public string Password { get; set; } = string.Empty;
}
