using System;

namespace TaskiePet.Application.Constants;

public static class ErrorMessages
{
    // System Errors
    public static string UnexpectedError(string err) => $"Unexpected error: {err}";

    // Business Errors
    public const string WrongUsernamePassword = "Wrong username/password.";
    public const string DuplicateEmail = "Email is already registered.";
}
