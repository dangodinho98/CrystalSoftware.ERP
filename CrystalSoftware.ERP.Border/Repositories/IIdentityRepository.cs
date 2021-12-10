using CrystalSoftware.ERP.Border.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IIdentityRepository
    {
        Task<ApplicationUser> FindApplicationUserByEmail(string email);
        Task<ApplicationUser> FindApplicationUserByName(string name);
        Task<IdentityResult> AddApplicationUser(ApplicationUser appUser, string password);
        Task<ApplicationUser> UpdateApplicationUser(ApplicationUser applicationUser);
        Task<string> GenerateEmailConfirmationToken(ApplicationUser appUser);
        Task<SignInResult> PasswordSignIn(ApplicationUser applicationUser, LoginRequest request);
        Task<string> GeneratePasswordResetToken(ApplicationUser applicationUser);
        Task SignOut();
    }
}
