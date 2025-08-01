namespace MimirCore.Application.Interfaces;

public interface ILeaveCalculationService
{
    Task<int> CalculateRemainingDaysAsync(int employeeId, int leaveTypeId, int year);
    Task<int> CalculateUsedDaysAsync(int employeeId, int leaveTypeId, int year);
    Task<bool> CanRequestLeaveAsync(int employeeId, DateTime startDate, DateTime endDate, int leaveTypeId);
    Task<decimal> CalculateLeavePayAsync(int employeeId, int leaveDays, int leaveTypeId);
}