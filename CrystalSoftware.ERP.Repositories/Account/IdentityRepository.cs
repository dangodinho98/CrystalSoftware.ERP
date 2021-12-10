﻿using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Repositories.Account
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public IdentityRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IdentityResult> AddApplicationUser(ApplicationUser applicationUser, string password)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

            return await userManager.CreateAsync(applicationUser, password);
        }

        public async Task<ApplicationUser> FindApplicationUserByEmail(string email)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

            var applicationUser = await userManager.FindByEmailAsync(email);
            return applicationUser;
        }

        public async Task<string> GenerateEmailConfirmationToken(ApplicationUser applicationUser)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

            var token = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            return token;
        }

        public async Task<SignInResult> PasswordSignIn(ApplicationUser applicationUser, LoginRequest request)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var signInManager = (SignInManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(SignInManager<ApplicationUser>));

            var result = await signInManager.PasswordSignInAsync(applicationUser.UserName, request.Password, request.KeepLogged, true);

            if (result.Succeeded)
                await signInManager.SignInAsync(applicationUser, request.KeepLogged);

            return result;
        }

        public async Task SignOut()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var signInManager = (SignInManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(SignInManager<ApplicationUser>));

            await signInManager.SignOutAsync();
        }

        public async Task<string> GeneratePasswordResetToken(ApplicationUser applicationUser)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

            var token = await userManager.GeneratePasswordResetTokenAsync(applicationUser);
            return token;
        }

        public async Task<ApplicationUser> FindApplicationUserByName(string name)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

            var applicationUser = await userManager.FindByNameAsync(name);
            return applicationUser;
        }

        public async Task<ApplicationUser> UpdateApplicationUser(ApplicationUser applicationUser)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var userDbContext = (ApplicationDbContext)scope.ServiceProvider.GetService(typeof(ApplicationDbContext));

            userDbContext.Entry(applicationUser).State = EntityState.Modified;
            await userDbContext.SaveChangesAsync();

            return applicationUser;
        }
    }
}
