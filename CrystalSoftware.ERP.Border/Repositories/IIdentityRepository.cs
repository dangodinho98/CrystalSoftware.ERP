using CrystalSoftware.ERP.Border.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IIdentityRepository
    {
        Task<IdentityResult> AddApplicationUser(ApplicationUser appUser, string password);
        Task<ApplicationUser> FindApplicationUserByEmail(string email);
        Task<string> GenerateEmailConfirmationToken(ApplicationUser appUser);
        Task<SignInResult> PasswordSignIn(ApplicationUser applicationUser, LoginRequest request);
    }
}
