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

        public AccountController(ICreateAccountUseCase createAccountUseCase,
            ILoginUseCase loginUseCase)
        {
            _createAccountUseCase = createAccountUseCase;
            _loginUseCase = loginUseCase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
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

        public ActionResult Login()
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
            if (result.Status == UseCaseResponseKind.NotFound)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(request);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
