using Core.Interfaces;
using Core.Schemas;
using Core;

namespace Infrastructure.Services
{
    public class CommentService : BaseService<CommentSchema, DataContext>, ICommentService
    {
        DataContext dbContext;
        public CommentService(DataContext _ctx) : base(_ctx)
        {
            dbContext = _ctx;
        }
    }
}
