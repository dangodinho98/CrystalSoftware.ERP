using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICreateAccountUseCase _createAccountUseCase;
        private readonly ILoginUseCase _loginUseCase;
        private readonly ISignOutUseCase _signOutUseCase;
        private readonly IForgotPasswordUseCase _forgotPasswordUseCase;
        private readonly IProfileUseCase _profileUseCase;

        public AccountController(ICreateAccountUseCase createAccountUseCase,
            ILoginUseCase loginUseCase,
            ISignOutUseCase signOutUseCase,
            IForgotPasswordUseCase forgotPasswordUseCase,
            IProfileUseCase profileUseCase)
        {
            _createAccountUseCase = createAccountUseCase;
            _loginUseCase = loginUseCase;
            _signOutUseCase = signOutUseCase;
            _forgotPasswordUseCase = forgotPasswordUseCase;
            _profileUseCase = profileUseCase;
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
            var model = await _profileUseCase.Execute(User.Identity.Name);
            if (model?.Status == UseCaseResponseKind.Success)
            {
                return View(model.Result);
            }
        
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public async Task<IActionResult> Profile(ProfileEditRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(request);
        //    }

        //    var result = await _loginUseCase.Execute(request);
        //    switch (result.Status)
        //    {
        //        case UseCaseResponseKind.BadRequest:
        //            ModelState.AddModelError("", result.ErrorMessage);
        //            return View(request);
        //        case UseCaseResponseKind.Success:
        //            return RedirectToAction("Index", "Home");
        //        default:
        //            return View(request);
        //    }
        //}
    }
}
