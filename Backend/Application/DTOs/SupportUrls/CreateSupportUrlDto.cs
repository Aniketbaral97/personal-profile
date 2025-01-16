using Domain.Enums;

namespace Application.DTOs.SupportUrls;

public class CreateSupportUrlDto
{
    public required UrlTypes Type { get; set; } =UrlTypes.Other;
    public required string Url { get; set; }
}
