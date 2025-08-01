using MimirCore.Api.Models.User;
using MimirCore.Application.Models.User;
using UserPaginatedListResponse = MimirCore.Api.Models.User.UserPaginatedListResponse;

namespace MimirCore.Api.Extensions;

public static class UserApiExtensions
{
    // Application -> API
    public static UserResponse ToApiDto(this UserDto userDto)
    {
        return new UserResponse
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            PhoneNumber = userDto.PhoneNumber,
            IsActive = userDto.IsActive,
            LastLoginAt = userDto.LastLoginAt,
            CreatedAt = userDto.CreatedAt,
            UpdatedAt = userDto.UpdatedAt
        };
    }

    public static UserListItemDto ToApiDto(this Application.Models.User.UserItemListDto userItemDto)
    {
        return new UserListItemDto
        {
            Id = userItemDto.Id,
            Username = userItemDto.Username,
            Email = userItemDto.Email,
            FirstName = userItemDto.FirstName,
            LastName = userItemDto.LastName,
            IsActive = userItemDto.IsActive,
            LastLoginAt = userItemDto.LastLoginAt
        };
    }

    // API -> Application
    public static CreateUserDto ToApplicationDto(this CreateUserRequest createUserRequest)
    {
        return new CreateUserDto
        {
            Username = createUserRequest.Username,
            Email = createUserRequest.Email,
            FirstName = createUserRequest.FirstName,
            LastName = createUserRequest.LastName,
            PhoneNumber = createUserRequest.PhoneNumber
        };
    }

    public static UpdateUserDto ToApplicationDto(this UpdateUserRequest updateUserRequest)
    {
        return new UpdateUserDto
        {
            Username = updateUserRequest.Username,
            Email = updateUserRequest.Email,
            FirstName = updateUserRequest.FirstName,
            LastName = updateUserRequest.LastName,
            PhoneNumber = updateUserRequest.PhoneNumber,
            IsActive = updateUserRequest.IsActive
        };
    }

    // Collection extensions
    public static IEnumerable<UserResponse> ToApiDtos(this IEnumerable<UserDto> users)
    {
        return users.Select(u => u.ToApiDto());
    }

    public static IEnumerable<UserListItemDto> ToApiDtos(this IEnumerable<Application.Models.User.UserItemListDto> users)
    {
        return users.Select(u => u.ToApiDto());
    }

    // Pagination extensions
    public static UserPaginatedListResponse ToApiResponse(this Application.Models.User.UserPaginatedListResponse appResponse)
    {
        return new UserPaginatedListResponse(
            appResponse.Items.ToApiDtos().ToList(),
            appResponse.PageNumber,
            appResponse.PageSize,
            appResponse.TotalCount
        );
    }
}