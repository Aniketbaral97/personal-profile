using Application.DTOs.Educations;
using FluentValidation;

namespace Application.Services.Educations.Validators;

public class CreateManyEducationValidator : AbstractValidator<CreateManyEducationDto>
{
    public CreateManyEducationValidator()
    {
        RuleFor(x => x.PersonalInfoId).NotEmpty().NotEmpty();
        RuleForEach(x => x.Educations).SetValidator(new CreateEducationValidator());

    }
}
public class CreateEducationValidator : AbstractValidator<CreateEducationDto>
{
    public CreateEducationValidator()
    {
        RuleFor(x => x.Institution).NotEmpty().NotEmpty();
        RuleFor(x => x.Degree).NotEmpty().NotEmpty();
        RuleFor(x => x.Duration).NotEmpty().NotEmpty();
        RuleFor(x => x.Description).NotEmpty().NotEmpty();
        RuleFor(x => x.GradingType).NotEmpty().NotEmpty();
        RuleFor(x => x.Grading).NotEmpty().NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty().NotEmpty();
        
        RuleFor(x => x.EndDate)
            .NotEmpty()
            .When(x => !x.IsCurrent)
            .WithMessage("Date must not be empty when IsCurrent is false.");
    }
}
