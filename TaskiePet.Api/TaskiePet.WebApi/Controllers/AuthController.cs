using Microsoft.AspNetCore.Mvc;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Domain.Entities;
using TaskiePet.Application.Common;
using TaskiePet.Application.Constants;
using TaskiePet.WebApi.Models.Response;
using TaskiePet.Application.DTOs;
using TaskiePet.WebApi.Models.Request;

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
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // verify login
        var account = await userService
            .GetUserByEmailAndPasswordAsync(new UserCredentialDto { Email = request.Email, Password = request.Password });

        if (account == null)
        {
            return Unauthorized(new ApiResponse<object>
            {
                IsSuccess = false,
                Message = ErrorMessages.WrongUsernamePassword
            });
        }
        // login success -> issue (access token, refresh token)
        var tokens = GenerateTokens(account);

        return Ok(new ApiResponse<TokenResponse>
        {
            Message = SuccessMessages.LoginSuccess,
            Data = tokens
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginRequest request)
    {
        await userService.CreateNewAccountAsync(new UserCredentialDto { Email = request.Email, Password = request.Password });
        return CreatedAtAction(nameof(Register), new ApiResponse<object>
        {
            Message = SuccessMessages.RegisterSuccess,
            Data = request.Email
        });
    }

    private TokenResponse GenerateTokens(User user)
    {
        var jwtConfig = appConfig.JwtConfiguration;
        var issueDate = DateTime.Now;

        var accessToken = user.GenerateJwt(
            jwtConfig.SecretKey, issueDate.AddHours(jwtConfig.ATExpHours));

        var refreshToken = user.GenerateJwt(
            jwtConfig.SecretKey, issueDate.AddHours(jwtConfig.RTExpHours));

        return new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}

