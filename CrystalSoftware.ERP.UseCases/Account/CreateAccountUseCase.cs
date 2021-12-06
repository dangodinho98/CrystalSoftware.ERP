using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Extensions;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using CrystalSoftware.ERP.Repositories.Services;
using CrystalSoftware.ERP.Shared.Extensions;
using FluentValidation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly CreateAccountValidator _validator;
        private const string DefaultErrorMessage = "An error has occured when trying to create user account.";
        private readonly MailService _mailService;

        public CreateAccountUseCase(IIdentityRepository _identityRepository, 
            IAccountRepository accountRepository,
            CreateAccountValidator validator,
            MailService mailService)
        {
            this._identityRepository = _identityRepository;
            _accountRepository = accountRepository;
            _validator = validator;
            _mailService = mailService;
        }

        public async Task<UseCaseResponse<ApplicationUser>> Execute(CreateAccountRequest request)
        {
            var useCaseResponse = new UseCaseResponse<ApplicationUser>();
            try
            {
                _validator.ValidateAndThrow(request);

                var applicationUser = await _identityRepository.FindApplicationUserByEmail(request.Email);
                if (applicationUser != null)
                    return useCaseResponse.SetCreated(applicationUser);

                applicationUser = request.ToApplicationUser();
                var result = await _identityRepository.AddApplicationUser(applicationUser, request.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(x => new ErrorMessage
                    {
                        Code = x.Code,
                        Message = x.Description
                    }).ToArray();
                    return useCaseResponse.SetBadRequest("An error occurred.", errors);
                }

                //var token = await _identityRepository.GenerateEmailConfirmationToken(applicationUser);

                //token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                //var callbackUrl = Url.Page(
                //    "/Account/ConfirmEmail",
                //    pageHandler: null,
                //    values: new { area = "Identity", userId = applicationUser.Id, code = code },
                //    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //{
                //    return RedirectToPage("RegisterConfirmation",
                //                          new { email = Input.Email });
                //}
                //else
                //{
                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    return LocalRedirect(returnUrl);
                //}

                return useCaseResponse.SetCreated(applicationUser);
            }
            catch (ValidationException e)
            {
                return useCaseResponse.SetBadRequest(DefaultErrorMessage, e.Errors.ToErrorMessages().ToArray());
            }
            catch (Exception e)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage);
            }
        }
    }
}
