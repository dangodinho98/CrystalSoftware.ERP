using CrystalSoftware.ERP.Border.Dto;
using FluentValidation;

namespace CrystalSoftware.ERP.Border.Validators
{
	public class LoginRequestValidator : AbstractValidator<LoginRequest>
	{
		public LoginRequestValidator()
		{
			RuleFor(x => x.Email).EmailAddress().NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
