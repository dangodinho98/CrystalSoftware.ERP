using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddApplicationUser(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                //_logger.LogInformation("User created a new account with password.");

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //var callbackUrl = Url.Page(
                //    "/Account/ConfirmEmail",
                //    pageHandler: null,
                //    values: new { area = "Identity", userId = user.Id, code = code },
                //    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //{
                //    return RedirectToPage("RegisterConfirmation",
                //                          new { email = Input.Email });
                //}
                //else
                //{
                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    return LocalRedirect(returnUrl);
                //}
            }
        }

        //  foreach (var error in result.Errors)
        //{
        //    ModelState.AddModelError(string.Empty, error.Description);
        //}
    }
}
