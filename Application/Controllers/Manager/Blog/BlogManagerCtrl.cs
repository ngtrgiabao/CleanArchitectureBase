using Core.Interfaces;

namespace Application.Controllers.Manager.Blog
{
    public class BlogManagerCtrl
    {
        private readonly IBlogService blogService;
        public BlogManagerCtrl(IBlogService _blogService)
        {
            blogService = _blogService;
        }

        public async Task<IResult> GetAsync()
        {
            var response = await blogService.GetAll();
            return Results.Ok(response);
        }
    }
}
