using CrystalSoftware.ERP.Border.Dto;

namespace CrystalSoftware.ERP.Border.Extensions
{
    public static class CreateAccountRequestExtensions
    {
        public static ApplicationUser ToApplicationUser(this CreateAccountRequest request)
        {
            var applicationUser = new ApplicationUser() 
            {
                Email = request.Email,
                UserName = request.UserName,
                LockoutEnabled = true
            };
            return applicationUser;
        }
    }
}
