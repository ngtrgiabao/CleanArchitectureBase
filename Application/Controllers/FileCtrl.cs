using Core.Interfaces; 
using Infrastructure.Services;

namespace Application.Controllers
{
    public class FileCtrl
    {
        private readonly IUploadService uploadService;
        public FileCtrl()
        {
            uploadService = new UploadService();
        }
         
        public async Task<IResult> Post(IFormFile file)
        {
            var res = await uploadService.UploadImage(file);

            return Results.Ok(res);
        }

    }
}
