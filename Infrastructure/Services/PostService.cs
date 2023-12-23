using Core.Interfaces;
using Core.Schemas;
using Core;

namespace Infrastructure.Services
{
    public class PostService : BaseService<PostSchema, DataContext>, IPostService
    {
        DataContext dbContext;
        public PostService(DataContext _ctx) : base(_ctx)
        {
            dbContext = _ctx;
        }
    }
}
