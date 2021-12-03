using FluentValidation;

namespace CrystalSoftware.ERP.Border.Validators
{
    public class StringValidator : AbstractValidator<string>
    {
        public StringValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
