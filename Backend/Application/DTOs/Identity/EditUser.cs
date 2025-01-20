using Domain.Enums;

namespace Application.DTOs.Identity;

public class EditUser
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public ActiveStatus ActiveStatus { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? SecurityStamp { get; set; }
    public UserGroup UserGroup { get; set; }
}
