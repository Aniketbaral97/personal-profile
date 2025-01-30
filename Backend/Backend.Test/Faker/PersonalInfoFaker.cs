using Application.DTOs.PersonalInfos;
using Bogus;
using Bogus.Extensions.Sweden;

namespace Backend.Test.Faker;

public static class PersonalInfoFaker
{
    public static CreatePersonalInfoDto GetCreateModel(){
        
    var faker = new Faker<CreatePersonalInfoDto>()
    .RuleFor(x => x.Address, y => y.Address.FullAddress())
    .RuleFor(x => x.ShortText, y => y.Lorem.Sentence())
    .RuleFor(x => x.Designations, y => y.Lorem.Word())
    .RuleFor(x => x.Details, y => y.Lorem.Sentences())
    .RuleFor(x => x.Email, y => y.Internet.Email())
    .RuleFor(x => x.Firstname, y => y.Name.FirstName())
    .RuleFor(x => x.Lastname, y => y.Name.LastName())
    .RuleFor(x => x.Nationality, y => y.Lorem.Word())
    .RuleFor(x => x.PhoneNumber, y => y.Person.Personnummer())
    .RuleFor(x => x.Gender, y => Domain.Enums.Gender.Female)
    .RuleFor(x => x.DateOfBirth, y => DateOnly.FromDateTime(y.Person.DateOfBirth));
    return faker.Generate();
    }    
 
    public static CreatePersonalInfoDto GetIncompleteCreateModel(){
        
    var faker = new Faker<CreatePersonalInfoDto>()
    .RuleFor(x => x.Address, y => String.Empty)
    .RuleFor(x => x.ShortText, y => y.Lorem.Sentence())
    .RuleFor(x => x.Designations, y => y.Lorem.Word())
    .RuleFor(x => x.Details, y => y.Lorem.Sentences())
    .RuleFor(x => x.Email, y => y.Internet.Email())
    .RuleFor(x => x.Firstname, y => y.Name.FirstName())
    .RuleFor(x => x.Lastname, y => y.Name.LastName())
    .RuleFor(x => x.Nationality, y => y.Lorem.Word())
    .RuleFor(x => x.PhoneNumber, y => y.Person.Personnummer())
    .RuleFor(x => x.Gender, y => Domain.Enums.Gender.Female)
    .RuleFor(x => x.DateOfBirth, y => DateOnly.FromDateTime(y.Person.DateOfBirth));
    return faker.Generate();
    } 
    public static UpdatePersonalInfoDto GetUpdateModel(){    
    var faker = new Faker<UpdatePersonalInfoDto>()
    .RuleFor(x => x.Id, y => Guid.NewGuid())
    .RuleFor(x => x.Address, y => y.Address.FullAddress())
    .RuleFor(x => x.ShortText, y => y.Lorem.Sentence())
    .RuleFor(x => x.Designations, y => y.Lorem.Word())
    .RuleFor(x => x.Details, y => y.Lorem.Sentences())
    .RuleFor(x => x.Email, y => y.Internet.Email())
    .RuleFor(x => x.Firstname, y => y.Name.FirstName())
    .RuleFor(x => x.Lastname, y => y.Name.LastName())
    .RuleFor(x => x.Nationality, y => y.Lorem.Word())
    .RuleFor(x => x.PhoneNumber, y => y.Person.Personnummer())
    .RuleFor(x => x.Gender, y => Domain.Enums.Gender.Female)
    .RuleFor(x => x.DateOfBirth, y => DateOnly.FromDateTime(y.Person.DateOfBirth));
    return faker.Generate();
    }      
      
    public static UpdatePersonalInfoDto GetIncompleteUpdateModel(){    
    var faker = new Faker<UpdatePersonalInfoDto>()
    .RuleFor(x => x.Id, y => Guid.NewGuid())
    .RuleFor(x => x.Address, y => y.Address.FullAddress())
    .RuleFor(x => x.ShortText, y => y.Lorem.Sentence())
    .RuleFor(x => x.Designations, y => y.Lorem.Word())
    .RuleFor(x => x.Details, y => y.Lorem.Sentences())
    .RuleFor(x => x.Email, y => y.Internet.Email())
    .RuleFor(x => x.Firstname, y => String.Empty)
    .RuleFor(x => x.Lastname, y => y.Name.LastName())
    .RuleFor(x => x.Nationality, y => y.Lorem.Word())
    .RuleFor(x => x.PhoneNumber, y => y.Person.Personnummer())
    .RuleFor(x => x.Gender, y => Domain.Enums.Gender.Female)
    .RuleFor(x => x.DateOfBirth, y => DateOnly.FromDateTime(y.Person.DateOfBirth));
    return faker.Generate();
    }   

    public static PersonalInfoDto GetPersonalInfoModel(){    
    var faker = new Faker<PersonalInfoDto>()
    .RuleFor(x => x.Id, y => Guid.NewGuid())
    .RuleFor(x => x.Address, y => y.Address.FullAddress())
    .RuleFor(x => x.ShortText, y => y.Lorem.Sentence())
    .RuleFor(x => x.Designations, y => y.Lorem.Word())
    .RuleFor(x => x.Details, y => y.Lorem.Sentences())
    .RuleFor(x => x.Email, y => y.Internet.Email())
    .RuleFor(x => x.Firstname, y => y.Name.FirstName())
    .RuleFor(x => x.Lastname, y => y.Name.LastName())
    .RuleFor(x => x.Nationality, y => y.Lorem.Word())
    .RuleFor(x => x.PhoneNumber, y => y.Person.Personnummer())
    .RuleFor(x => x.Gender, y => Domain.Enums.Gender.Female)
    .RuleFor(x => x.WorkAvailabilityStatus, y => Domain.Enums.WorkAvailabilityStatus.Available)
    .RuleFor(x => x.DateOfBirth, y => DateOnly.FromDateTime(y.Person.DateOfBirth));
    return faker.Generate();
    }    
}
