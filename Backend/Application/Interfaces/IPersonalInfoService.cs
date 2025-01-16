using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.PersonalInfos;

namespace Application.Interfaces;

public interface IPersonalInfoService
{
    public Task<Guid> AddPersonalInfoAsync(CreatePersonalInfoDto personalInfo);
    public Task<int> UpdatePersonalInfoAsync(UpdatePersonalInfoDto personalInfo);
    public Task<int> DeletePersonalInfoAsync(Guid id);
    public Task<PersonalInfoDto?> GetPersonalInfoByIdAsync(Guid id);
}
