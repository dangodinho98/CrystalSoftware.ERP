using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.HeaderMessagesMenu
{
    public class HeaderMessagesMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}