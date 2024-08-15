using FluentValidation;
using HotelProject.DtoLayer.Dtos.GuestDtos;

namespace HotelProject.WebApi.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidate : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidate()
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
}
