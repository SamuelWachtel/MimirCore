using MimirCore.Application.Models;
using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardData> GetDashboardDataAsync(int? departmentId = null, int? teamId = null);
    Task<IEnumerable<DashboardMetric>> GetMetricsAsync(string metricType, DateTime startDate, DateTime endDate);
}