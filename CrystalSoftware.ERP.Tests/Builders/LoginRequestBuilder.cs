using CrystalSoftware.ERP.Border.Dto;

namespace CrystalSoftware.ERP.Tests.Builders
{
    public class LoginRequestBuilder
    {
        public readonly LoginRequest Instance;

        public LoginRequestBuilder()
        {
            Instance = new LoginRequest
            {
                Email = "test@email.com",
                Password = "123456",
                KeepLogged = false
            };
        }

        public LoginRequestBuilder WithEmail(string email)
        {
            Instance.Email = email;
            return this;
        }

        public LoginRequestBuilder WithPassword(string password)
        {
            Instance.Password = password;
            return this;
        }

        public LoginRequestBuilder WithKeepLogged(bool keepLogged)
        {
            Instance.KeepLogged = keepLogged;
            return this;
        }
    }
}
