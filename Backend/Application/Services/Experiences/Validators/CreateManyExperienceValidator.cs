using Application.DTOs.Experiences;
using FluentValidation;

namespace Application.Services.Experiences.Validators;

public class CreateManyExperienceValidator : AbstractValidator<CreateManyExperienceDto>
{
    public CreateManyExperienceValidator()
    {
        RuleFor(x => x.PersonalInfoId).NotEmpty().NotEmpty();
        RuleForEach(x => x.Experiences).SetValidator(new CreateExperienceValidator());

    }
}
public class CreateExperienceValidator : AbstractValidator<CreateExperienceDto>
{
    public CreateExperienceValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotEmpty();
        RuleFor(x => x.Company).NotEmpty().NotEmpty();
        RuleFor(x => x.Position).NotEmpty().NotEmpty();
        RuleFor(x => x.Duration).NotEmpty().NotEmpty();
        RuleFor(x => x.Description).NotEmpty().NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty().NotEmpty();
        RuleFor(x => x.EndDate)
            .NotEmpty()
            .When(x => !x.IsCurrent)
            .WithMessage("Date must not be empty when IsCurrent is false.");
    }
}
