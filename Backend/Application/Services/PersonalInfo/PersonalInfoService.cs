using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.PersonalInfos;
using Application.Interfaces;
using Application.Services.Common;
using Application.Services.PersonalInfo.Validators;

namespace Application.Services.PersonalInfo;

public class PersonalInfoService : IPersonalInfoService
{
    private readonly IPersonalInfoRepository _personalInfoRepository;

    public PersonalInfoService(IPersonalInfoRepository personalInfoRepository)
    {
        _personalInfoRepository = personalInfoRepository;
    }

    public async Task<Guid> AddPersonalInfoAsync(CreatePersonalInfoDto personalInfo)
    {
        CreatePersonalInfoValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(personalInfo));
        return await _personalInfoRepository.AddPersonalInfoAsync(personalInfo);
    }

    public async Task<int> DeletePersonalInfoAsync(Guid id)
    {
        return await _personalInfoRepository.DeletePersonalInfoAsync(id);
    }

    public async Task<PersonalInfoDto?> GetPersonalInfoByIdAsync(Guid id)
    {
        return await _personalInfoRepository.GetPersonalInfoByIdAsync(id);
    }

    public async Task<GetPersonalInfoDemoDto> GetPersonalInfoList(PersonalInfoDemoRequestDto request)
    {
        return await _personalInfoRepository.GetPersonalInfoList(request);
    }

    public async Task<int> UpdatePersonalInfoAsync(UpdatePersonalInfoDto personalInfo)
    {
        UpdatePersonalInfoValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(personalInfo));
        return await _personalInfoRepository.UpdatePersonalInfoAsync(personalInfo);
    }
}
