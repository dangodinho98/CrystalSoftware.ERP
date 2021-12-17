using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.SidebarBrand
{
    public class SidebarBrandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}