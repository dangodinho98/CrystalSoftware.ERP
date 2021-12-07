using System.ComponentModel.DataAnnotations;

namespace CrystalSoftware.ERP.Border.Dto
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
