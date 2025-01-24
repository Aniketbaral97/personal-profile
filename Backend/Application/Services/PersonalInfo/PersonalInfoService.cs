using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.PersonalInfos;
using Application.Exceptions;
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

    public bool CheckIsMain(Guid id)
    {
        return _personalInfoRepository.CheckIsMain(id);
    }

    public async Task<int> DeletePersonalInfoAsync(Guid id)
    {
        return await _personalInfoRepository.DeletePersonalInfoAsync(id);
    }

    public async Task<Guid> GetMainProfile()
    {
        return await _personalInfoRepository.GetMainProfile();
    }

    public async Task<PersonalInfoDto?> GetPersonalInfoByIdAsync(Guid id)
    {
        return await _personalInfoRepository.GetPersonalInfoByIdAsync(id);
    }

    public async Task<GetPersonalInfoDemoDto> GetPersonalInfoList(PersonalInfoDemoRequestDto request)
    {
        return await _personalInfoRepository.GetPersonalInfoList(request);
    }

    public async Task<int> UpdateIsMain(UpdateMainProfile request)
    {
        return await _personalInfoRepository.UpdateIsMain(request);
    }

    public async Task<int> UpdatePersonalInfoAsync(UpdatePersonalInfoDto personalInfo)
    {
        UpdatePersonalInfoValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(personalInfo));
        if (personalInfo.IsMain)
        {
            bool isMainRes = _personalInfoRepository.CheckIsMain(personalInfo.Id);
            if (isMainRes)
            {
                throw new CommandExecutionException("Cannot have multiple main profiles");
            }
        }
        return await _personalInfoRepository.UpdatePersonalInfoAsync(personalInfo);
    }
}
