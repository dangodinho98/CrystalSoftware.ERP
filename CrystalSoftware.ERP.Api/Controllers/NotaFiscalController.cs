using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Api.Controllers
{
    [Authorize]
    public class NotaFiscalController : Controller
    {
        public IActionResult ImportarXml()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ImportarXml(object request)
        {
            //var useCaseResponse = await _getAccountUseCase.Execute(request);
            //if (useCaseResponse.Status == UseCaseResponseKind.BadRequest)
            //{
            //    if (useCaseResponse.Errors.Any())
            //    {
            //        foreach (var item in useCaseResponse.Errors)
            //            ModelState.AddModelError("", item.Message);
            //    }

            //}

            //return Json(useCaseResponse.Result.ToList());
            return null;
        }
    }
}