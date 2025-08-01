namespace MimirCore.Application.Models.Common;

public class ShiftAnalytics
{
    public int TotalShifts { get; set; }
    public int CompletedShifts { get; set; }
    public int MissedShifts { get; set; }
    public decimal AverageHoursPerEmployee { get; set; }
    public decimal TotalOvertimeHours { get; set; }
    public Dictionary<string, int> ShiftsByType { get; set; } = new();
}