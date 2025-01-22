using Application.DTOs.PersonalInfos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class PersonalInfoRepository : IPersonalInfoRepository
{
    private readonly AppDbContext _context;

    public PersonalInfoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddPersonalInfoAsync(CreatePersonalInfoDto personalInfo)
    {
        var entity  = new PersonalInfo(){
            Firstname = personalInfo.Firstname,
            Lastname = personalInfo.Lastname,
            Middlename = personalInfo.Middlename,
            Designations = personalInfo.Designations,
            Address = personalInfo.Address,
            PhoneNumber = personalInfo.PhoneNumber,
            Details = personalInfo.Details,
            DateOfBirth = personalInfo.DateOfBirth,
            Gender = personalInfo.Gender,
            ShortText = personalInfo.ShortText,
            Email=personalInfo.Email,
            Hobbies=personalInfo.Hobbies,
            Languages=personalInfo.Languages,
            Nationality=personalInfo.Nationality,
            WorkAvailabilityStatus=personalInfo.WorkAvailabilityStatus
        };
        _context.PersonalInfos.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> DeletePersonalInfoAsync(Guid id)
    {
        return await _context.PersonalInfos
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<PersonalInfoDto?> GetPersonalInfoByIdAsync(Guid id)
    {
        return await _context.PersonalInfos.Where(x=>x.Id==id).Select(x=>new PersonalInfoDto(){
            Firstname = x.Firstname,
            Lastname = x.Lastname,
            Middlename = x.Middlename,
            Designations = x.Designations,
            Address = x.Address,
            PhoneNumber = x.PhoneNumber,
            Details = x.Details,
            DateOfBirth = x.DateOfBirth,
            Gender = x.Gender,
            ShortText = x.ShortText,
            Id = x.Id,
            Email=x.Email,
            Hobbies=x.Hobbies,
            Languages=x.Languages,
            Nationality=x.Nationality,
            WorkAvailabilityStatus=x.WorkAvailabilityStatus
        }).FirstOrDefaultAsync() ?? null;
    }

    public async Task<int> UpdatePersonalInfoAsync(UpdatePersonalInfoDto personalInfo)
    {
        return await _context.PersonalInfos.Where(x=>x.Id==personalInfo.Id)
        .ExecuteUpdateAsync(x=>x.SetProperty(x=>x.Firstname,personalInfo.Firstname)
        .SetProperty(x=>x.Lastname,personalInfo.Lastname)
        .SetProperty(x=>x.Middlename,personalInfo.Middlename)
        .SetProperty(x=>x.Designations,personalInfo.Designations)
        .SetProperty(x=>x.Address,personalInfo.Address)
        .SetProperty(x=>x.PhoneNumber,personalInfo.PhoneNumber)
        .SetProperty(x=>x.Details,personalInfo.Details)
        .SetProperty(x=>x.DateOfBirth,personalInfo.DateOfBirth)
        .SetProperty(x=>x.Gender,personalInfo.Gender)
        .SetProperty(x=>x.ShortText,personalInfo.ShortText)
        .SetProperty(x=>x.Email,personalInfo.Email)
        .SetProperty(x=>x.Nationality,personalInfo.Nationality)
        .SetProperty(x=>x.Hobbies,personalInfo.Hobbies)
        .SetProperty(x=>x.Languages,personalInfo.Languages)
        .SetProperty(x=>x.WorkAvailabilityStatus,personalInfo.WorkAvailabilityStatus)
        
        );
    }
}
