using MimirCore.Application.Models;
using MimirCore.Application.Models.User;

namespace MimirCore.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<UserDto> GetByUsernameAsync(string username);
    Task<UserDto> CreateAsync(CreateUserDto createUserDto, string password);
    Task UpdateAsync(UpdateUserDto updateUserDto);
    Task DeleteAsync(Guid id);
    Task<bool> ValidatePasswordAsync(string username, string password);
    Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
    Task ResetPasswordAsync(Guid userId, string newPassword);
}