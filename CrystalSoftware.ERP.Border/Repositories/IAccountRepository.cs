using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IAccountRepository
    {
        Task AddApplicationUser(ApplicationUser applicationUser, string password);
    }
}
