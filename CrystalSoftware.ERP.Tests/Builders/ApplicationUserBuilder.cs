using CrystalSoftware.ERP.Border;

namespace CrystalSoftware.ERP.Tests.Builders
{
    public class ApplicationUserBuilder
    {
        public readonly ApplicationUser Instance;
        public ApplicationUserBuilder()
        {
            Instance = new ApplicationUser
            {
                Email = "test@mail.com",
                UserName = "Administrator"
            };
        }

        public ApplicationUserBuilder WithEmailConfirmed(bool emailConfirmed)
        {
            Instance.EmailConfirmed = emailConfirmed;
            return this;
        }
    }
}
