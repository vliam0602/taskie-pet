using System;

namespace TaskiePet.Application.DTOs;

public class UserCredentialDto
{
	public string Email { get; set; } = default!;
	public string Password { get; set; } = default!;
}
