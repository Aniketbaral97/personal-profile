using Domain.Enums;

namespace Application.DTOs.Identity;

public sealed class UserListQueryResponse
{
    public int TotalPages { get; set; }
    public List<UserListDto> Users { get; set; } = [];


    public sealed class UserListDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string[] Projects { get; set; } = [];
        public ActiveStatus ActiveStatus { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
