using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules;

public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
{
    public CreateGuestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("En az 3 karater")
            .MaximumLength(20).WithMessage("En fazla 20 karakter");

        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty")
            .MinimumLength(3).WithMessage("En az 3 karater")
            .MaximumLength(20).WithMessage("En fazla 20 karakter");

        RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be empty")
            .MinimumLength(3).WithMessage("En az 3 karater")
            .MaximumLength(20).WithMessage("En fazla 20 karakter");

    }
}
