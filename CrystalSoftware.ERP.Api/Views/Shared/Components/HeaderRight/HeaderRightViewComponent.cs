using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.HeaderRight
{
    public class HeaderRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}