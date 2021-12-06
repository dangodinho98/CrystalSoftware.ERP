using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IIdentityRepository
    {
        Task<IdentityResult> AddApplicationUser(ApplicationUser appUser, string password);
        Task<ApplicationUser> FindApplicationUserByEmail(string email);
        Task<string> GenerateEmailConfirmationToken(ApplicationUser appUser);
        Task FindApplicationUserByEmail(object email);
        Task<SignInResult> GenerateEmailConfirmationToken(ApplicationUser applicationUser, string password);
    }
}
