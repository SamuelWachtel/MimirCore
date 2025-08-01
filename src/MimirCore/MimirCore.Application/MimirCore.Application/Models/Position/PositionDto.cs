namespace MimirCore.Application.Models.Position;

public class PositionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreatePositionDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
}

public class UpdatePositionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
}