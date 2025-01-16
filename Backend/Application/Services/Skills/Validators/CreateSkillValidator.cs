using Application.DTOs.PersonalInfos;
using Application.DTOs.Skills;
using FluentValidation;

namespace Application.Services.Skills.Validators;

public class CreateManySkillValidator : AbstractValidator<CreateManySkillDto>
{
    public CreateManySkillValidator()
    {
        RuleFor(x => x.PersonalInfoId).NotEmpty().NotEmpty();
        RuleForEach(x => x.Skills).SetValidator(new CreateSkillValidator());

    }
}
public class CreateSkillValidator : AbstractValidator<CreateSkillDto>
{
    public CreateSkillValidator()
    {
        RuleFor(x => x.Skill).NotEmpty().NotEmpty();
    }
}
