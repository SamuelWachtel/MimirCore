using MimirCore.Application.Models;
using MimirCore.Application.Models.Shift;

namespace MimirCore.Application.Interfaces;

public interface IShiftService
{
    Task<ShiftDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ShiftDto>> GetByEmployeeAsync(Guid employeeId, DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<ShiftDto>> GetByTeamAsync(Guid teamId, DateTime date);
    Task<ShiftDto> CreateAsync(CreateShiftDto createShiftDto);
    Task UpdateAsync(UpdateShiftDto updateShiftDto);
    Task DeleteAsync(Guid id);
    Task ClockInAsync(Guid shiftId, DateTime? clockInTime = null);
    Task ClockOutAsync(Guid shiftId, DateTime? clockOutTime = null);
    Task<IEnumerable<ShiftDto>> GetScheduleAsync(DateTime startDate, DateTime endDate, Guid? teamId = null);
}