using Domain.Enums;

namespace Application.DTOs.Identity;
public class AddUser
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public ActiveStatus ActiveStatus { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public UserGroup UserGroup { get; set; }
}
