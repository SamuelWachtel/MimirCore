namespace MimirCore.Application.Models.User;

// User ItemListDto - brief version for lists
public class UserItemListDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLoginAt { get; set; }
}