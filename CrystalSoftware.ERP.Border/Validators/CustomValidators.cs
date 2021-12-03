using FluentValidation;
using System;

namespace CrystalSoftware.ERP.Border.Validators
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, Guid> GuidNotEmpty<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithErrorCode("00")
                .WithMessage("{PropertyName} should not be an empty guid");
        }
    }
}
