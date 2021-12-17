using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.HeaderAvatar
{
    public class HeaderAvatarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}