using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Shared.Resources;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class ProfileUseCase : IProfileUseCase
    {
        private readonly IIdentityRepository _identityRepository;

        public ProfileUseCase(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<UseCaseResponse<ApplicationUser>> Execute(string name)
        {
            var useCaseResponse = new UseCaseResponse<ApplicationUser>();
            try
            {
                var applicationUser = await _identityRepository.FindApplicationUserByName(name);
                if (applicationUser == null)
                    return useCaseResponse.SetBadRequest(Messages.UserNotFound);

                return useCaseResponse.SetSuccess(applicationUser);
            }
            catch (Exception)
            {
                return useCaseResponse.SetInternalServerError(Messages.UserNotFound);
            }
        }
    }
}
