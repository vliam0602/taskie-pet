using System;
using TaskiePet.Application.AppConfiguration;

namespace TaskiePet.Application.Common;

public class AppConfiguration
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public JwtConfiguration JwtConfiguration { get; set; } = new();
}
