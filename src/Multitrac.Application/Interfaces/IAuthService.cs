using Multitrac.Application.DTOs;

namespace Multitrac.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> ChangePasswordAsync(string username, ChangePasswordRequest request);
    Task<UsuarioDto?> GetCurrentUserAsync(string username);
}

public class UsuarioDto
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string Role { get; set; } = "User";
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}
