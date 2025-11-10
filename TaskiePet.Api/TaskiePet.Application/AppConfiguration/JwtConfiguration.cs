using System;

namespace TaskiePet.Application.AppConfiguration;

public class JwtConfiguration
{
    public string SecretKey { get; set; } = default!;
    public int ATExpHours { get; set; }
    public int RTExpHours { get; set; }
}
