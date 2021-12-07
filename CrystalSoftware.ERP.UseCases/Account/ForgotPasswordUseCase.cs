using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Shared.Resources;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class ForgotPasswordUseCase : IForgotPasswordUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private const string DefaultErrorMessage = "An error has occured when trying to do user password recovery.";

        public ForgotPasswordUseCase(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<UseCaseResponse> Execute(string email)
        {
            var useCaseResponse = new UseCaseResponse();
            try
            {
                var applicationUser = await _identityRepository.FindApplicationUserByEmail(email);
                if (applicationUser == null)
                    return useCaseResponse.SetBadRequest(Messages.UserNotFound);

                var token = await _identityRepository.GeneratePasswordResetToken(applicationUser);

                return useCaseResponse.SetSuccess();
            }
            catch (Exception e)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage, null);
            }
        }
    }
}
