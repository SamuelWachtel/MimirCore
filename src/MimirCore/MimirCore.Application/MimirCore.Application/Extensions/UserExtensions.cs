using MimirCore.Application.Models.User;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class UserExtensions
{
    public static UserDto ToApplicationDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            IsActive = user.IsActive,
            LastLoginAt = user.LastLoginAt,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.ModifiedAt
        };
    }

    public static UserItemListDto ToItemListDto(this User user)
    {
        return new UserItemListDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsActive = user.IsActive,
            LastLoginAt = user.LastLoginAt
        };
    }

    public static User ToEntity(this CreateUserDto createUserDto)
    {
        return new User
        {
            Username = createUserDto.Username,
            Email = createUserDto.Email,
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            PhoneNumber = createUserDto.PhoneNumber,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateUserDto updateUserDto, User user)
    {
        user.Username = updateUserDto.Username;
        user.Email = updateUserDto.Email;
        user.FirstName = updateUserDto.FirstName;
        user.LastName = updateUserDto.LastName;
        user.PhoneNumber = updateUserDto.PhoneNumber;
        user.IsActive = updateUserDto.IsActive;
        user.ModifiedAt = DateTime.UtcNow;
    }

    public static IEnumerable<UserDto> ToApplicationDtos(this IEnumerable<User> users)
    {
        return users.Select(u => u.ToApplicationDto());
    }

    public static IEnumerable<UserItemListDto> ToItemListDtos(this IEnumerable<User> users)
    {
        return users.Select(u => u.ToItemListDto());
    }
}