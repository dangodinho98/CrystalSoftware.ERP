using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using CrystalSoftware.ERP.Tests.Builders;
using CrystalSoftware.ERP.UseCases.Account;
using Moq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using CrystalSoftware.ERP.Shared.Resources;
using CrystalSoftware.ERP.Border.Dto;
using Microsoft.AspNetCore.Identity;

namespace CrystalSoftware.ERP.Tests.UseCases
{
    public class LoginUseCaseTest
    {
        private readonly ILoginUseCase _useCase;
        private readonly Mock<IIdentityRepository> _identityRepository;

        public LoginUseCaseTest()
        {
            _identityRepository = new Mock<IIdentityRepository>();

            _useCase = new LoginUseCase(_identityRepository.Object, new LoginRequestValidator());
        }

        [Fact]
        public async Task Execute_WhenIdentityRepositoryFailsOnFindApplicationUserByEmail_ReturnsBadRequest()
        {
            var request = new LoginRequestBuilder().Instance;
            _identityRepository.Setup(r => r.FindApplicationUserByEmail(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            var response = await _useCase.Execute(request);

            response.Status.Should().Be(UseCaseResponseKind.BadRequest);
            response.ErrorMessage.Should().Be(Messages.InvalidUserOrPassword);

            _identityRepository.Verify(r => r.FindApplicationUserByEmail(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Execute_WhenEverythingGoesOk_ReturnsSuccess()
        {
            var request = new LoginRequestBuilder().Instance;
            var applicationUser = new ApplicationUserBuilder()
                .WithEmailConfirmed(true)
                .Instance;

            _identityRepository.Setup(r => r.FindApplicationUserByEmail(It.IsAny<string>())).ReturnsAsync(applicationUser);
            _identityRepository.Setup(r => r.PasswordSignIn(It.IsAny<ApplicationUser>(), It.IsAny<LoginRequest>())).ReturnsAsync(SignInResult.Success);

            var response = await _useCase.Execute(request);

            response.Status.Should().Be(UseCaseResponseKind.Success);

            _identityRepository.Verify(r => r.FindApplicationUserByEmail(It.IsAny<string>()), Times.Once);
            _identityRepository.Verify(r => r.PasswordSignIn(It.IsAny<ApplicationUser>(), It.IsAny<LoginRequest>()), Times.Once);
            _identityRepository.Verify(r => r.SignOut(), Times.Never);
        }


        [Fact]
        public async Task Execute_WhenPasswordSignInReturnsFalse_ReturnsBadRequest()
        {
            var request = new LoginRequestBuilder().Instance;
            var applicationUser = new ApplicationUserBuilder()
                .WithEmailConfirmed(true)
                .Instance;

            _identityRepository.Setup(r => r.FindApplicationUserByEmail(It.IsAny<string>())).ReturnsAsync(applicationUser);
            _identityRepository.Setup(r => r.PasswordSignIn(It.IsAny<ApplicationUser>(), It.IsAny<LoginRequest>())).ReturnsAsync(SignInResult.Failed);

            var response = await _useCase.Execute(request);

            response.Status.Should().Be(UseCaseResponseKind.BadRequest);
            response.ErrorMessage.Should().Be(Messages.InvalidUserOrPassword);

            _identityRepository.Verify(r => r.FindApplicationUserByEmail(It.IsAny<string>()), Times.Once);
            _identityRepository.Verify(r => r.PasswordSignIn(It.IsAny<ApplicationUser>(), It.IsAny<LoginRequest>()), Times.Once);
            _identityRepository.Verify(r => r.SignOut(), Times.Never);
        }
    }
}
