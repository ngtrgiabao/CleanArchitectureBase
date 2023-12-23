using Core.Interfaces;
using Microsoft.AspNetCore.Http; 

namespace Infrastructure.Services
{
    public class UploadService : IUploadService
	{

        public UploadService()
        {
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            string folder = "wwwroot/images/";
            folder += file.FileName + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			using var stream = File.OpenWrite(folder);
            await file.CopyToAsync(stream);

            return folder;
        }

    }
}
