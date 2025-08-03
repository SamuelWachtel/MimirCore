namespace MimirCore.Application.Models.Position;

public class PositionItemListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
}