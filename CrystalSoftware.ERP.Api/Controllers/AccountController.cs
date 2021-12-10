using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Dto.Account;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICreateAccountUseCase _createAccountUseCase;
        private readonly ILoginUseCase _loginUseCase;
        private readonly ISignOutUseCase _signOutUseCase;
        private readonly IForgotPasswordUseCase _forgotPasswordUseCase;
        private readonly IGetAccountUseCase _getAccountUseCase;
        private readonly IEditProfileUseCase _editProfileUseCase;

        public AccountController(ICreateAccountUseCase createAccountUseCase,
            ILoginUseCase loginUseCase,
            ISignOutUseCase signOutUseCase,
            IForgotPasswordUseCase forgotPasswordUseCase,
            IGetAccountUseCase getAccountUseCase,
            IEditProfileUseCase editProfileUseCase)
        {
            _createAccountUseCase = createAccountUseCase;
            _loginUseCase = loginUseCase;
            _signOutUseCase = signOutUseCase;
            _forgotPasswordUseCase = forgotPasswordUseCase;
            _getAccountUseCase = getAccountUseCase;
            _editProfileUseCase = editProfileUseCase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _createAccountUseCase.Execute(request);
            if (result.Status == UseCaseResponseKind.BadRequest)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Message);

                return View(request);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _loginUseCase.Execute(request);
            switch (result.Status)
            {
                case UseCaseResponseKind.BadRequest:
                    ModelState.AddModelError("", result.ErrorMessage);
                    return View(request);
                case UseCaseResponseKind.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    return View(request);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signOutUseCase.Execute(null);
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var model = await _getAccountUseCase.Execute(User.Identity.Name);
            if (model?.Status == UseCaseResponseKind.Success)
            {
                var request = model.Result.ToEditProfileRequest();
                return View(request);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Profile(EditProfileRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            if (HttpContext.Request.Form.Files?.Count == 1)
            {
                request.File = HttpContext.Request.Form.Files[0];

                var result = await _editProfileUseCase.Execute(request);
                if (result.Status == UseCaseResponseKind.Success)
                    return View(result.Result.ToEditProfileRequest());

                ModelState.AddModelError("", result.ErrorMessage);
            }

            return View(request);
        }
    }
}
