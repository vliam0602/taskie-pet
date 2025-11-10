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
        try
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
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new ApiResponse
            {
                IsSuccess = false,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse
            {
                IsSuccess = false,
                Message = ErrorMessages.UnexpectedError(ex.Message)
            });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginDto registerDto)
    {
        try
        {
            await userService.CreateNewAccountAsync(registerDto.Email, registerDto.Password);
            return CreatedAtAction(nameof(Register), new ApiResponse
            {
                Message = SuccessMessages.RegisterSuccess,
                Data = registerDto.Email
            });
        }
        catch (DuplicateNameException ex)
        {
            return Conflict(new ApiResponse
            {
                IsSuccess = false,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse
            {
                IsSuccess = false,
                Message = ErrorMessages.UnexpectedError(ex.Message)
            });
        }
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

