using Application.DTOs.PersonalInfos;
using Bogus;
using Bogus.Extensions.Sweden;
using Domain.Entities;

namespace Backend.Test.Faker;

public static class PersonalInfoFaker
{
    public static CreatePersonalInfoDto GetCreateModel()
    {

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

    public static CreatePersonalInfoDto GetIncompleteCreateModel()
    {

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
    public static UpdatePersonalInfoDto GetUpdateModel()
    {
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

    public static UpdatePersonalInfoDto GetIncompleteUpdateModel()
    {
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

    public static PersonalInfoDto GetPersonalInfoModel()
    {
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
    public static PersonalInfo GetPersonalInfoEntity(CreatePersonalInfoDto request)
    {

        var faker = new Faker<PersonalInfo>()
        .RuleFor(x => x.Id, y => Guid.NewGuid())
        .RuleFor(x => x.Address, y => request.Address)
        .RuleFor(x => x.ShortText, y => request.ShortText)
        .RuleFor(x => x.Designations, y => request.Designations)
        .RuleFor(x => x.Details, y => request.Details)
        .RuleFor(x => x.Email, y => request.Email)
        .RuleFor(x => x.Firstname, y => request.Firstname)
        .RuleFor(x => x.Lastname, y => request.Lastname)
        .RuleFor(x => x.Nationality, y => request.Nationality)
        .RuleFor(x => x.PhoneNumber, y => request.PhoneNumber)
        .RuleFor(x => x.Gender, y => Domain.Enums.Gender.Female)
        .RuleFor(x => x.DateOfBirth, y => request.DateOfBirth);
        return faker.Generate();
    }
    public static List<PersonalInfo> GetPersonalInfoEntities(int number)
    {
        var response = new List<PersonalInfo>();
        for (int i=0; i<number;i++)
        {
            var faker = new Faker<PersonalInfo>()
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
            response.Add(faker.Generate());
        }
        return response;
    }
}
