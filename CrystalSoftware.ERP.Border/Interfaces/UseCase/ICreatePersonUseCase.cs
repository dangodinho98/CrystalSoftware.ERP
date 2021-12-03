using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Shared;

namespace CrystalSoftware.ERP.Border.Interfaces.UseCase
{
    public interface ICreatePersonUseCase : IUseCase<CreatePersonRequest, UseCaseResponse<CreatePersonResponse>>
    {
    }
}
