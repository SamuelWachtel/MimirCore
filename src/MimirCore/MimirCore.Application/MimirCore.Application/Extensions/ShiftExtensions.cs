using MimirCore.Application.Models.Shift;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class ShiftExtensions
{
    // Domain -> Application
    public static ShiftDto ToApplicationDto(this Shift shift)
    {
        return new ShiftDto
        {
            Id = shift.Id,
            EmployeeId = shift.EmployeeId,
            ShiftTemplateId = shift.ShiftTemplateId,
            StartTime = shift.StartTime,
            EndTime = shift.EndTime,
            ActualStartTime = shift.ActualStartTime,
            ActualEndTime = shift.ActualEndTime,
            Status = shift.Status,
            Notes = shift.Notes,
            CreatedAt = shift.CreatedAt,
            UpdatedAt = shift.ModifiedAt,
            Employee = shift.Employee?.ToItemListDto(),
            ShiftTemplate = shift.ShiftTemplate?.ToItemListDto()
        };
    }

    public static ShiftItemListDto ToItemListDto(this Shift shift)
    {
        return new ShiftItemListDto
        {
            Id = shift.Id,
            EmployeeName = shift.Employee != null ? $"{shift.Employee.User?.FirstName} {shift.Employee.User?.LastName}" : "",
            StartTime = shift.StartTime,
            EndTime = shift.EndTime,
            Status = shift.Status,
            ShiftTemplateName = shift.ShiftTemplate?.Name ?? ""
        };
    }

    // Application -> Domain
    public static Shift ToEntity(this CreateShiftDto createShiftDto)
    {
        return new Shift
        {
            EmployeeId = createShiftDto.EmployeeId,
            ShiftTemplateId = createShiftDto.ShiftTemplateId ?? 0,
            StartTime = createShiftDto.StartTime,
            EndTime = createShiftDto.EndTime,
            Status = "Scheduled",
            Notes = createShiftDto.Notes,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateShiftDto updateShiftDto, Shift shift)
    {
        shift.StartTime = updateShiftDto.StartTime;
        shift.EndTime = updateShiftDto.EndTime;
        shift.ActualStartTime = updateShiftDto.ActualStartTime;
        shift.ActualEndTime = updateShiftDto.ActualEndTime;
        shift.Status = updateShiftDto.Status;
        shift.Notes = updateShiftDto.Notes;
        shift.ModifiedAt = DateTime.UtcNow;
    }

    // Collection extensions
    public static IEnumerable<ShiftDto> ToApplicationDtos(this IEnumerable<Shift> shifts)
    {
        return shifts.Select(s => s.ToApplicationDto());
    }

    public static IEnumerable<ShiftItemListDto> ToItemListDtos(this IEnumerable<Shift> shifts)
    {
        return shifts.Select(s => s.ToItemListDto());
    }
}