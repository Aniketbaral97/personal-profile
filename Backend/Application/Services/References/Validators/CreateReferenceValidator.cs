using Application.DTOs.References;
using FluentValidation;

namespace Application.Services.References.Validators;

public class CreateManyReferenceValidator : AbstractValidator<CreateManyReferenceDto>
{
    public CreateManyReferenceValidator()
    {
        RuleFor(x => x.PersonalInfoId).NotEmpty().NotEmpty();
        RuleForEach(x => x.References).SetValidator(new CreateReferenceValidator());

    }
}
public class CreateReferenceValidator : AbstractValidator<CreateReferenceDto>
{
    public CreateReferenceValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotEmpty();
        RuleFor(x => x.Position).NotEmpty().NotEmpty();
        RuleFor(x => x.WorkPlace).NotEmpty().NotEmpty();
        RuleFor(x => x.ContactInfo)
            .NotEmpty().NotNull()
            .When(x => x.Email == null || x.Email=="")
            .WithMessage("You must provide at leaste contact info or email");
        RuleFor(x => x.Email)
            .NotEmpty().NotNull()
            .When(x => x.ContactInfo == null || x.ContactInfo=="")
            .WithMessage("You must provide at leaste contact info or email");
    }
}
