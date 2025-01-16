using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs.Skills;

public class CreateSkillDto
{
    public SkillTypes Type { get; set; } =SkillTypes.Other;
    public required string Skill { get; set; }
    public SkillLevels Level { get; set; } = SkillLevels.Beginner;
}
