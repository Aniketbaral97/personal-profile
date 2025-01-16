using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Skills;

namespace Application.Interfaces;

public interface ISkillService
{
    public Task<int> AddSkillAsync(CreateManySkillDto skills);
    public Task<int> UpdateSkillAsync(UpdateSkillDto skill);
    public Task<int> DeleteSkillAsync(Guid id);
    public Task<int> DeleteSkillByInfoIdAsync(Guid infoId);
    public Task<GetManySkillDto> GetSkillsByInfoIdAsync(Guid infoId);
}
