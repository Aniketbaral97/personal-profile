using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs.Skills;

public class CreateSkillDto
{
    public required SkillTypes Type { get; set; }
    public required string Skill { get; set; }
    public required SkillLevels Level { get; set; }
}
