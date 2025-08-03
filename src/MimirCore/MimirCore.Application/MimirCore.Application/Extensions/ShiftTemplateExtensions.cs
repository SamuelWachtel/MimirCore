using MimirCore.Application.Models.Shift;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class ShiftTemplateExtensions
{
    public static ShiftTemplateDto ToApplicationDto(this ShiftTemplate shiftTemplate)
    {
        return new ShiftTemplateDto
        {
            Id = shiftTemplate.Id,
            Name = shiftTemplate.Name,
            StartTime = shiftTemplate.StartTime,
            EndTime = shiftTemplate.EndTime,
            Description = shiftTemplate.Description,
            CreatedAt = shiftTemplate.CreatedAt,
            UpdatedAt = shiftTemplate.ModifiedAt
        };
    }

    public static ShiftTemplateItemListDto ToItemListDto(this ShiftTemplate shiftTemplate)
    {
        return new ShiftTemplateItemListDto
        {
            Id = shiftTemplate.Id,
            Name = shiftTemplate.Name,
            StartTime = shiftTemplate.StartTime,
            EndTime = shiftTemplate.EndTime,
        };
    }

    public static IEnumerable<ShiftTemplateDto> ToApplicationDtos(this IEnumerable<ShiftTemplate> shiftTemplates)
    {
        return shiftTemplates.Select(st => st.ToApplicationDto());
    }

    public static IEnumerable<ShiftTemplateItemListDto> ToItemListDtos(this IEnumerable<ShiftTemplate> shiftTemplates)
    {
        return shiftTemplates.Select(st => st.ToItemListDto());
    }
}