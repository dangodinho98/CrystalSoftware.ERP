using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Shared;

namespace CrystalSoftware.ERP.Border.Interfaces.UseCase
{
    public interface ICreateAccountUseCase : IUseCase<CreateAccountRequest, UseCaseResponse<ApplicationUser>>
    {
    }
}
