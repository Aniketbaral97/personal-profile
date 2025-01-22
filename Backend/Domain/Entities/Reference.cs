namespace Domain.Entities;

public class Reference : BaseEntity
{
    public Guid PersonalInfoId { get; set; }
    public required string Name { get; set; }
    public required string Position { get; set; }
    public required string WorkPlace { get; set; }
    public string? ContactInfo { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
}