using Application.DTOs.References;
using FluentValidation;

namespace Application.Services.References.Validators;

public class UpdateReferenceValidator : AbstractValidator<UpdateReferenceDto>
{
    public UpdateReferenceValidator()
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