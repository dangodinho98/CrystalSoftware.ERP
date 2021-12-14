using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Controllers
{
    public class Calendar : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
