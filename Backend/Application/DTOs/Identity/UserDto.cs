using Domain.Enums;

namespace Application.DTOs.Identity;

public class UserDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public UserGroup UserGroup { get; set; }
    public string? FirstName { get; set; }
    public string? PasswordHash { get; set; }
    public string? MiddleName { get; set; } = null;
    public string? LastName { get; set; }
    public ActiveStatus IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid LoginIdentifier { get; set; }
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }

}
