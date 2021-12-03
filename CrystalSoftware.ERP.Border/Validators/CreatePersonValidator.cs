using CrystalSoftware.ERP.Border.Dto;
using FluentValidation;

namespace CrystalSoftware.ERP.Border.Validators
{

    public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
	{
		public CreatePersonValidator()
		{
			RuleFor(x => x.Id).GuidNotEmpty();
		}
	}
}
