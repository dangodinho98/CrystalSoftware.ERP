using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICreateAccountUseCase _createAccountUseCase;

        public AccountController(ICreateAccountUseCase createAccountUseCase)
        {
            _createAccountUseCase = createAccountUseCase;
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
        public async Task<ActionResult> Register(CreateAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _createAccountUseCase.Execute(request);

            return RedirectToAction("Index", "Home");
        }
    }
}
