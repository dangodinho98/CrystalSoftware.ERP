using CrystalSoftware.ERP.Border.Shared;

namespace CrystalSoftware.ERP.Border.Interfaces.UseCase
{
    public interface IGetAccountByNameUseCase : IUseCase<string, UseCaseResponse<ApplicationUser>>
    {
    }
}
