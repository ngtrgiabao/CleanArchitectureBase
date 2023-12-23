using Core;
using Core.Interfaces;
using Infrastructure.Services;

namespace Application.Controllers
{
    public class PermCtrl
    {
        private readonly IPermService permService;
        public PermCtrl(DataContext dbContext)
        {
            permService = new PermService(dbContext);
        }

        public async Task<IResult> GetAllAsync()
        {
            var response = await permService.GetAll();
            return Results.Ok(response);
        }
    }
}
