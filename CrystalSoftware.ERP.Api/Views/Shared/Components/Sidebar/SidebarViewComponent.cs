using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.Sidebar
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}