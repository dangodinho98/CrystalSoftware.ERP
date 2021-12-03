using FluentValidation;
using System;

namespace CrystalSoftware.ERP.Border.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x).GuidNotEmpty();
        }
    }
}
