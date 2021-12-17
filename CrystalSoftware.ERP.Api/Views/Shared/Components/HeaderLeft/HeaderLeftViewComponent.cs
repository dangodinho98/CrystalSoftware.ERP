using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.HeaderLeft
{
    public class HeaderLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}