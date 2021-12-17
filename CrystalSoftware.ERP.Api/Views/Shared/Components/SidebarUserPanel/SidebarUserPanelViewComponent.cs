using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.SidebarUserPanel
{
    public class SidebarUserPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}