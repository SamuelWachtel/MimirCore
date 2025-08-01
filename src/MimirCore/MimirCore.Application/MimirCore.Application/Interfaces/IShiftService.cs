using MimirCore.Application.Models;
using MimirCore.Application.Models.Shift;

namespace MimirCore.Application.Interfaces;

public interface IShiftService
{
    Task<ShiftDto> GetByIdAsync(int id);
    Task<IEnumerable<ShiftDto>> GetByEmployeeAsync(int employeeId, DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<ShiftDto>> GetByTeamAsync(int teamId, DateTime date);
    Task<ShiftDto> CreateAsync(CreateShiftDto createShiftDto);
    Task UpdateAsync(UpdateShiftDto updateShiftDto);
    Task DeleteAsync(int id);
    Task ClockInAsync(int shiftId, DateTime? clockInTime = null);
    Task ClockOutAsync(int shiftId, DateTime? clockOutTime = null);
    Task<IEnumerable<ShiftDto>> GetScheduleAsync(DateTime startDate, DateTime endDate, int? teamId = null);
}