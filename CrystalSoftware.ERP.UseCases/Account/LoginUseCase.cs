using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using CrystalSoftware.ERP.Shared.Extensions;
using FluentValidation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly CreateAccountValidator _validator;
        private const string DefaultErrorMessage = "An error has occured when trying to do user login.";
        private const string InvalidUserOrPassword = "Usuário ou senha inválidos.";

        public LoginUseCase(IIdentityRepository _identityRepository, CreateAccountValidator validator)
        {
            this._identityRepository = _identityRepository;
            _validator = validator;
        }

        public async Task<UseCaseResponse> Execute(LoginRequest request)
        {
            var useCaseResponse = new UseCaseResponse();
            try
            {
                //_validator.ValidateAndThrow(request);

                var applicationUser = await _identityRepository.FindApplicationUserByEmail(request.Email);
                if (applicationUser == null)
                    return useCaseResponse.SetNotFound(InvalidUserOrPassword);

                var signInResult = await _identityRepository.PasswordSignIn(applicationUser, request);
                if (!signInResult.Succeeded)
                    return useCaseResponse.SetNotFound(InvalidUserOrPassword);

                return useCaseResponse.SetSuccess();
            }
            catch (ValidationException e)
            {
                return useCaseResponse.SetBadRequest(DefaultErrorMessage, e.Errors.ToErrorMessages().ToArray());
            }
            catch (Exception e)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage, null);
            }
        }
    }
}
