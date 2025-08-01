namespace MimirCore.Application.Models.Common;

public class DashboardData
{
    public int TotalEmployees { get; set; }
    public int ActiveTickets { get; set; }
    public int PendingLeaveRequests { get; set; }
    public int TodayShifts { get; set; }
    public IEnumerable<DashboardMetric> RecentMetrics { get; set; } = new List<DashboardMetric>();
}