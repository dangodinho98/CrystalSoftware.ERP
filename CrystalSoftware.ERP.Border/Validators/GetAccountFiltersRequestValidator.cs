using CrystalSoftware.ERP.Border.Dto.Account;
using FluentValidation;

namespace CrystalSoftware.ERP.Border.Validators
{
    public class GetAccountFiltersRequestValidator : AbstractValidator<GetAccountFiltersRequest>
    {
        public GetAccountFiltersRequestValidator()
        {
            RuleFor(r => r.CreationDateEnd)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(r => r.CreationDateStart.Value).WithMessage("End date must after Start date")
                .When(m => m.CreationDateStart.HasValue && m.CreationDateEnd.HasValue);
        }
    }
}
