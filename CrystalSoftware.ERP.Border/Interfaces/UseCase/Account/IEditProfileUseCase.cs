using CrystalSoftware.ERP.Border.Dto.Account;
using CrystalSoftware.ERP.Border.Shared;

namespace CrystalSoftware.ERP.Border.Interfaces.UseCase
{
    public interface IEditProfileUseCase : IUseCase<EditProfileRequest, UseCaseResponse<ApplicationUser>>
    {
    }
}
