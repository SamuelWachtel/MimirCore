using MimirCore.Application.Models;
using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Interfaces;

public interface IAnalyticsService
{
    Task<EmployeeAnalytics> GetEmployeeAnalyticsAsync(DateTime startDate, DateTime endDate);
    Task<LeaveAnalytics> GetLeaveAnalyticsAsync(DateTime startDate, DateTime endDate);
    Task<ShiftAnalytics> GetShiftAnalyticsAsync(DateTime startDate, DateTime endDate);
    Task<TicketAnalytics> GetTicketAnalyticsAsync(DateTime startDate, DateTime endDate);
}