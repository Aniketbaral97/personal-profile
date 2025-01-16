using Application.DTOs.Experiences;
using FluentValidation;

namespace Application.Services.Experiences.Validators;

public class UpdateExperienceValidator : AbstractValidator<UpdateExperienceDto>
{
    public UpdateExperienceValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotEmpty();
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