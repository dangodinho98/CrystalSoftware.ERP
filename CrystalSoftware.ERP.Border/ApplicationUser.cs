using Microsoft.AspNetCore.Identity;
using System;

namespace CrystalSoftware.ERP.Border
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Avatar { get; set; }
    }
}
