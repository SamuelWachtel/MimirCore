using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class SystemSetting : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Key { get; set; }
        
    [Required]
    public string Value { get; set; }
        
    [StringLength(200)]
    public string Description { get; set; }
        
    [StringLength(50)]
    public string Category { get; set; }

    [StringLength(50)]
    public string DataType { get; set; } = "String";
}