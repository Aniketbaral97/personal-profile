using Application.DTOs.Skills;
using FluentValidation;

namespace Application.Services.Skills.Validators;

public class UpdateSkillValidator : AbstractValidator<UpdateSkillDto>
{
    public UpdateSkillValidator()
    {
        RuleFor(x => x.Skill).NotEmpty().NotEmpty();
    }
}