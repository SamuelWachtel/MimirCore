using MimirCore.Application.Models;
using MimirCore.Application.Models.User;

namespace MimirCore.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(UserDto user);
    string GenerateRefreshToken();
    Task<bool> ValidateTokenAsync(string token);
    Task<int> GetUserIdFromTokenAsync(string token);
}