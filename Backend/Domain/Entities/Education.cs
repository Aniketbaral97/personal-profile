using Domain.Enums;

namespace Domain.Entities;

public class Education : BaseEntity
{
    public Guid PersonalInfoId { get; set; }
    public required string Institution { get; set; }
    public required string Degree { get; set; }
    public required string Duration { get; set; }
    public required string Description { get; set; }
    public required GradingTypes GradingType { get; set; }
    public required double Grading { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
