using Domain.Enums;

namespace Domain.Entities;

public class Skills : BaseEntity
{
    public Guid PersonalInfoId { get; set; }
    public required SkillTypes Type { get; set; }
    public required string Skill { get; set; }
    public required SkillLevels Level { get; set; }
}