using Microsoft.AspNetCore.Http;

namespace CrystalSoftware.ERP.Border.Dto.Account
{
    public class EditProfileRequest
    {
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile File { get; set; }
    }
}
