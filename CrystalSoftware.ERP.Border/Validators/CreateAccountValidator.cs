using CrystalSoftware.ERP.Border.Dto;
using FluentValidation;

namespace CrystalSoftware.ERP.Border.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
