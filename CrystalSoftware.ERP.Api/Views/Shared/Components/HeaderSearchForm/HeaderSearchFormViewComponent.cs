using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.HeaderSearchForm
{
    public class HeaderSearchFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}