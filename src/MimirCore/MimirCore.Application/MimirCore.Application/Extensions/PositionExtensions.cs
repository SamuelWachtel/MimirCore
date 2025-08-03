using MimirCore.Application.Models.Position;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class PositionExtensions
{
    public static PositionDto ToApplicationDto(this Position position)
    {
        return new PositionDto
        {
            Id = position.Id,
            Title = position.Title,
            Description = position.Description,
            DepartmentId = position.DepartmentId,
            MinSalary = position.MinSalary,
            MaxSalary = position.MaxSalary,
            CreatedAt = position.CreatedAt,
            UpdatedAt = position.ModifiedAt
        };
    }

    public static PositionItemListDto ToItemListDto(this Position position)
    {
        return new PositionItemListDto
        {
            Id = position.Id,
            Title = position.Title,
            MinSalary = position.MinSalary,
            MaxSalary = position.MaxSalary
        };
    }

    public static Position ToEntity(this CreatePositionDto createPositionDto)
    {
        return new Position
        {
            Title = createPositionDto.Title,
            Description = createPositionDto.Description,
            DepartmentId = createPositionDto.DepartmentId,
            MinSalary = createPositionDto.MinSalary,
            MaxSalary = createPositionDto.MaxSalary,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdatePositionDto updatePositionDto, Position position)
    {
        position.Title = updatePositionDto.Title;
        position.Description = updatePositionDto.Description;
        position.DepartmentId = updatePositionDto.DepartmentId;
        position.MinSalary = updatePositionDto.MinSalary;
        position.MaxSalary = updatePositionDto.MaxSalary;
        position.ModifiedAt = DateTime.UtcNow;
    }

    public static IEnumerable<PositionDto> ToApplicationDtos(this IEnumerable<Position> positions)
    {
        return positions.Select(p => p.ToApplicationDto());
    }

    public static IEnumerable<PositionItemListDto> ToItemListDtos(this IEnumerable<Position> positions)
    {
        return positions.Select(p => p.ToItemListDto());
    }
}