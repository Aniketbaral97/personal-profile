using Application.DTOs.SupportUrls;
using FluentValidation;

namespace Application.Services.Experiences.Validators;

public class CreateManySupportValidator : AbstractValidator<CreateManySupportUrlDto>
{
    public CreateManySupportValidator()
    {
        RuleFor(x => x.PersonalInfoId).NotEmpty().NotEmpty();
        RuleForEach(x => x.SupportUrls).SetValidator(new CreateSupportUrlValidator());

    }
}
public class CreateSupportUrlValidator : AbstractValidator<CreateSupportUrlDto>
{
    public CreateSupportUrlValidator()
    {
        RuleFor(x => x.Url).NotEmpty().NotEmpty();
    }
}
