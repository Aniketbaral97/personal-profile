namespace Domain.Entities;

public class Experience : BaseEntity
{
    public Guid PersonalInfoId { get; set; }
    public required string Company { get; set; }
    public required string Position { get; set; }
    public required string Duration { get; set; }
    public required string Description { get; set; }
    public bool IsCurrent { get; set; }
    public required DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
