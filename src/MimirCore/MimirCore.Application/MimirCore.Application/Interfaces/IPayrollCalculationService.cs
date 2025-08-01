namespace MimirCore.Application.Interfaces;

public interface IPayrollCalculationService
{
    Task<decimal> CalculateGrossPayAsync(int employeeId, DateTime startDate, DateTime endDate);
    Task<decimal> CalculateOvertimePayAsync(int employeeId, DateTime startDate, DateTime endDate);
    Task<decimal> CalculateLeaveDeductionsAsync(int employeeId, DateTime startDate, DateTime endDate);
    Task<decimal> CalculateNetPayAsync(int employeeId, DateTime startDate, DateTime endDate);
}