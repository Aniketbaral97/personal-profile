using Domain.Enums;

namespace Application.DTOs.Identity;
public class UsersList
{
    public int TotalPages { get; set; }
    public List<UserListDto> Users { get; set; } = new();
}

public class UserListDto
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public string[] Projects { get; set; } = [];
    public ActiveStatus ActiveStatus { get; set; }
    public UserGroup UserGroup { get; set; }
}