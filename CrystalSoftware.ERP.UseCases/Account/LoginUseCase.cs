using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using CrystalSoftware.ERP.Shared.Extensions;
using CrystalSoftware.ERP.Shared.Resources;
using FluentValidation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly LoginRequestValidator _validator;
        private const string DefaultErrorMessage = "An error has occured when trying to do user login.";
        private const string UnconfirmedMail = "Email não confirmado.";

        public LoginUseCase(IIdentityRepository identityRepository, LoginRequestValidator validator)
        {
            _identityRepository = identityRepository;
            _validator = validator;
        }

        public async Task<UseCaseResponse> Execute(LoginRequest request)
        {
            var useCaseResponse = new UseCaseResponse();
            try
            {
                _validator.ValidateAndThrow(request);

                var applicationUser = await _identityRepository.FindApplicationUserByEmail(request.Email);
                if (applicationUser == null)
                    return useCaseResponse.SetBadRequest(Messages.InvalidUserOrPassword);

                var signInResult = await _identityRepository.PasswordSignIn(applicationUser, request);
                if (!signInResult.Succeeded)
                    return useCaseResponse.SetBadRequest(Messages.InvalidUserOrPassword);

                //TODO: Aguardando funcionalidade de envio de e-mail
                //if (!applicationUser.EmailConfirmed)
                //{
                //    await _identityRepository.SignOut();
                //    return useCaseResponse.SetBadRequest(UnconfirmedMail);
                //}

                return useCaseResponse.SetSuccess();
            }
            catch (ValidationException e)
            {
                return useCaseResponse.SetBadRequest(DefaultErrorMessage, e.Errors.ToErrorMessages().ToArray());
            }
            catch (Exception)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage, null);
            }
        }
    }
}
