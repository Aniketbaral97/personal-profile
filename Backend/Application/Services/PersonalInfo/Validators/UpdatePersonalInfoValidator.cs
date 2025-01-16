using Application.DTOs.PersonalInfos;
using FluentValidation;

namespace Application.Services.PersonalInfo.Validators;

public class UpdatePersonalInfoValidator : AbstractValidator<UpdatePersonalInfoDto>
{
    public UpdatePersonalInfoValidator()
    {
        RuleFor(x => x.Firstname).NotEmpty().NotEmpty();
        RuleFor(x => x.Lastname).NotEmpty().NotEmpty();
        RuleFor(x => x.Designations).NotEmpty().NotEmpty();
        RuleFor(x => x.Address).NotEmpty().NotEmpty();
        RuleFor(x => x.Gender).NotEmpty().NotEmpty();
    }
}