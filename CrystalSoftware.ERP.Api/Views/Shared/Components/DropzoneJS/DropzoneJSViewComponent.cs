using CrystalSoftware.ERP.Api.Views.Shared.Components.DropzoneJS;
using Microsoft.AspNetCore.Mvc;

namespace CrystalSoftware.ERP.Api.Shared.Components.DropzoneJS
{
    public class DropzoneJSViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DropzoneJSViewModel dropzoneJSViewModel) => View(dropzoneJSViewModel);
    }
}