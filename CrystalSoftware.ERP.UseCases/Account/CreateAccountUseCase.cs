using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Extensions;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly CreateAccountValidator _validator;

        public CreateAccountUseCase(IAccountRepository accountRepository, CreateAccountValidator validator)
        {
            _accountRepository = accountRepository;
            _validator = validator;
        }

        public async Task<UseCaseResponse<CreateAccountResponse>> Execute(CreateAccountRequest request)
        {
            try
            {
                _validator.ValidateAndThrow(request);

                var applicationUser = request.ToApplicationUser();
                await _accountRepository.AddApplicationUser(applicationUser, request.Password);

                return new UseCaseResponse<CreateAccountResponse>().SetSuccess();
            }
            catch (ValidationException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
