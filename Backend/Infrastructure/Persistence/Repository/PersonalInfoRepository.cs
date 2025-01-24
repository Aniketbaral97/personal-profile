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
            WorkAvailabilityStatus=personalInfo.WorkAvailabilityStatus,
            IsMain=personalInfo.IsMain
            
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
            WorkAvailabilityStatus=x.WorkAvailabilityStatus,
            IsMain=x.IsMain
        }).FirstOrDefaultAsync() ?? null;
    }

    public async Task<GetPersonalInfoDemoDto> GetPersonalInfoList(PersonalInfoDemoRequestDto request)
    {
        var res = new GetPersonalInfoDemoDto(){};
        request.Offset *=request.Limit;
        var personalInfos = await _context.PersonalInfos.ToListAsync();
        if(request.Name != null)
        {
            personalInfos=personalInfos.Where(x=>x.Firstname.Contains(request.Name, StringComparison.CurrentCultureIgnoreCase) ||
            (x.Middlename != null && x.Middlename.Contains(request.Name, StringComparison.CurrentCultureIgnoreCase)) ||
            x.Lastname.Contains(request.Name, StringComparison.CurrentCultureIgnoreCase)).ToList();   
        }
        if(request.WorkAvailabilityStatus>0)
        {
            personalInfos = personalInfos.Where(x=>x.WorkAvailabilityStatus==request.WorkAvailabilityStatus).ToList();
        }
        res.TotalPages= (int)Math.Ceiling((double)personalInfos.Count / request.Limit);
        res.PersonalInfos = personalInfos.Select(x=> new PersonalInfoDemo(){
            Firstname =x.Firstname,
            Lastname=x.Lastname,
            Middlename=x.Middlename,
            WorkAvailabilityStatus=x.WorkAvailabilityStatus,
            Designations=x.Designations,
            Address=x.Address,
            IsMain=x.IsMain
        }).Skip(request.Offset).Take(request.Limit).ToList();
        return res;

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
        .SetProperty(x=>x.IsMain,personalInfo.IsMain)
        .SetProperty(x=>x.WorkAvailabilityStatus,personalInfo.WorkAvailabilityStatus)
        
        );
    }
    public async Task<int> UpdateIsMain(UpdateMainProfile request)
    {
        var res = await _context.PersonalInfos.Where(x=>x.Id==request.Id)
        .ExecuteUpdateAsync(x=>x.SetProperty(x=>x.IsMain,request.IsMain));
        if(res > 0 && request.IsMain)
        {
            await _context.PersonalInfos.Where(x=>x.Id!=request.Id && x.IsMain)
            .ExecuteUpdateAsync(x=>x.SetProperty(x=>x.IsMain,false));
        }
        return res;
    }
    public bool CheckIsMain(Guid id){
        return _context.PersonalInfos.Any(x=>x.Id!=id && x.IsMain==true);
    }

    public async Task<Guid> GetMainProfile()
    {
        var res = await _context.PersonalInfos.Where(x=>x.IsMain==true).Select(x=>x.Id).FirstOrDefaultAsync();
        if(res==Guid.Empty)
        {
           res= await _context.PersonalInfos.Select(x=>x.Id).FirstOrDefaultAsync();
        }
        return res;
    }
}
