using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.HeaderNotificationsMenu
{
    public class HeaderNotificationsMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}