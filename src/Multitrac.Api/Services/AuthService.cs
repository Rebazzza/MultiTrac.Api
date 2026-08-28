using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Exceptions;
using Multitrac.Infrastructure.Data;

namespace Multitrac.Api.Services;

public class AuthService : IAuthService
{
    private readonly BdmultitracContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(BdmultitracContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username.ToLower() == request.Username.ToLower());

        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Credenciales inválidas"
            };
        }

        if (!user.IsActive)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Usuario desactivado"
            };
        }

        user.LastLoginAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        var token = GenerateJwtToken(user);

        return new AuthResponse
        {
            Success = true,
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(8),
            Username = user.Username,
            FullName = user.FullName,
            Roles = new[] { user.Role },
            Message = "Login exitoso"
        };
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Username.ToLower() == request.Username.ToLower()))
        {
            return new AuthResponse
            {
                Success = false,
                Message = "El nombre de usuario ya existe"
            };
        }

        var user = new Usuario
        {
            Username = request.Username,
            PasswordHash = HashPassword(request.Password),
            FullName = request.FullName,
            Email = request.Email,
            Role = "User",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();

        var token = GenerateJwtToken(user);

        return new AuthResponse
        {
            Success = true,
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(8),
            Username = user.Username,
            FullName = user.FullName,
            Roles = new[] { user.Role },
            Message = "Registro exitoso"
        };
    }

    public async Task<AuthResponse> ChangePasswordAsync(string username, ChangePasswordRequest request)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());

        if (user == null)
        {
            return new AuthResponse { Success = false, Message = "Usuario no encontrado" };
        }

        if (!VerifyPassword(request.CurrentPassword, user.PasswordHash))
        {
            return new AuthResponse { Success = false, Message = "Contraseña actual incorrecta" };
        }

        user.PasswordHash = HashPassword(request.NewPassword);
        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            Success = true,
            Message = "Contraseña actualizada exitosamente"
        };
    }

    public async Task<UsuarioDto?> GetCurrentUserAsync(string username)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());

        if (user == null) return null;

        return new UsuarioDto
        {
            Id = user.Id,
            Username = user.Username,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            LastLoginAt = user.LastLoginAt
        };
    }

    private string GenerateJwtToken(Usuario user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            jwtSettings["Key"] ?? "MultitracSuperSecretKey2024!@#$%^&*()_+AbcdefGhiJKLmNoPqRsTuVwXyZ123"));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (!string.IsNullOrEmpty(user.FullName))
            claims.Add(new Claim("fullName", user.FullName));

        if (!string.IsNullOrEmpty(user.Email))
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"] ?? "MultitracAPI",
            audience: jwtSettings["Audience"] ?? "MultitracWeb",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var saltedPassword = $"Multitrac_{password}_Salt_2024";
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        return Convert.ToBase64String(bytes);
    }

    private static bool VerifyPassword(string password, string hash)
    {
        using var sha256 = SHA256.Create();
        var saltedPassword = $"Multitrac_{password}_Salt_2024";
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        var computedHash = Convert.ToBase64String(bytes);
        return computedHash == hash;
    }
}
