using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Educations;

namespace Application.Interfaces;

public interface IEducationRepository
{
    public Task<int> AddEducationAsync(CreateManyEducationDto educations);
    public Task<int> UpdateEducationAsync(UpdateEducationDto education);
    public Task<int> DeleteEducationAsync(Guid id);
    public Task<int> DeleteEducationByInfoIdAsync(Guid infoId);
    public Task<GetManyEducationDto> GetEducationsByInfoIdAsync(Guid infoId);
}
