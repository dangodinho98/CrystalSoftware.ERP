using CrystalSoftware.ERP.Border.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CrystalSoftware.ERP.Repositories
{
    public class FileManagerRepository : IFileManagerRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileManagerRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadAvatarImage(IFormFile file)
        {
            try
            {
                var uniqueFileName = string.Empty;
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"dist\img\UserPhotos");
                var existingFile = Path.Combine(uploads, file.FileName);
                if (!File.Exists(existingFile))
                {
                    uniqueFileName = GetUniqueFileName(file.FileName);
                    var fullPath = Path.Combine(uploads, uniqueFileName);
                    file.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                return uniqueFileName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
