namespace Multitrac.Application.DTOs;

public class LoginRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class RegisterRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? FullName { get; set; }
    public string? Email { get; set; }
}

public class AuthResponse
{
    public bool Success { get; set; }
    public string Token { get; set; } = null!;
    public DateTime Expiration { get; set; }
    public string Username { get; set; } = null!;
    public string? FullName { get; set; }
    public string[] Roles { get; set; } = Array.Empty<string>();
    public string? Message { get; set; }
}

public class ChangePasswordRequest
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
