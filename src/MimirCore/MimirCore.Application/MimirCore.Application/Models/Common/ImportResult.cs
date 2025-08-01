namespace MimirCore.Application.Models.Common;

public class ImportResult
{
    public bool Success { get; set; }
    public int TotalRecords { get; set; }
    public int SuccessfulRecords { get; set; }
    public int FailedRecords { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}