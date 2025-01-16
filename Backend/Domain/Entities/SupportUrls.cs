using Domain.Enums;

namespace Domain.Entities;

public class SupportUrls : BaseEntity
{
    public Guid PersonalInfoId { get; set; }
    public required UrlTypes Type { get; set; }
    public required string Url { get; set; }
}
