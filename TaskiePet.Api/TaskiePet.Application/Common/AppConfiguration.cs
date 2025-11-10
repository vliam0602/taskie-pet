using System;
using TaskiePet.Application.AppConfiguration;

namespace TaskiePet.Application.Common;

public class AppConfiguration
{
    public ConnectionStrings ConnectionStrings { get; set; } = default!;
    public JwtConfiguration JwtConfiguration { get; set; } = default!;
}
