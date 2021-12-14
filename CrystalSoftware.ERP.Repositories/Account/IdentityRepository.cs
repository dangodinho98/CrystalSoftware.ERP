using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Dto.Account;
using CrystalSoftware.ERP.Border.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Repositories.Account
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
    {
        public IdentityRepository(IServiceScopeFactory serviceScopeFactory) 
            : base(serviceScopeFactory)
        {
        }

        public async Task<IdentityResult> AddApplicationUser(ApplicationUser applicationUser, string password)
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            return await userManager.CreateAsync(applicationUser, password);
        }

        public async Task<ApplicationUser> FindApplicationUserByEmail(string email)
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            var applicationUser = await userManager.FindByEmailAsync(email);
            
            return applicationUser;
        }

        public async Task<string> GenerateEmailConfirmationToken(ApplicationUser applicationUser)
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            var token = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
          
            return token;
        }

        public async Task<SignInResult> PasswordSignIn(ApplicationUser applicationUser, LoginRequest request)
        {
            var signInManager = GetService<SignInManager<ApplicationUser>>();
            var result = await signInManager.PasswordSignInAsync(applicationUser.UserName, request.Password, request.KeepLogged, true);

            if (result.Succeeded)
                await signInManager.SignInAsync(applicationUser, request.KeepLogged);

            return result;
        }

        public async Task SignOut()
        {
            var signInManager = GetService<SignInManager<ApplicationUser>>();
            await signInManager.SignOutAsync();
        }

        public async Task<string> GeneratePasswordResetToken(ApplicationUser applicationUser)
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            var token = await userManager.GeneratePasswordResetTokenAsync(applicationUser);
            
            return token;
        }

        public async Task<ApplicationUser> FindApplicationUserByName(string name)
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            var applicationUser = await userManager.FindByNameAsync(name);
            
            return applicationUser;
        }

        public async Task<ApplicationUser> UpdateApplicationUser(ApplicationUser applicationUser)
        {
            var context = GetService<ApplicationDbContext>();

            context.Entry(applicationUser).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return applicationUser;
        }

        public async Task<IEnumerable<ApplicationUser>> FindApplicationUsersWithFilters(GetAccountFiltersRequest request)
        {
            var context = GetService<ApplicationDbContext>();
            var applicationUsers = await context.Users.ToListAsync();

            return applicationUsers;
        }
    }
}
