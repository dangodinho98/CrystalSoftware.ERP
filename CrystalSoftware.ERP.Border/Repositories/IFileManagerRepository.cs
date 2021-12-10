using Microsoft.AspNetCore.Http;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IFileManagerRepository
    {
        string UploadAvatarImage(IFormFile file);
    }
}
