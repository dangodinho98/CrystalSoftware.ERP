using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class SignOutUseCase : ISignOutUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private const string DefaultErrorMessage = "An error has occured when trying to do user logout.";

        public SignOutUseCase(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<UseCaseResponse> Execute(object request)
        {
            var useCaseResponse = new UseCaseResponse();
            try
            {
                await _identityRepository.SignOut();
                return useCaseResponse.SetSuccess();
            }
            catch (Exception)
            {
                return useCaseResponse.SetInternalServerError(DefaultErrorMessage, null);
            }
        }
    }
}
