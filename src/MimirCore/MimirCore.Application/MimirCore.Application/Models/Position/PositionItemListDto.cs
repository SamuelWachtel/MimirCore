namespace MimirCore.Application.Models.Position;

// Position ItemListDto - brief version for lists
public class PositionItemListDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
}