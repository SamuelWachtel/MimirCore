namespace MimirCore.Api.Models.Employee;

public class TerminateEmployeeRequest
{
    public DateTime TerminationDate { get; set; }
    public string Reason { get; set; } = string.Empty;
}