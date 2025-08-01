namespace MimirCore.Application.Interfaces;

public interface IShiftCalculationService
{
    Task<int> CalculateShiftDurationAsync(DateTime startTime, DateTime endTime);
    Task<int> CalculateOvertimeMinutesAsync(int shiftId);
    Task<decimal> CalculateShiftPayAsync(int shiftId);
    Task<bool> HasShiftConflictAsync(int employeeId, DateTime startTime, DateTime endTime, int? excludeShiftId = null);
}