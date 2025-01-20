using Domain.Enums;

namespace Application.DTOs.Identity;

public sealed class UserListQueryRequest
{
    public int Limit { get; set; } = 50;
    public int Offset { get; set; } = 0;
    public UserListQueryRequestFilter Filter { get; set; } = new();
    public sealed class UserListQueryRequestFilter
    {
        public Guid ProjectId { get; set; }
        public List<Guid> UserIds { get; set; } = new();
        public string? Username { get; set; } = null;
        public UserGroup? UserGroup { get; set; }
        public ActiveStatus? ActiveStatus { get; set; }
        public bool UserClaimIsAdmin { get; set; }

    }
}
