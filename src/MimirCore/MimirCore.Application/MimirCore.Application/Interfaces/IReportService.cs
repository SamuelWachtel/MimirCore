namespace MimirCore.Application.Interfaces;

public interface IReportService
{
    Task<byte[]> GenerateEmployeeReportAsync(int? departmentId = null, int? teamId = null);
    Task<byte[]> GenerateLeaveReportAsync(int? employeeId = null, DateTime? startDate = null, DateTime? endDate = null);
    Task<byte[]> GenerateShiftReportAsync(DateTime startDate, DateTime endDate, int? teamId = null);
    Task<byte[]> GenerateTicketReportAsync(int? categoryId = null, DateTime? startDate = null, DateTime? endDate = null);
    Task<byte[]> GeneratePayrollReportAsync(DateTime startDate, DateTime endDate, int? departmentId = null);
}