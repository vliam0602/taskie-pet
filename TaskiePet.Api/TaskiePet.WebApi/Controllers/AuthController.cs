using Microsoft.AspNetCore.Mvc;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Domain.Entities;
using TaskiePet.WebApi.DTOs;
using TaskiePet.Application.Common;
using TaskiePet.Application.Constants;
using System.Data;

namespace TaskiePet.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IUserService userService,
    AppConfiguration appConfig) : ControllerBase
{
    [HttpGet("hash-password")]
    public IActionResult Test(string password)
    {
        return Ok(password.Hash());
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        // verify login
        var account = await userService
            .GetUserByEmailAndPasswordAsync(loginDto.Email, loginDto.Password);

        if (account == null)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                Message = ErrorMessages.WrongUsernamePassword
            });
        }
        // login success -> issue (access token, refresh token)
        var tokens = GenerateTokens(account);

        return Ok(new ApiResponse
        {
            Message = SuccessMessages.LoginSuccess,
            Data = tokens
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginDto registerDto)
    {
        await userService.CreateNewAccountAsync(registerDto.Email, registerDto.Password);
        return CreatedAtAction(nameof(Register), new ApiResponse
        {
            Message = SuccessMessages.RegisterSuccess,
            Data = registerDto.Email
        });
    }

    private TokenDto GenerateTokens(User user)
    {
        var jwtConfig = appConfig.JwtConfiguration;
        var issueDate = DateTime.Now;

        var accessToken = user.GenerateJwt(
            jwtConfig.SecretKey, issueDate.AddHours(jwtConfig.ATExpHours));

        var refreshToken = user.GenerateJwt(
            jwtConfig.SecretKey, issueDate.AddHours(jwtConfig.RTExpHours));

        return new TokenDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}

