using CrystalSoftware.ERP.Border.Dto.Account;
using CrystalSoftware.ERP.Border.Shared;
using System.Collections.Generic;

namespace CrystalSoftware.ERP.Border.Interfaces.UseCase
{
    public interface IGetAccountUseCase : IUseCase<GetAccountFiltersRequest, UseCaseResponse<IEnumerable<ApplicationUser>>>
    {
    }
}
