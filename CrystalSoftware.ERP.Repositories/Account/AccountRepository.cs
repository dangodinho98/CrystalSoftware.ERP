using CrystalSoftware.ERP.Border.Repositories;

namespace CrystalSoftware.ERP.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IIdentityRepository _identityRepository;

        public AccountRepository(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }
    }
}
