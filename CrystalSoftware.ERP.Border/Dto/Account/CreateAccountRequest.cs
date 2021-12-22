using System.ComponentModel.DataAnnotations;

namespace CrystalSoftware.ERP.Border.Dto
{
    public class CreateAccountRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string RetypePassword { get; set; }
        public bool AgreeTerms { get; set; }

        public string RedirectToAction { get; set; }
    }
}
