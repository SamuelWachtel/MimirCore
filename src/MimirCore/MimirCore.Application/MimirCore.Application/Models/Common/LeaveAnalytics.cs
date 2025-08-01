namespace MimirCore.Application.Models.Common;

public class LeaveAnalytics
{
    public int TotalLeaveRequests { get; set; }
    public int ApprovedLeaves { get; set; }
    public int PendingLeaves { get; set; }
    public int RejectedLeaves { get; set; }
    public Dictionary<string, int> LeavesByType { get; set; } = new();
    public Dictionary<string, int> LeavesByMonth { get; set; } = new();
}