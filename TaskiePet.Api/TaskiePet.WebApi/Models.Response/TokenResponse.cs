using System;

namespace TaskiePet.WebApi.Models.Response;

public class TokenResponse
{
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
