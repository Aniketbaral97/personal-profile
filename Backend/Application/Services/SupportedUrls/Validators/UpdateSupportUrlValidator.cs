using Application.DTOs.SupportUrls;
using FluentValidation;

namespace Application.Services.SupportUrls.Validators;

public class UpdateSupportUrlValidator : AbstractValidator<UpdateSupportUrlDto>
{
    public UpdateSupportUrlValidator()
    {
        RuleFor(x => x.Url).NotEmpty().NotEmpty();
    }
}