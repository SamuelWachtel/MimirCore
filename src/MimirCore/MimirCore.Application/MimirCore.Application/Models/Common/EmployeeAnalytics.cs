namespace MimirCore.Application.Models.Common;

public class EmployeeAnalytics
{
    public int TotalEmployees { get; set; }
    public int NewHires { get; set; }
    public int Terminations { get; set; }
    public decimal AverageSalary { get; set; }
    public Dictionary<string, int> EmployeesByDepartment { get; set; } = new();
    public Dictionary<string, int> EmployeesByTeam { get; set; } = new();
}