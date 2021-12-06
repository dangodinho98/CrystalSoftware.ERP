using CrystalSoftware.ERP.Border.Shared;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CrystalSoftware.ERP.Shared.Extensions
{
    public static class ValidationResultExtension
    {
        public static IEnumerable<ErrorMessage> ToErrorMessages(this ValidationResult validationResult) =>
            validationResult.Errors.ToErrorMessages();

        public static IEnumerable<ErrorMessage> ToErrorMessages(this IEnumerable<ValidationFailure> validationFailures) =>
            validationFailures.Select(validationFailure => validationFailure.ToErrorMessage());

        private static ErrorMessage ToErrorMessage(this ValidationFailure validationFailure) =>
            BuilderErrorMessage.Build(validationFailure.ErrorMessage);
    }
}
