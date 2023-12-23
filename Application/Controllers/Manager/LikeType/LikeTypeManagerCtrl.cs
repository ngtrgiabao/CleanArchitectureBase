using Core;
using Core.Interfaces;
using Infrastructure.Services;

namespace Application.Controllers.Manager.LikeType
{
    public class LikeTypeManagerCtrl
    {
        private readonly ILikeTypeService likeTypeService;
        public LikeTypeManagerCtrl(DataContext ctx)
        {
            likeTypeService = new LikeTypeService(ctx);
        }

        public async Task<IResult> GetAsync()
        {
            var response = await likeTypeService.GetAll();
            return Results.Ok(response);
        }

        public async Task<IResult> CreateAsync(LikeTypePresenter model)
        {
            var response = await likeTypeService.Add(new Core.Schemas.LikeTypeSchema());
            return Results.Ok(response);
        }

        public async Task<IResult> UpdateAsync(LikeTypePresenter model)
        {
            var response = await likeTypeService.Update(new Core.Schemas.LikeTypeSchema());
            return Results.Ok(response);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var response = await likeTypeService.Delete(id);
            return Results.Ok(response);
        }
    }
}
