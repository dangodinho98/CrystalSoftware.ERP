using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}