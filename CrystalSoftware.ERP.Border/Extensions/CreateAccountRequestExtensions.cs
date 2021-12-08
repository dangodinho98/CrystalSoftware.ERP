using CrystalSoftware.ERP.Border.Dto;
using System;

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
                FullName = request.Name,
                LockoutEnabled = true,
                CreationDate = DateTime.Now
            };
            return applicationUser;
        }
    }
}
