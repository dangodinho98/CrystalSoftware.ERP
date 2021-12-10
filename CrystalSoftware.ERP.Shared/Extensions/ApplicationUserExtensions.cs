using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Dto.Account;

namespace CrystalSoftware.ERP.Shared.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static EditProfileRequest ToEditProfileRequest(this ApplicationUser applicationUser)
        {
            return new EditProfileRequest
            {
                Avatar = applicationUser.Avatar,
                UserName = applicationUser.UserName,
                FullName = applicationUser.FullName,
                Email = applicationUser.Email,
            };
        }
    }
}
